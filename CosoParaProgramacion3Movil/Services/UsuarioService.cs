using System.Net.Http.Json;
using CosoParaProgramacion3Movil.Models;

namespace CosoParaProgramacion3Movil.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        // GET: api/Usuarios/listar
        public async Task<List<Usuario>> GetUsuarios()
        {
            var response = await _http.GetFromJsonAsync<List<Usuario>>("api/Usuarios/listar");
            return response ?? new List<Usuario>();
        }

        // GET: api/Usuarios/buscar/{id}
        public async Task<Usuario?> GetUsuario(int id)
        {
            var response = await _http.GetFromJsonAsync<Usuario>($"api/Usuarios/buscar/{id}");
            return response;
        }

        // POST: api/Usuarios/crear
        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            var response = await _http.PostAsJsonAsync("api/Usuarios/crear", usuario);
            return response.IsSuccessStatusCode;
        }

        // PUT: api/Usuarios/editar/{id}
        public async Task<bool> EditarUsuario(int id, Usuario usuario)
        {
            var response = await _http.PutAsJsonAsync($"api/Usuarios/editar/{id}", usuario);
            return response.IsSuccessStatusCode;
        }

        // DELETE: api/Usuarios/eliminar/{id}
        public async Task<bool> EliminarUsuario(int id)
        {
            var response = await _http.DeleteAsync($"api/Usuarios/eliminar/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
