using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class FurnitureStatus : BaseTypeEntity
    {
        public ICollection<Furniture> Furniture { get; set; }
    }
}
