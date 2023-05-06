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
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Reservation AddReservationByEventDTO(PostEventDto eventDto, int eventId);
        Task<List<Reservation>> GetReservationByStartTimeDate(DateTime startTime);
        void UpdateReservationByDto(int idReservation, ReservationUpdateDTO reservationDto);
        int GetReservationIdByUserId(int userId);
        int GetReservationEventId(int eventId);
    }
}
