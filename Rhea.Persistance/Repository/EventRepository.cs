using Microsoft.Extensions.Logging;
using Rhea.DAL.SQL;
using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Entities.Enums;
using Rhea.Interfaces.Generic;
using Rhea.Interfaces.Repository;
using Rhea.Persistance.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Persistance.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public RheaDbContext Context { get { return context; } }

        public EventRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }

        public Event CreateEventByDTO(PostEventDto eventDto)
        {
            var @event = new Event()
            {
                IdEventType = eventDto.IdEventType,
                IdEventStatus = (int)EventStatusEnum.CREATED,
                Name = eventDto.Name
            };

            Add(@event);
            Context.SaveChanges();
            return @event;
        }

        public void UpdateEventByDTO(int eventId, ReservationUpdateDTO reservationDto) 
        {
            var @event = Get(eventId);

            @event.IdEventType = reservationDto.IdEventType;
            @event.IdEventStatus = reservationDto.IdEventStatus;
            @event.Name = reservationDto.EventName;
        }
    }
}
