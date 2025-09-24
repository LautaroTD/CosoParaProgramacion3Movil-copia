using CosoParaProgramacion3Movil.Models;

namespace CosoParaProgramacion3Movil.Services;

//Los SERVICES tienen todos los metodos de los MODELOS. Mas o menos asi.

public class PlantaService //Que es mejor? tener cajas negras con nombres muy distintos para diferenciarlos bien? o que sean genericos para que sean copiables y facilmente reusables?
{
    public readonly List<Planta> lista; //esto simula el _context de una coneccion a una base de datos

    #region Constructor
    public PlantaService()
    {
        lista = new List<Planta>(); //no pongas "List<T>", pone solo el nombre de tu public readonly, de lo contrario te creara una nueva lista.

        for (int i = 0; i < 10; i++)
        {
            var planta = PlantaFactory.CrearPlantaGenerica();
            planta.Id = i + 1; // Puedes asignar un ID único
            lista.Add(planta);
        }

        var planta1 = PlantaFactory.CrearPlantaConNombre("PlantaMuyBonita");
        planta1.Id = lista.Max(p => p.Id) + 1;
        planta1.Imagen = "img/plantaimages.jpg";    
        lista.Add(planta1);
    }
    #endregion

    #region Metodos
    public List<Planta> GetPlanta()
    {
        return lista;
    }

    public Planta GetPlanta(int id)
    {
        return lista.FirstOrDefault(p => p.Id == id);
    }

    public void AddPlanta(Planta planta)
    {
        if (lista.Any())
        {
            planta.Id = lista.Max(p => p.Id) + 1;
        }
        else
        {
            planta.Id = 1;
        } 
        lista.Add(planta);
    }

    public void UpdatePlanta(Planta planta)
    {
        var plantaExistente = lista.FirstOrDefault(u => u.Id == planta.Id);
        if (plantaExistente != null)
        {
            plantaExistente.Informacion.NombreCientifico = planta.Informacion.NombreCientifico;
            plantaExistente.Informacion.NombreVulgar = planta.Informacion.NombreVulgar;
        }
    }

    public void DeletePlanta(int id)
    {
        var planta = lista.FirstOrDefault(u => u.Id == id);
        
        if (planta != null)
        {
            lista.Remove(planta);
        }
    }
    #endregion
}
