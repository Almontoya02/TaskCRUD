using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class TareaController: ControllerBase{

    ITareaService tareaService;

    public TareaController(ITareaService service){

        tareaService=service;

    }

    [HttpGet]
    public ActionResult Get(){
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public ActionResult Post([FromBody] Tarea tarea){

        tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(Guid id,[FromBody] Tarea tarea){

        tareaService.Update(id,tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id){

        tareaService.Delete(id);
        return Ok();
    }

}