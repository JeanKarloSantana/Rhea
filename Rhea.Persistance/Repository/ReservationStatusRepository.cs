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
    public class ReservationStatusRepository : BaseRepository<ReservationStatus>, IReservationStatusRepository
    {
        public RheaDbContext Context { get { return context; } }

        public ReservationStatusRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ComboBox>> GetEventStatusComboBox() => await context.ReservationStatuses.Select(x => new ComboBox
        {
            Id = x.Id,
            Name = x.Name,
        }).ToListAsync();
    }
}
