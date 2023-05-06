using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class Event : BaseTypeEntity
    { 
        public int IdEventType { get; set; }
        public int IdEventStatus { get; set; }
        public EventType EventType { get; set; }
        public EventStatus EventStatus { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
    }
}
