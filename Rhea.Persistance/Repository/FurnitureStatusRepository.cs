using Microsoft.EntityFrameworkCore;
using Rhea.DAL.SQL;
using Rhea.Entities.ComboBox;
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

        public async Task<List<ComboBox>> GetEventStatusComboBox() => await context.FurnitureStatuses.Select(x => new ComboBox
        {
            Id = x.Id,
            Name = x.Name,
        }).ToListAsync();
    }
}
