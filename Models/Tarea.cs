using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Tarea
{
    public Guid TareaId {get;set;}
    public Guid CategoriaId {get;set;}
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}

    /**
    Permite a Entity Framework crear un proxy 
    alrededor de la propiedad virtual
    para que la propiedad pueda admitir la carga diferida 
    y un seguimiento de cambios más eficaz.
    */  
    public virtual Categoria Categoria {get;set;}
    public string Resumen {get;set;}
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}