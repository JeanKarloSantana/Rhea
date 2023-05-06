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
        private ResponseDTO<string> response;

        public EventManager(IUnitOfWork unitOfWork, IReservationValidationService reservationValidation) 
        {
            _unitOfWork = unitOfWork;
            _reservationValidation = reservationValidation;
            response = new ResponseDTO<string>();
        }

        private void updateResponse(ushort statusCode, bool succeed, string error, string message)
        {
            response.Message = message;
            response.StatusCode = statusCode;
            response.Succeed = succeed;
            response.Errors.Add(error);            
        }

        public async Task<ResponseDTO<string>> CreateReservation(PostEventDto crtReservationDto)
        {
            var validationResp = new ValidationResponse();

            bool isUserValid = userValidation(crtReservationDto.IdUser);
            
            if (!isUserValid)
            {
                updateResponse(400, false, "This User cannot make reservation at this time", "");
                return await Task.FromResult(response);
            }

            validationResp = _reservationValidation.ScheduleDateTimeValidation(crtReservationDto.StartTime, crtReservationDto.EndTime);
            if(!validationResp.IsValid) 
            {
                updateResponse(400, false, validationResp.Message, "");
                return await Task.FromResult(response);
            }

            (string message, bool funitureVal) furnitureValidation = ("", true);
            if (crtReservationDto.FurnitureIds != null) furnitureValidation = ValidateFurniture(crtReservationDto.FurnitureIds);

            if (!furnitureValidation.funitureVal)
            {
                updateResponse(400, false, furnitureValidation.message, "");
                return await Task.FromResult(response);
            };

            Event @event = _unitOfWork.Event.CreateEventByDTO(crtReservationDto);
            
            Reservation reservation = _unitOfWork.Reservation.AddReservationByEventDTO(crtReservationDto, @event.Id);
            
            _unitOfWork.User.UpdateUserStatus(crtReservationDto.IdUser, (int)UserStatusEnum.DUE);
            
            if(crtReservationDto.FurnitureIds != null) _unitOfWork.FurnitureDetail.AddFurnitureDetailByListIds(crtReservationDto.FurnitureIds, reservation.Id);
           
            _unitOfWork.Complete();

            updateResponse(200, true, "", "Reservation Created");

            return await Task.FromResult(response);
        }

        public async Task<ResponseDTO<string>> UpdateReservationByDto(ReservationUpdateDTO reservationDto)
        {
            int idReservation = _unitOfWork.Reservation.GetReservationIdByUserId(reservationDto.IdUser);
            
            _unitOfWork.Reservation.UpdateReservationByDto(idReservation, reservationDto);

            int idEvent = _unitOfWork.Reservation.GetReservationEventId(idReservation);
            
           _unitOfWork.Event.UpdateEventByDTO(idEvent, reservationDto);
            
            updateResponse(200, true, "", "reservation updated");
            
            _unitOfWork.Complete();
            
            return await Task.FromResult(response);
        }

        private bool userValidation(int idUser) 
        {
            Person person = _unitOfWork.Person.GetPersonById(idUser);
            if (person != null)
            {
                if (CalculateAge(person.DateOfBirth) < 21 || person.User.IdUserStatus != (int)UserStatusEnum.AVAILABLE) return false;
                return true;
            }

            Company company = _unitOfWork.Company.GetCompanyById(idUser);
            return company.User.IdUserStatus == (int)UserStatusEnum.AVAILABLE;
        }

        private (string message, bool funitureVal) ValidateFurniture(List<int> furnitureIds)
        {
            var furnitureVal = ("", false);
            
            if (furnitureIds.Count > 10) 
            {
                furnitureVal.Item1 = "You cannot rent more than 10 furniture pieces at this moment";
                return furnitureVal;
            }

            var furnitureAvail = _unitOfWork.Furniture.GetAll()
                .Where(x => furnitureIds.Contains(x.Id) && x.IdFurnitureStatus == 1)
                .Count();

            if(furnitureAvail != furnitureIds.Count) 
            {
                furnitureVal.Item1 = "One or more furnitures are not available";
                return furnitureVal;
            }
            
            furnitureVal.Item2 = true;

            return furnitureVal;
        }

        private async Task<(string message, bool canSchedule)> ReservationValidation(DateTime starTime, DateTime endTime)
        {  
            (string, bool) isValidReservation = ScheduleDateTimeValidation(starTime, endTime);
            if (isValidReservation.Item2 != true) return isValidReservation;

            bool isReservationOverlap = await ReservationOverlapValidation(starTime, endTime);
            
            if (isReservationOverlap) 
            {
                isValidReservation.Item1 = "There is a time overlap with another reservation";
                isValidReservation.Item2 = false;
                return isValidReservation;
            }

            isValidReservation.Item2 = true; 
            return isValidReservation;
        }

        private async Task<bool> ReservationOverlapValidation(DateTime starTime, DateTime endTime) 
        {
            List<Reservation> reservationList = await _unitOfWork.Reservation.GetReservationByStartTimeDate(starTime);
            bool isTimeOverlap = false;
            
            if (reservationList.Count > 0)
            {
                reservationList.ForEach(reservation =>
                {
                    isTimeOverlap = TimeOverlapValidation(reservation.StartTime, reservation.EndTime, starTime, endTime);
                });
            }

            return isTimeOverlap;
        }

        private static bool TimeOverlapValidation(DateTime firstStartTime, DateTime firstEndTime, DateTime secondStartTime, DateTime secondEndTime)
        {
            return firstStartTime.TimeOfDay < secondEndTime.TimeOfDay && firstEndTime.TimeOfDay > secondStartTime.TimeOfDay;
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthdate.Year;
            if (now < birthdate.AddYears(age))
                age--;
            return age;
        }

        private static (string, bool) ScheduleDateTimeValidation(DateTime starTime, DateTime endTime)
        {
            if (starTime.Hour > endTime.Hour)
                return ("The endtime cannot be greater than or equal to the start time", false);

            if (starTime.Hour == endTime.Hour)
                return ("You cannot reserved less than 1 hour", false);
            
            if (starTime.Date != endTime.Date)
                return ("The start time and the endtime cannot have different dates", false);

            if (starTime.DayOfWeek == DayOfWeek.Sunday)
                return ("Reservations are not allowed on sundays", false);

            if (starTime.DayOfWeek >= DayOfWeek.Monday && starTime.DayOfWeek <= DayOfWeek.Thursday)
            {
                if (starTime.Hour < 7 || starTime.Hour == 7 && starTime.Minute < 30)
                    return ("From monday to thursday, the event cannot start before 7:30 AM", false);

                if (endTime.Hour > 19 || endTime.Hour == 19 && endTime.Minute > 0)
                    return ("From monday to thursday, the event cannot end after 9:00 PM", false);
            }

            if (starTime.DayOfWeek >= DayOfWeek.Friday && starTime.DayOfWeek <= DayOfWeek.Saturday)
            {
                if (starTime.Hour < 15 || starTime.Hour == 15 && starTime.Minute < 0)
                    return ("From friday to saturday, the event cannot start before 3:00 pm", false);

                if (endTime.Hour > 23 || endTime.Hour == 23 && endTime.Minute > 0)
                    return ("From friday to saturday, the event cannot end after 11:00 pm", false);
            }

            return ("", true);
        }
    }
}
