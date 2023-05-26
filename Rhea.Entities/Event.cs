using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhea.Entities.ComboBox;

namespace Rhea.Entities
{
    public class Event : BaseTypeEntity
    {
        [Column("id_event_type")]
        public int IdEventType { get; set; }
        [Column("id_event_status")]
        public int IdEventStatus { get; set; }
        public EventType EventType { get; set; }
        public EventStatus EventStatus { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
    }
}
