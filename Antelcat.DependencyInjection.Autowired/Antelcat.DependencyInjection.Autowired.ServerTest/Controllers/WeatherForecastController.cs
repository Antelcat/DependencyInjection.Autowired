using System.Diagnostics;
using Antelcat.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Antelcat.DependencyInjection.Autowired.ServerTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    [Autowired]
    protected ITest? Test;
    
    [Autowired]
    protected ILogger<WeatherForecastController>? Logger;

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        if (Logger == null || Test == null || !Test.FullFilled()) throw new NullReferenceException("Logger not been autowired");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}