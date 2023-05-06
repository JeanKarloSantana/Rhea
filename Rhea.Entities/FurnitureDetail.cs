using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class FurnitureDetail
    {
        public int IdReservation { get; set; }
        public int IdFurniture { get; set; }
        public Reservation Reservation { get; set; }
        public Furniture Furniture { get; set; }
    }
}
