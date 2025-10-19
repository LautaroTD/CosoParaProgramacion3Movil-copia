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
            var response = await _http.GetFromJsonAsync<List<Usuario>>("api/Usuario/listar");
            return response ?? new List<Usuario>();
        }

        // GET: api/Usuarios/buscar/{id}
        public async Task<Usuario?> GetUsuario(int id)
        {
            Console.WriteLine("Llego hasta GetUsuario en UsuarioService");
            
            var response = await _http.GetFromJsonAsync<Usuario>($"api/Usuario/buscar/{id}");

            Console.WriteLine("Paso la llamada a la api, esto no se ejecuta ni en pedo, 99199");

            Console.WriteLine($"Llego la siguiente respuesta: {response.Id}, {response.Name}, {response.Role}, {response.Imagen}");

            return response;
        }

        // POST: api/Usuarios/crear
        public async Task<bool> CreateUsuario(Usuario usuario)
        {
            var response = await _http.PostAsJsonAsync("api/Usuario/guardar", usuario);
            return response.IsSuccessStatusCode;
        }

        // PUT: api/Usuarios/editar/{id}
        public async Task<bool> UpdateUsuario(int id, Usuario usuario)
        {
            Console.WriteLine($"llego a UpdateUsuario. 001111: {usuario.Role},{usuario.Imagen}");

            var response = await _http.PutAsJsonAsync($"api/Usuario/editar/{id}", usuario);

            return response.IsSuccessStatusCode;
        }

        // DELETE: api/Usuarios/eliminar/{id}
        public async Task<bool> EliminarUsuario(int id)
        {
            var response = await _http.DeleteAsync($"api/Usuario/eliminar/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
