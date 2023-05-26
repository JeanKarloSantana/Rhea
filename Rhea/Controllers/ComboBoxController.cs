using Microsoft.AspNetCore.Mvc;
using Rhea.Entities;
using Rhea.Entities.ComboBox;
using Rhea.Entities.DTO;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;
using System;
using System.Reflection;

namespace Rhea.Controllers
{
    public class ComboBoxController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public ComboBoxController(IUserManager eventManager, IUnitOfWork unitOfWork)
        {
            _userManager = eventManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("EventStatuses")]
        public async Task<IActionResult> GetEventStatusesComboBoxAsync()
        {
            try
            {
                return StatusCode(200, await _unitOfWork.EventStatus.GetEventStatusComboBox());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("FillComboBoxTables")]
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

                var EventList = new List<string> { "CONFERENCE", "BIRTHDAY", "HOUSE PARTY", "COURSES", "CONVENTION" };
                EventList.ForEach(type =>
                {
                    var eventType = new EventType { Name = type };
                    _unitOfWork.EventType.Add(eventType);
                });

                var furnitureList = new List<string>
                {
                    "CONFERENCE CHAIR A1",
                    "CONFERENCE CHAIR A2",
                    "CONFERENCE CHAIR A3",
                    "CONFERENCE CHAIR A4",
                    "CONFERENCE CHAIR A5",
                    "CONFERENCE CHAIR A6",
                    "CONFERENCE TABLE A2",
                    "CONFERENCE TABLE A3",
                    "CONFERENCE TABLE A4",
                    "CONFERENCE TABLE A5",
                    "CONFERENCE TABLE A6",
                    "BIRTHDAY CHAIR A1",
                    "BIRTHDAY CHAIR A2",
                    "BIRTHDAY CHAIR A3",
                    "BIRTHDAY CHAIR A4",
                    "BIRTHDAY CHAIR A5",
                    "BIRTHDAY CHAIR A6",
                    "BIRTHDAY TABLE A1",
                    "BIRTHDAY TABLE A2",
                    "BIRTHDAY TABLE A3",
                    "BIRTHDAY TABLE A4",
                    "BIRTHDAY TABLE A5",
                    "BIRTHDAY TABLE A6",
                    "PROJECTOR A1",
                    "PROJECTOR A2",
                    "PROJECTOR A3",
                    "PROJECTOR A4"
                };

                foreach (var item in furnitureList)
                {
                    var furniture = new Furniture();
                    furniture.Name = item;
                    furniture.IdFurnitureStatus = 1;
                    _unitOfWork.Furniture.Add(furniture);
                }

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
