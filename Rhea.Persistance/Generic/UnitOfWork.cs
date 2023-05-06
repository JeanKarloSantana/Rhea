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

            EventStatus = new EventStatusRepository(_dbContext);
            EventType = new EventTypeRepository(_dbContext);
            FurnitureStatus = new FurnitureStatusRepository(_dbContext);
            ReservationStatus = new ReservationStatusRepository(_dbContext);
            UserType = new UserTypeRepository(_dbContext);
            UserStatus = new UserStatusRepository(_dbContext);
            User = new UserRepository(_dbContext);
            Person = new PersonRepository(_dbContext);
            Company = new CompanyRepository(_dbContext);
            Reservation = new ReservationRepository(_dbContext);
            Event = new EventRepository(_dbContext);
            Furniture = new FurnitureRepository(_dbContext);
            FurnitureDetail = new FurnitureDetailRepository(_dbContext);
        }

        public int Complete() => _dbContext.SaveChanges();
        public void Dispose() => _dbContext.Dispose();

        public IEventStatusRepository EventStatus { get; set; }
        public IEventTypeRepository EventType { get; set; }
        public IFurnitureStatusRepository FurnitureStatus { get; set; }
        public IReservationStatusRepository ReservationStatus { get; set; }
        public IUserTypeRepository UserType { get; set; }
        public IUserStatusRepository UserStatus { get; set; }
        public IUserRepository User { get; set; }
        public IPersonRepository Person { get; set; }
        public ICompanyRepository Company { get; set; }
        public IReservationRepository Reservation { get; set; }
        public IFurnitureDetailRepository FurnitureDetail { get; set; }
        public IFurnitureRepository Furniture { get; set; }
        public IEventRepository Event { get; set; }

    }
}
