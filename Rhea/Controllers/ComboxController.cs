using Microsoft.AspNetCore.Mvc;
using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;
using System;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Rhea.Controllers
{
    public class ComboxController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public ComboxController(IUserManager eventManager, IUnitOfWork unitOfWork)
        {
            _userManager = eventManager;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("FillDBCombox")]
        public async Task<IActionResult> CreateEvent()
        {
            try
            {
                var eventList = new List<string> { "CREATED", "SOLD_OUT", "PENDING", "ON_GOING" };
                eventList.ForEach(status =>
                {
                    var eventStat = new EventStatus { Name = status };
                    _unitOfWork.EventStatus.Add(eventStat);
                });
                
                var furnitureStatuses = new List<string> { "AVAILABLE", "MAINTENANCE", "UNAVAILABLE" };
                furnitureStatuses.ForEach(status =>
                {
                    var furnitureStat = new FurnitureStatus { Name = status };
                    _unitOfWork.FurnitureStatus.Add(furnitureStat);
                });

                var reservationStatuses = new List<string> { "RESERVED", "CANCELLED", "POSTPONED" };
                reservationStatuses.ForEach(status =>
                {
                    var reservationStat = new ReservationStatus { Name = status };
                    _unitOfWork.ReservationStatus.Add(reservationStat);
                });
               
                var userStatuses = new List<string> { "AVAILABLE", "DUE", "CANCELED" };
                userStatuses.ForEach(status =>
                {
                    var userStat = new UserStatus { Name = status };
                    _unitOfWork.UserStatus.Add(userStat);
                });

                var userList = new List<string> { "PERSON", "COMPANY" };
                userList.ForEach(type =>
                {
                    var userType = new UserType { Name = type };
                    _unitOfWork.UserType.Add(userType);
                });

                var EventList = new List<string> { "CONFERECE", "BIRTHDAY", "HOUSE PARTY", "COURSES", "CONVENTION" };
                EventList.ForEach(type =>
                {
                    var eventType = new EventType { Name = type };
                    _unitOfWork.EventType.Add(eventType);
                });

                _unitOfWork.Complete();
                return StatusCode(200, "OK");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
