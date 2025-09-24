namespace CosoParaProgramacion3Movil.Models;

public static class PlantaFactory
{
    public static Planta CrearPlantaGenerica()
    {
        return new Planta
        {
            Imagen = "img/generico.jpg",
            Informacion = new DescripcionPlanta
            {
                NombreCientifico = "",
                NombreVulgar = "",
                Descripcion = "",
                RegionNatural = "",
                Familia = "",
                AlturaMaxima = 0,
                EpocaDeFloracion = ""
            },
            Rigo = new RiegoPlanta
            {
                Frecuencia = "",
                CantidadEnMl = "",
                Metodo = "",
                RiegoRecomendaciones = ""
            },
            Toxicidad = new ToxicidadPlanta
            {
                AnimalesAfectados = new List<string>(),
                SustanciaToxica = "",
                SintomasDeIntoxicacion = "",
                Tratamiento = "",
                FuenteDeInformacionDeTratamiento = ""
            },
            Cuidados = new CuidadosPlanta
            {
                TipoDeLuz = "",
                HumedadIdealMinima = 0,
                HumedadIdealMaxima = 0,
                TemperaturaIdealMinima = 0,
                TemperaturaIdealMaxima = 0,
                Fertilizante = "",
                Poda = "",
                RequerimientosDeTrasplante = ""
            },
            Suelo = new SueloPlanta
            {
                TipoDeSuelo = "",
                pH = 0.0,
                VelocidadDeDrenadoEnMmHora = 0.0,
                MateriaVegetalEnPorcentaje = 0.0,
                SueloRecomendaciones = ""
            },
            Fertilizante = new FertilizantePlanta
            {
                TipoDeFertilizante = "",
                Forma = "",
                Composicion = "",
                Aplicacion = "",
                Advertencias = "",
                MateriaOrganicaDeFertilizante = new MateriaOrganica
                {
                    PorcentajeTotal = 0.0,
                    PorcentajeCompost = 0.0,
                    PorcentajeHumus = 0.0,
                    PorcentajeEstiercol = 0.0,
                    PorcentajeResiduosVegetales = 0.0,
                    PorcentajeLombrioCompuesto = 0.0,
                    FuenteDeInformacionDeCompuesto = "",
                    EfectoSobrePlanta = "",
                    MateriaOrganicaRecomendaciones = ""
                }
            },
            Poda = new PodaPlanta
            {
                TipoDePoda = "",
                EpocaDePoda = "",
                HerramientasDePoda = "",
                RecomendacionesDePoda = ""
            }
        };
    }

    // Método adicional si quisieras crear una planta personalizada
    public static Planta CrearPlantaConNombre(string nombreCientifico)
    {
        var planta = CrearPlantaGenerica();
        planta.Informacion.NombreCientifico = nombreCientifico;
        return planta;
    }
}
