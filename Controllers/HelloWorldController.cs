using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase //herencia
{
    private readonly ILogger<HelloWorldController> _logger;
    IHelloWorldService helloWorldService;
    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger){
        _logger=logger;
        helloWorldService=helloWorld;
    }
    public IActionResult Get(){
         _logger.LogInformation("Retornando la lista de HelloWorld");//inmforma en consola
        return Ok(helloWorldService.GetHelloWorld());
    }
}