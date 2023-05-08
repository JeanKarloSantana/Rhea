using Microsoft.EntityFrameworkCore;
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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Persistance.Repository
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public RheaDbContext Context { get { return context; } }

        public ReservationRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }

        public Reservation AddReservationByEventDTO(PostEventDto eventDto, int eventId)
        {
            var reservation = new Reservation
            {
                IdUser = eventDto.IdUser,
                IdEvent = eventId,
                IdReservationStatus = (int)ReservationStatusEnum.RESERVED,
                StartTime = eventDto.StartTime,
                EndTime = eventDto.EndTime
            };

            Add(reservation);
            
            context.SaveChanges();
            
            return reservation;
        }

        public int GetReservationIdByUserId(int userId) => context.Reservations
            .Where(x => x.IdUser == userId)
            .Select(x => x.Id)
            .FirstOrDefault();
        

        public void UpdateReservationByDto(int idReservation, ReservationUpdateDTO reservationDto)
        {
            var reservation = Get(idReservation);
            reservation.IdReservationStatus = reservationDto.IdReservationStatus;
            reservation.StartTime = reservationDto.StartTime;
            reservation.EndTime = reservationDto.EndTime;
        }

        public async Task<List<Reservation>> GetReservationByStartTimeDate(DateTime startTime) => await Context.Reservations
            .Where(x => x.StartTime.Date == startTime.Date)
            .ToListAsync();

        public int GetReservationEventId(int eventId) => context.Reservations
            .Where(x => x.Id == eventId)
            .Select(x => x.IdEvent)
            .FirstOrDefault();

        public IEnumerable<Reservation> GetReservationById(int id) 
        {
           return context.Reservations.Where(x => x.IdUser == id).ToList();
        }
    }
}
