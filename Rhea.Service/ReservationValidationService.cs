using Rhea.Entities;
using Rhea.Entities.Shared;
using Rhea.Entities.Shared.Messages;
using Rhea.Interfaces.Generic;
using Rhea.Interfaces.Service;
using System.Reflection.Metadata.Ecma335;

namespace Rhea.Service
{
    public class ReservationValidationService : IReservationValidationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationValidationService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

       public ValidationResponse ScheduleDateTimeValidation(DateTime starTime, DateTime endTime)
        {
            var reservationValidation = new ValidationResponse();

            if (starTime.Hour > endTime.Hour)
                return reservationValidation.SetResponse(ReservationMessages.EndTimeGreaterThanStartTime, false);

            if (starTime.Hour == endTime.Hour)
                return reservationValidation.SetResponse(ReservationMessages.LessThanOneHour, false);

            if (starTime.Date != endTime.Date)
                return reservationValidation.SetResponse(ReservationMessages.DifferentDates, false);

            if (starTime.DayOfWeek == DayOfWeek.Sunday)
                return reservationValidation.SetResponse(ReservationMessages.NoSundays, false);

            if (starTime.DayOfWeek >= DayOfWeek.Monday && starTime.DayOfWeek <= DayOfWeek.Thursday)
            {
                if (starTime.Hour < 7 || starTime.Hour == 7 && starTime.Minute < 30)
                    return reservationValidation.SetResponse(ReservationMessages.EventStartBeforeSeven, false);

                if (endTime.Hour > 19 || endTime.Hour == 19 && endTime.Minute > 0)
                    return reservationValidation.SetResponse(ReservationMessages.EventEndAfterNine, false);
            }

            if (starTime.DayOfWeek >= DayOfWeek.Friday && starTime.DayOfWeek <= DayOfWeek.Saturday)
            {
                if (starTime.Hour < 15 || starTime.Hour == 15 && starTime.Minute < 0)
                    return reservationValidation.SetResponse(ReservationMessages.EventStartBeforeThree, false);

                if (endTime.Hour > 23 || endTime.Hour == 23 && endTime.Minute > 0)
                    return reservationValidation.SetResponse(ReservationMessages.EventEndAfterEleven, false); ;
            }

            return reservationValidation.SetResponse(ReservationMessages.ValidReservation, true);
        }

        public async Task<ValidationResponse> ReservationOverlapValidation(DateTime starTime, DateTime endTime)
        {
            var timeOverlapValidation = new ValidationResponse();
            
            List<Reservation> reservationList = await _unitOfWork.Reservation.GetReservationByStartTimeDate(starTime);
            
            bool isTimeOverlap = false;

            if (reservationList.Count > 0)
            {
                reservationList.ForEach(reservation =>
                {
                    isTimeOverlap = TimeOverlapValidation(reservation.StartTime, reservation.EndTime, starTime, endTime);
                });
            }
           
            return isTimeOverlap 
                ? timeOverlapValidation.SetResponse(ReservationMessages.ScheduleOverlap, false)
                : timeOverlapValidation.SetResponse(ReservationMessages.ValidReservation, true);
        }

        public static bool TimeOverlapValidation(DateTime firstStartTime, DateTime firstEndTime, DateTime secondStartTime, DateTime secondEndTime)
        {
            return firstStartTime.TimeOfDay < secondEndTime.TimeOfDay && firstEndTime.TimeOfDay > secondStartTime.TimeOfDay;
        }
    }
}