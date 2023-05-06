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
    public class EventStatusRepository : BaseRepository<EventStatus>, IEventStatusRepository
    {
        public RheaDbContext Context { get { return context; } }

        public EventStatusRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
