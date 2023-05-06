using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities.Shared.Messages
{
    public class ReservationMessages
    {
        public static readonly string ValidReservation = "Reservations timeframe is valid";
        public static readonly string EndTimeGreaterThanStartTime = "The endtime cannot be greater than or equal to the start time";
        public static readonly string LessThanOneHour = "You cannot reserved less than 1 hour";
        public static readonly string DifferentDates = "The start time and the endtime cannot have different dates";
        public static readonly string NoSundays = "Reservations are not allowed on sundays";
        public static readonly string EventStartBeforeSeven = "From monday to thursday, the event cannot start before 7:30 AM";
        public static readonly string EventEndAfterNine = "From monday to thursday, the event cannot end after 9:00 PM";
        public static readonly string EventStartBeforeThree = "From friday to saturday, the event cannot start before 3:00 pm";
        public static readonly string EventEndAfterEleven = "From friday to saturday, the event cannot end after 11:00 pm";
    }
}
