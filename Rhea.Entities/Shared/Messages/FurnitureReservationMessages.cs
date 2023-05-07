using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities.Shared.Messages
{
    public class FurnitureReservationMessages
    {
        public static readonly string ValidFurnitureReservation = "Reservations timeframe is valid";
        public static readonly string MoreThanTenFurniture = "You cannot rent more than 10 furniture pieces at this moment";
        public static readonly string FurnitureNotAvailable = "One or more furnitures are not available";
    }
}
