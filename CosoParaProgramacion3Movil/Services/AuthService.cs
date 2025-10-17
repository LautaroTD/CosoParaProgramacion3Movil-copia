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
            BaseAddress = new Uri("http://10.173.107.218:5005/") // reemplazá por tu puerto real
        };
    }

    public async Task<bool> LoginAsync(string nombre, string contrasena)
    {//este metodo esta fallando me parece, hace try catchs hasta el orto
        LoginRequest login = new LoginRequest(); //ACORDATE QUE ASI SE DECLARAN LAS VARIABLES, QUE GANAS DE INVENTARSE FORMAS DE JODER

        login.Name = nombre;
        login.Password = contrasena;

        Console.WriteLine($"Entro al metodo LoginAsync()");

        HttpContent content;

        try
        {
            var json = JsonSerializer.Serialize(login);
            content = new StringContent(json, Encoding.UTF8, "application/json");
        } catch (Exception ex)
        {
            Console.WriteLine($"Erroy:");
            Console.WriteLine($"Erroy: {ex.Message}");
            return false;
        }

        HttpResponseMessage response;

        try
        {
            response = await _http.PostAsync("http://10.0.2.2:5005/api/Usuario/login", content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erroi");
            Console.WriteLine(ex.Message);
            return false;
        }

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

        await Shell.Current.GoToAsync("//Home"); //esto puede estar mal
    }

}
