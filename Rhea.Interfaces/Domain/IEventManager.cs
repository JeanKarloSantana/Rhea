using Rhea.Entities.DTO;
using Rhea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Interfaces.Domain
{
    public interface IEventManager
    {
        Task<ResponseDTO<string>> CreateReservation(PostEventDto crtReservationDto);
        Task<ResponseDTO<string>> UpdateReservationByDto(ReservationUpdateDTO reservationDto);
    }
}
