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
            ValidationResponse validationResp = await EventReservationResponse(crtReservationDto.IdUser, crtReservationDto.StartTime, crtReservationDto.EndTime, crtReservationDto.FurnitureIds, "create");
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
            ValidationResponse validationResp = await EventReservationResponse(reservationDto.IdUser, reservationDto.StartTime, reservationDto.EndTime, reservationDto.FurnitureIds, "update");
            if (!validationResp.IsValid)
                return await Task.FromResult(response.UpdateResponse(response, "", 400, false, validationResp.Message, ""));

            int idReservation = _unitOfWork.Reservation.GetReservationIdByUserId(reservationDto.IdUser);

            _unitOfWork.Reservation.UpdateReservationByDto(idReservation, reservationDto);

            int idEvent = _unitOfWork.Reservation.GetReservationEventId(idReservation);
            
            _unitOfWork.Event.UpdateEventByDTO(idEvent, reservationDto);

            response.UpdateResponse(response, "", 200, true, "", "reservation updated");
            
            _unitOfWork.Complete();
            
            return await Task.FromResult(response);
        }

        private async Task<ValidationResponse> EventReservationResponse(int idUser, DateTime evStartTime, DateTime evEndtime, List<int> furnitureIds, string action) 
        {
            ValidationResponse validationResp = _userValidation.UserValidateScheduleReservation(idUser);
            if (!validationResp.IsValid && action != "update")
                return validationResp;

            validationResp = _reservationValidation.ScheduleDateTimeValidation(evStartTime, evEndtime);
            if (!validationResp.IsValid)
                return validationResp;

            if (furnitureIds != null)
            {
                validationResp = _furnitureReservationValidation.ValidateFurniture(furnitureIds);
                if (!validationResp.IsValid)
                    return validationResp;
            }

            validationResp = await _reservationValidation.ReservationOverlapValidation(evStartTime, evEndtime);
            if (!validationResp.IsValid)
                return validationResp;

            return validationResp.SetResponse("Valid", true);
        }
    }
}
