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
    }
}