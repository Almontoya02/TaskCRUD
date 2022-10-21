using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class CategoriaController: ControllerBase{

    ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService service){

        categoriaService=service;

    }

    [HttpGet]
    public ActionResult Get(){
        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public ActionResult Post([FromBody] Categoria categoria){

        categoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(Guid id,[FromBody] Categoria categoria){

        categoriaService.Update(id,categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id){

        categoriaService.Delete(id);
        return Ok();
    }

}