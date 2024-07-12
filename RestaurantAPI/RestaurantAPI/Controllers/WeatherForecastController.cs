using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
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
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int results, [FromBody] TemperatureRequest request)
        {
            if(!(results > 0 && request.MaxTemp > request.MinTemp))
            {
                return StatusCode(400);
            }
            var result = _service.Get(results, request.MinTemp, request.MaxTemp);
            return StatusCode(200, result);
        }
    }
}
