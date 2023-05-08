using Microsoft.AspNetCore.Mvc;
using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;

namespace Rhea.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventManager _eventManager;
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IEventManager eventManager, IUnitOfWork unitOfWork)
        {
            _eventManager = eventManager;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent(PostEventDto eventDto)
        {
            try
            {  
                ResponseDTO<string> response = await _eventManager.CreateReservation(eventDto);
                return StatusCode(response.StatusCode, response.Succeed ? response.Message : response.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost("UpdateEvent")]
        public async Task<IActionResult> CreateEvent(ReservationUpdateDTO reservationDto)
        {
            try
            {
                ResponseDTO<string> response = await _eventManager.UpdateReservationByDto(reservationDto);
                return StatusCode(response.StatusCode, response.Succeed ? response.Message : response.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("GetReservation")]
        public IActionResult GetEvent(int idUser)
        {
            try
            {
                return StatusCode(200, _unitOfWork.Reservation.GetReservationById(idUser));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
