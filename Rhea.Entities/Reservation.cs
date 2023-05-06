using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        [Column("id_user")]
        public int IdUser { get; set; }
        [Column("id_event")]
        public int IdEvent { get; set; }
        [Column("id_reservation_status")]
        public int IdReservationStatus { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public ICollection<FurnitureDetail> FurnitureDetail { get; set; }
    }
}
