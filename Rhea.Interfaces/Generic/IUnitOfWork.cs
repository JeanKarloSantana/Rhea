using Rhea.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Interfaces.Generic
{
    public interface IUnitOfWork
    {
        int Complete();
        void Dispose();

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
