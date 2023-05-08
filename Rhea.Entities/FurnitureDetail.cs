using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class FurnitureDetail
    {
        [Column("id_reservation")]
        public int IdReservation { get; set; }
        [Column("id_furniture")]
        public int IdFurniture { get; set; }
        public Reservation Reservation { get; set; }
        public Furniture Furniture { get; set; }
    }
}
