using Rhea.Entities.Shared;
using Rhea.Entities.Shared.Messages;
using Rhea.Interfaces.Service;

namespace Rhea.Service
{
    public class ReservationValidationService : IReservationValidationService
    {

        private ValidationResponse SetResponse(ValidationResponse reservationValidation, string message, bool isValid)
        {
            reservationValidation.SetMessage(message);
            reservationValidation.SetIsValid(isValid);
            
            return reservationValidation;
        }

       public ValidationResponse ScheduleDateTimeValidation(DateTime starTime, DateTime endTime)
        {
            var reservationValidation = new ValidationResponse();

            if (starTime.Hour > endTime.Hour)
                return SetResponse(reservationValidation, ReservationMessages.EndTimeGreaterThanStartTime, false);

            if (starTime.Hour == endTime.Hour)
                return SetResponse(reservationValidation, ReservationMessages.LessThanOneHour, false);

            if (starTime.Date != endTime.Date)
                return SetResponse(reservationValidation, ReservationMessages.DifferentDates, false);

            if (starTime.DayOfWeek == DayOfWeek.Sunday)
                return SetResponse(reservationValidation, ReservationMessages.NoSundays, false);

            if (starTime.DayOfWeek >= DayOfWeek.Monday && starTime.DayOfWeek <= DayOfWeek.Thursday)
            {
                if (starTime.Hour < 7 || starTime.Hour == 7 && starTime.Minute < 30)
                    return SetResponse(reservationValidation, ReservationMessages.EventStartBeforeSeven, false);

                if (endTime.Hour > 19 || endTime.Hour == 19 && endTime.Minute > 0)
                    return SetResponse(reservationValidation, ReservationMessages.EventEndAfterNine, false);
            }

            if (starTime.DayOfWeek >= DayOfWeek.Friday && starTime.DayOfWeek <= DayOfWeek.Saturday)
            {
                if (starTime.Hour < 15 || starTime.Hour == 15 && starTime.Minute < 0)
                    return SetResponse(reservationValidation, ReservationMessages.EventStartBeforeThree, false);

                if (endTime.Hour > 23 || endTime.Hour == 23 && endTime.Minute > 0)
                    return SetResponse(reservationValidation, ReservationMessages.EventEndAfterEleven, false); ;
            }

            return SetResponse(reservationValidation, ReservationMessages.ValidReservation, true);
        }
    }
}