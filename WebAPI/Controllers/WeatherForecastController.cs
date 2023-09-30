using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource;

namespace WebAPI.Controllers;

[ApiController]
[Route( "[controller]" )]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger< WeatherForecastController > _logger;
    private ApiDbContext _dbContext;
    public WeatherForecastController( ApiDbContext dbContext, ILogger< WeatherForecastController > logger )
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet( Name = "GetWeatherForecast" )]
    public async Task<IActionResult> Get()
    {
        // mock for tests
        //var cities = await _dbContext.Cities.ToListAsync();

        return Ok(Enumerable.Range( 1, 5 ).Select( index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime( DateTime.Now.AddDays( index ) ),
                TemperatureC = Random.Shared.Next( -20, 55 ),
                Summary = Summaries[ Random.Shared.Next( Summaries.Length ) ]
            } )
            .ToArray());
    }
}