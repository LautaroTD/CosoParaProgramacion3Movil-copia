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
        HttpResponseMessage response;
        try
        {
            response = await _http.GetAsync("api/Plantas/listar"); //http://localhost:5005/api/Plantas/listar // esto tambien pero es mas lento (celular): http://10.13.238.218:5005/api/Plantas/listar // casa: http://192.168.1.101:5005/api/Plantas/listar
            Console.WriteLine($"funciomo1"); //al usar un dispositivo emulado, usa este "http://10.0.2.2:5005/api/Plantas/listar"
        }
        catch (Exception ex)
        {
            Console.WriteLine($"errorr en la peticion");
            Console.Write(ex);
            return new List<Plantas>();
        }

        response.EnsureSuccessStatusCode();

        var respuesta2 = new List<Plantas>();

        try
        {
            //SI ESTO NO ANDA PROBA CAMBIAR ReadFromJsonAsync por ReadFromJsonAsAsyncEnumerable
            respuesta2 = await response.Content.ReadFromJsonAsync<List<Plantas>>();
            Console.WriteLine($"funciomo2");
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"errorr en la traduccion");
            Console.Write(ex);
            return new List<Plantas>();
        }

        Console.WriteLine($"funciomo3");

        return respuesta2;
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
