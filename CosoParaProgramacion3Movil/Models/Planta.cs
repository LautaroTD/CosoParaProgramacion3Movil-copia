
namespace CosoParaProgramacion3Movil.Models;

public class Planta
{ //es posible que esto no este completo... y tambien es posible que sea demasiado
    //Ahora solo queda hacer el CRUD de esto y mamita sera un infierno.
    public int Id { get; set; }
    public string Imagen { get; set; }
    public DescripcionPlanta Informacion { get; set; }
    public RiegoPlanta Rigo { get; set; }
    public ToxicidadPlanta Toxicidad{ get; set; }
    public CuidadosPlanta Cuidados { get; set; }
    public SueloPlanta Suelo { get; set; }
    public FertilizantePlanta Fertilizante {  get; set; }
    public PodaPlanta Poda {  get; set; }
}
public class PodaPlanta
{
    public string TipoDePoda {  get; set; }
    public string EpocaDePoda { get; set; }
    public string HerramientasDePoda { get; set; }
    public string RecomendacionesDePoda { get; set; }
}

public class FertilizantePlanta
{
    public string TipoDeFertilizante {  get; set; }
    public string Forma { get; set; }
    public string Composicion { get; set; }
    public MateriaOrganica MateriaOrganicaDeFertilizante {get;set;} 
    public string Aplicacion { get; set; }
    public string Advertencias { get; set; }

}

public class MateriaOrganica
{
    public double PorcentajeTotal { get; set; }
    public double PorcentajeCompost { get; set; }
    public double PorcentajeHumus { get; set; }
    public double PorcentajeEstiercol { get; set; }
    public double PorcentajeResiduosVegetales { get; set; }
    public double PorcentajeLombrioCompuesto { get; set; }
    public string FuenteDeInformacionDeCompuesto { get; set; }
    public string EfectoSobrePlanta { get; set; }
    public string MateriaOrganicaRecomendaciones { get; set; }


}

public class SueloPlanta
{
    public string TipoDeSuelo { get; set; }
    public double pH { get; set; }
    public double VelocidadDeDrenadoEnMmHora { get; set; }
    public double MateriaVegetalEnPorcentaje { get; set; }
    public string SueloRecomendaciones { get; set; }

}
public class CuidadosPlanta
{
    public string TipoDeLuz { get; set; }
    public int HumedadIdealMinima { get; set; }
    public int HumedadIdealMaxima { get; set; }
    public int TemperaturaIdealMinima { get; set; }
    public int TemperaturaIdealMaxima { get; set; }
    public string Fertilizante { get; set; }
    public string Poda { get; set; }
    public string RequerimientosDeTrasplante { get; set; }
}

public class ToxicidadPlanta
{
    public List<string> AnimalesAfectados { get;set; }
    public string SustanciaToxica { get; set; }
    public string SintomasDeIntoxicacion { get; set; }
    public string Tratamiento { get; set; } // Ej: "Enjuagar boca, contactar veterinario"
    public string FuenteDeInformacionDeTratamiento { get; set; } // Ej: "ASPCA", "Universidad de Cornell"

}


public class DescripcionPlanta
{
    public string NombreCientifico { get; set; }
    public string NombreVulgar { get; set; }
    public string Descripcion { get; set; }
    public string RegionNatural { get; set; }
    public string Familia { get; set; }
    public int AlturaMaxima { get; set; }
    public string EpocaDeFloracion { get; set; }
}

public class RiegoPlanta
{
    public string Frecuencia { get; set; }
    public string CantidadEnMl{ get; set; }
    public string Metodo { get; set; }
    public string RiegoRecomendaciones { get; set; }
}

