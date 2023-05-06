using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Interfaces.Repository
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Event CreateEventByDTO(PostEventDto eventDto);
        void UpdateEventByDTO(int eventId, ReservationUpdateDTO reservationDto);
    }
}
