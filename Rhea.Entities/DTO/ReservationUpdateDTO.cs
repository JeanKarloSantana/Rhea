using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities.DTO
{
    public class ReservationUpdateDTO
    {
        public int IdUser { get; set; }
        public int IdReservation { get; set; }
        public int IdReservationStatus { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int IdEventType { get; set; }
        public int IdEventStatus { get; set;}
        public string EventName { get; set; }
    }
}
