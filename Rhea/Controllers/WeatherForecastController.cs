using Microsoft.AspNetCore.Mvc;
using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Entities.Enums;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;

namespace Rhea.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventManager _eventManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork unitOfWork, IEventManager eventManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _eventManager = eventManager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetEventType")]
        public async Task<IActionResult> GetRepo()
        {
            return StatusCode(200, await _unitOfWork.EventType.GetAllAsync());
        }

        [HttpPost("PostEventType")]
        public async Task<IActionResult> PostRepo()
        {
            /*var userType = new UserType();
            userType.Name = "Company";
            userType.DateCreated = DateTime.Now;
            _unitOfWork.UserType.Add(userType);

            var userType2 = new UserType();
            userType2.Name = "Person";
            userType2.DateCreated = DateTime.Now;
            _unitOfWork.UserType.Add(userType2);

            var userStatus = new UserStatus();
            userStatus.Name = "AVAILABLE";
            userStatus.DateCreated = DateTime.Now;
            _unitOfWork.UserStatus.Add(userStatus);

            var eventType = new EventType();
            eventType.Name = "CONFERENCE";
            eventType.DateCreated = DateTime.Now;
            _unitOfWork.EventType.Add(eventType);

            var eventStatus = new EventStatus();
            eventStatus.Name = "UPCOMING";
            eventStatus.DateCreated = DateTime.Now;
            _unitOfWork.EventStatus.Add(eventStatus);*/

            /*var user = new User();
            user.Email = "NewTest@outlook.com";
            user.DateCreated = DateTime.Now;
            user.IdUserType = 1;
            user.IdUserStatus = 1;
            _unitOfWork.User.Add(user);
            _unitOfWork.Complete();
            */
            /*var company = new Company();
            company.Id = 5;
            company.Name = "Lr Comercial";
            company.NormalizedName = "LR COMERCIAL";
            _unitOfWork.Company.Add(company);

            var person = new Person();
            person.Id = 7;
            person.FirstName = "Dave";
            person.NormalizedFirstName = "DAVE";
            person.Lastname = "Stann";
            person.NormalizedLastname = "STANN";
            person.DateOfBirth = new DateTime(2015, 5, 29);
            _unitOfWork.Person.Add(person);

            _unitOfWork.Complete();*/

            /*var eventStatus = new EventStatus();
            eventStatus.Name = "CREATED";
            _unitOfWork.EventStatus.Add(eventStatus);
            _unitOfWork.Complete();*/

            /*var eventStatus2 = new EventStatus();
            eventStatus2.Name = "SOLD OUT";
            _unitOfWork.EventStatus.Add(eventStatus2);
            _unitOfWork.Complete();*/

            /*var eventStatus3 = new EventStatus();
            eventStatus3.Name = "PENDING";
            _unitOfWork.EventStatus.Add(eventStatus3);
            _unitOfWork.Complete();*/

            /*var eventStatus4 = new EventStatus();
            eventStatus.Name = "ONGOING";
            _unitOfWork.EventStatus.Add(eventStatus);
            _unitOfWork.Complete();*/

            /*var FurnitureStatus = new FurnitureStatus
            {
                Name = "AVAILABLE"
            };
            _unitOfWork.FurnitureStatus.Add(FurnitureStatus);
            _unitOfWork.Complete();

            var FurnitureStatus2 = new FurnitureStatus
            {
                Name = "MAINTENANCE"
            };
            _unitOfWork.FurnitureStatus.Add(FurnitureStatus2);
            _unitOfWork.Complete();

            var FurnitureStatus3 = new FurnitureStatus
            {
                Name = "UNAVAILABLE"
            };
            _unitOfWork.FurnitureStatus.Add(FurnitureStatus3);
            _unitOfWork.Complete();*/
            /*
            var userStatus = new UserStatus
            {
                Name = "AVAILABLE"
            };
            _unitOfWork.UserStatus.Add(userStatus);

            var userStatus2 = new UserStatus
            {
                Name = "DUE"
            };
            _unitOfWork.UserStatus.Add(userStatus2);

            var userStatus3 = new UserStatus
            {
                Name = "CANCELED"
            };
            _unitOfWork.UserStatus.Add(userStatus3);

            var reservationStatus = new ReservationStatus
            {
                Name = "AVAILABLE"
            };
            _unitOfWork.ReservationStatus.Add(reservationStatus);*/


            /*var furnitureList = new List<string>
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
            };

            foreach (var item in furnitureList)
            {
                var furniture = new Furniture();
                furniture.Name = item;
                furniture.IdFurnitureStatus = 1;
                _unitOfWork.Furniture.Add(furniture);
            }
            */
            var createEv = new PostEventDto
            {
                IdUser = 1,
                IdEventType = 1,
                Name = "Rock N Roll",
                StartTime = new DateTime(2023, 5, 3, 7, 29, 0),
                EndTime = new DateTime(2023, 5, 3, 19, 0, 0),
                FurnitureIds = new List<int>{ 1, 3, 7, 5, 6, 8 }
             };
            try
            {
                var response = await _eventManager.CreateReservation(createEv);
                return StatusCode(response.StatusCode, response.Errors.Count > 0 ? response.Errors : response.Data);

            } catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
            
            
        }
    }
}