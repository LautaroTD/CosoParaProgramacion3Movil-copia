
namespace CosoParaProgramacion3Movil.Models;

public class Plantas
{ //es posible que esto no este completo... y tambien es posible que sea demasiado
  //Ahora solo queda hacer el CRUD de esto y mamita sera un infierno.
  //cagate, porque cambio de vuelta y ahora tengo que hacer un CRUD de esto en el servicio
    public int Id { get; set; }

    public string NombreCientifico { get; set; } = string.Empty;

    public string NombreVulgar { get; set; } = string.Empty;

    public string Autor { get; set; } = string.Empty;

    public string EpocaFloracion { get; set; } = string.Empty;

    public int? AlturaMaxima { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public string Imagen {get;set; } = string.Empty;
}