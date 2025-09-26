using System.Net;
using System.Net.Http.Json;

using CosoParaProgramacion3Movil.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
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
            BaseAddress = new Uri("http://192.168.1.101:5005/") // reemplazá por tu puerto real
        };
    }

    public async Task<bool> LoginAsync(string nombre, string contrasena)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", new
        {
            nombre,
            contrasena
        });

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EstaAutenticadoAsync()
    {
        var response = await _http.GetAsync("api/auth/estado");

        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<EstadoSesionResponse>();
        return result?.Autenticado ?? false;
    }

    public async Task LogoutAsync()
    {
        await _http.PostAsync("api/auth/logout", null);
    }

    private class EstadoSesionResponse
    {
        public bool Autenticado { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Id { get; set; }
    }
}
