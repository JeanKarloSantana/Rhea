using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhea.Entities.ComboBox;

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
        [Column("date_created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Column("start_time")]
        public DateTime StartTime { get; set; }
        [Column("end_time")]
        public DateTime EndTime { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public ICollection<FurnitureDetail> FurnitureDetail { get; set; }
    }
}
