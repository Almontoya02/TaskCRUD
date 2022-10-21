using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase //herencia
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if(ListWeatherForecast == null || !ListWeatherForecast.Any()){ //!ListWeatherForecast.Any() Si no tiene ningun registro
            
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    //se puede acceder por medio de multiples rutas
    //[Route("get/")]
    [Route("get/getweatherforecast")]
    [Route("[action]")] //permite generar un endpoint con el nombre del metodo, en este caso Get
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Retornando la lista de weatherforecast");//inmforma en consola 
        return ListWeatherForecast;
    }

    [HttpPost]
    [Route("post/")]
    public IActionResult Post(WeatherForecast weatherForecast){
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("delete/{index}")]//dentro de la url viene un index
    [Route("delete/")]
    public IActionResult Delete(int index){
        if (ListWeatherForecast.Count < index || index < 0)
        {
            return BadRequest("The given ID is out of bounds.");
        }
        ListWeatherForecast.RemoveAt(index);
        return Ok("Forecast was successfully removed.");
        
    }
}
