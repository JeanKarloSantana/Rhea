using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Entities.Enums;
using Rhea.Entities.Shared;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;
using Rhea.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Domain.ReservationManager
{
    public class EventManager : IEventManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationValidationService _reservationValidation;
        private readonly IUserValidationService _userValidation;
        private readonly IFurnitureReservationValidationService _furnitureReservationValidation;
        private ResponseDTO<string> response;

        public EventManager(IUnitOfWork unitOfWork, 
            IReservationValidationService reservationValidation,
            IUserValidationService userValidation,
            IFurnitureReservationValidationService furnitureReservationValidation
            ) 
        {
            _unitOfWork = unitOfWork;
            _reservationValidation = reservationValidation;
            _userValidation = userValidation;
            _furnitureReservationValidation = furnitureReservationValidation;
            response = new ResponseDTO<string>();
        }

        public async Task<ResponseDTO<string>> CreateReservation(PostEventDto crtReservationDto)
        {
            var validationResp = new ValidationResponse();

            validationResp = _userValidation.UserValidateScheduleReservation(crtReservationDto.IdUser);
            if (!validationResp.IsValid)
                return await Task.FromResult(response.UpdateResponse(response, "", 400, false, validationResp.Message, ""));

            validationResp = _reservationValidation.ScheduleDateTimeValidation(crtReservationDto.StartTime, crtReservationDto.EndTime);
            if (!validationResp.IsValid)
                return await Task.FromResult(response = response.UpdateResponse(response, "", 400, false, validationResp.Message, ""));

            validationResp = _furnitureReservationValidation.ValidateFurniture(crtReservationDto.FurnitureIds);
            if (!validationResp.IsValid)
                return await Task.FromResult(response.UpdateResponse(response, "", 400, false, validationResp.Message, ""));

            validationResp = await _reservationValidation.ReservationOverlapValidation(crtReservationDto.StartTime, crtReservationDto.EndTime);
            if (!validationResp.IsValid)
                return await Task.FromResult(response.UpdateResponse(response, "", 400, false, validationResp.Message, ""));

            Event @event = _unitOfWork.Event.CreateEventByDTO(crtReservationDto);
            
            Reservation reservation = _unitOfWork.Reservation.AddReservationByEventDTO(crtReservationDto, @event.Id);
            
            _unitOfWork.User.UpdateUserStatus(crtReservationDto.IdUser, (int)UserStatusEnum.DUE);
            
            if(crtReservationDto.FurnitureIds != null) _unitOfWork.FurnitureDetail.AddFurnitureDetailByListIds(crtReservationDto.FurnitureIds, reservation.Id);
           
            _unitOfWork.Complete();
            response = response.UpdateResponse(response, "", 200, true, "", "Reservation Created");
            return await Task.FromResult(response);
        }

        public async Task<ResponseDTO<string>> UpdateReservationByDto(ReservationUpdateDTO reservationDto)
        {
            int idReservation = _unitOfWork.Reservation.GetReservationIdByUserId(reservationDto.IdUser);
            
            _unitOfWork.Reservation.UpdateReservationByDto(idReservation, reservationDto);

            int idEvent = _unitOfWork.Reservation.GetReservationEventId(idReservation);
            
           _unitOfWork.Event.UpdateEventByDTO(idEvent, reservationDto);

            response.UpdateResponse(response, "", 200, true, "", "reservation updated");
            
            _unitOfWork.Complete();
            
            return await Task.FromResult(response);
        }
    }
}
