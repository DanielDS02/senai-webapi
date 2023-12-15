using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
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
        public List<WeatherForecast> ListaDeTemperaturas { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            ListaDeTemperaturas = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }

        [HttpGet(Name = "GetWeatherForecast")]

        public IEnumerable<WeatherForecast> Get()
        {
            return ListaDeTemperaturas.ToArray();
        }

        [HttpPost]
        public Task<bool> AdicionarWeather(WeatherForecast weatherForecast)
        {
            ListaDeTemperaturas.Add(weatherForecast);
            return Task.FromResult(true);
        }

    }
}
