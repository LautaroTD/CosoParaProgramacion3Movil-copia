using CosoParaProgramacion3Movil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public class AuthService
{
    private readonly HttpClient _http;
    private readonly CookieContainer _cookieContainer = new();
    public AuthService()
    {
        var handler = new HttpClientHandler
        {
            CookieContainer = _cookieContainer,
            UseCookies = true,
            AllowAutoRedirect = false
        };

        _http = new HttpClient(handler)
        {
            BaseAddress = new Uri("http://192.168.1.100:5005/") 
        };
    }

    public async Task<bool> LoginAsync(string nombre, string contrasena)
    {//este metodo esta fallando me parece, hace try catchs hasta el orto
        LoginRequest login = new LoginRequest(); //ACORDATE QUE ASI SE DECLARAN LAS VARIABLES, QUE GANAS DE INVENTARSE FORMAS DE JODER

        login.Name = nombre;
        login.Password = contrasena;

        HttpContent content;

        try
        {
            var json = JsonSerializer.Serialize(login);
            content = new StringContent(json, Encoding.UTF8, "application/json");
        } 
        catch (Exception ex)
        {
            Console.WriteLine($"Erroy:");
            Console.WriteLine($"Erroy: {ex.Message}");
            return false;
        }

        HttpResponseMessage response;

        Console.WriteLine("A punto de usar PostAsync");

        try
        {
            response = await _http.PostAsync("/api/Usuario/login", content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erroi");
            Console.WriteLine(ex.Message);
            return false;
        }

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            // Si querés obtener el token:
            var result = JsonSerializer.Deserialize<LoginResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine($"Token recibido: {result?.Token}");

            return true;
        }
        else if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            Console.WriteLine("Credenciales inválidas.");
            return false;
        }
        else
        {
            Console.WriteLine($"Error inesperado: {(int)response.StatusCode} - {response.ReasonPhrase}");
            return false;
        }

        Console.WriteLine("Termino metodo LoginAsync");

        return true;
    }

    public async Task<bool> EstaAutenticadoAsync()
    {//si cambio este metodo y el metodo de la api, puedo tolerar roles
        
        var response = await _http.GetAsync("api/Usuario/estado");

        if (response is null)
            return false;

        return true;
    }

    public async Task LogoutAsync()
    {
        var token = await SecureStorage.GetAsync("jwt_token");

        if (!string.IsNullOrWhiteSpace(token))
        {
            // El token existe
            SecureStorage.Default.Remove("jwt_token");
        }

    }

}
