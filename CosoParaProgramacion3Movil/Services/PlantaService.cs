using CosoParaProgramacion3Movil.Models;
using System.Net.Http.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace CosoParaProgramacion3Movil.Services;

//Los SERVICES tienen todos los metodos de los MODELOS. Mas o menos asi.

public class PlantaService //Que es mejor? tener cajas negras con nombres muy distintos para diferenciarlos bien? o que sean genericos para que sean copiables y facilmente reusables?
{
    private readonly HttpClient _http;

    public PlantaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Plantas>> GetPlantas()
    {
        var response = await _http.GetFromJsonAsync<List<Plantas>>("api/Plantas/listar");
        return response ?? new List<Plantas>();
    }

    public async Task<Plantas?> GetPlanta(int id)
    {
        var response = await _http.GetFromJsonAsync<Plantas>($"api/Plantas/buscar/{id}");
        return response;
    }

    public async Task<bool> CreatePlanta(Plantas planta)
    {
        var response = await _http.PostAsJsonAsync("api/Plantas/guardar", planta);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdatePlanta(int id, Plantas planta)
    {
        var response = await _http.PutAsJsonAsync($"api/Plantas/editar/{id}", planta);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePlanta(int id)
    {
        var response = await _http.DeleteAsync($"api/Plantas/eliminar/{id}");
        return response.IsSuccessStatusCode;
    }

}
