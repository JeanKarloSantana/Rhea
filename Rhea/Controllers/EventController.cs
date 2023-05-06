using Microsoft.AspNetCore.Mvc;
using Rhea.Entities.DTO;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;

namespace Rhea.Controllers
{
    public class EventController : Controller
    { 
        private readonly IEventManager _eventManager;

        public EventController(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent(PostEventDto eventDto)
        {
            try
            {  
                ResponseDTO<string> response = await _eventManager.CreateReservation(eventDto);
                return StatusCode(response.StatusCode, response.Errors.Count > 0 ? response.Errors : response.Message);
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
                return StatusCode(response.StatusCode, response.Succeed ? response.Errors : response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
