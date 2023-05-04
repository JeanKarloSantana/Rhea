using Rhea.DAL.SQL;
using Rhea.Entities;
using Rhea.Interfaces.Generic;
using Rhea.Interfaces.Repository;
using Rhea.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Persistance.Generic
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RheaDbContext _dbContext;

        public UnitOfWork(RheaDbContext dbContext) 
        {
            _dbContext = dbContext;

            EventType = new EvenTypeRepository(_dbContext);

        }

        public int Complete() => _dbContext.SaveChanges();
        public void Dispose() => _dbContext.Dispose();
      
        public IEventTypeRepository EventType { get; set; }
        public IFurnitureStatusRepository Furniture { get; set; }
        public IReservationStatusRepository ReservationStatus { get; set; }
        public IUserTypeRepository UserType { get; set; }
    }
}
