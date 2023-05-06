using Rhea.Entities;
using Rhea.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Interfaces.Repository
{
    public interface IFurnitureDetailRepository : IBaseRepository<FurnitureDetail>
    {
        void AddFurnitureDetailByListIds(List<int> furnitureIds, int reservationId);
    }
}
