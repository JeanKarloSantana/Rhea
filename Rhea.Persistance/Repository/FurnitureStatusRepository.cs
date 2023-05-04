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
    public class FurnitureStatusRepository : BaseRepository<FurnitureStatus>, IFurnitureStatusRepository
    {
        public RheaDbContext Context { get { return context; } }

        public FurnitureStatusRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
