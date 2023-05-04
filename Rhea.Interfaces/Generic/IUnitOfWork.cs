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

        public IEventTypeRepository EventType { get; set; }  
        public IFurnitureStatusRepository Furniture { get; set; }
        public IReservationStatusRepository ReservationStatus { get; set; }
        public IUserTypeRepository UserType { get; set; }
    }
}
