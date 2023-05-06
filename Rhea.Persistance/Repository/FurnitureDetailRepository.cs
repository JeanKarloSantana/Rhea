using Rhea.DAL.SQL;
using Rhea.Entities;
using Rhea.Interfaces.Repository;
using Rhea.Persistance.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Persistance.Repository
{
    public class FurnitureDetailRepository : BaseRepository<FurnitureDetail>, IFurnitureDetailRepository
    {
        public RheaDbContext Context { get { return context; } }

        public FurnitureDetailRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }

        public void AddFurnitureDetailByListIds(List<int> furnitureIds, int reservationId)
        {
            furnitureIds.ForEach(id =>
            {
                var furnitureDetail = new FurnitureDetail
                {
                    IdFurniture = id,
                    IdReservation = reservationId
                };

                Add(furnitureDetail);
            });
        }
    }
}
