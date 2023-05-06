using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class Furniture : BaseTypeEntity
    {
        public int IdFurnitureStatus { get; set; }
        public FurnitureStatus FurnitureStatus { get; set; }
        public ICollection<FurnitureDetail> FurnitureDetail { get; set; }
    }
}
