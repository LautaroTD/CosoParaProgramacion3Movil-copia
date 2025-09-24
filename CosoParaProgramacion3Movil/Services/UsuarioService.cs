using CosoParaProgramacion3Movil.Models;

namespace CosoParaProgramacion3Movil.Services;

//Los SERVICES tienen todos los metodos de los MODELOS. Mas o menos asi.

public class UsuarioService
{
    public readonly List<Usuario> lista; //esto simula el _context de una coneccion a una base de datos
    public UsuarioService()
    {
        lista = new List<Usuario>()
        {
            new Usuario { Id = 1, Nombre = "A", Contrasena = "11", Imagen = "/img/images.png", Rol = "Basico"},
            new Usuario { Id = 2, Nombre = "B", Contrasena = "22", Imagen = "/img/usericon.jpg", Rol = "Admin1"},
            new Usuario { Id = 3, Nombre = "C", Contrasena = "33", Imagen = "/img/generico.jpg", Rol = "Admin2"},
            new Usuario { Id = 4, Nombre = "D", Contrasena = "44", Imagen = "/img/generico.jpg", Rol = "Basico"},
            new Usuario { Id = 5, Nombre = "E", Contrasena = "55", Imagen = "/img/generico.jpg", Rol = "Basico"},
            new Usuario { Id = 6, Nombre = "F", Contrasena = "66", Imagen = "/img/generico.jpg", Rol = "Admin7"},
            new Usuario { Id = 7, Nombre = "G", Contrasena = "77", Imagen = "/img/generico.jpg", Rol = "Basico"},
            new Usuario { Id = 8, Nombre = "H", Contrasena = "88", Imagen = "/img/generico.jpg", Rol = "Basico"},
            new Usuario { Id = 9, Nombre = "I", Contrasena = "99", Imagen = "/img/generico.jpg", Rol = "Basico"},
            new Usuario { Id = 10, Nombre = "J", Contrasena = "1010", Imagen = "/img/generico.jpg", Rol = "Basico"}
        };
    }

    public List<Usuario> GetUsuarios()
    {
        return lista;
    }

    public Usuario GetUsuarios(int id)
    {
        return lista.FirstOrDefault(p => p.Id == id);
    }

    public void AddUsuario(Usuario usuario)
    {
        if (lista.Any())
        {
        usuario.Id = lista.Max(p => p.Id) + 1;
        }
        else
        {
            usuario.Id = 1;
        } 
        lista.Add(usuario);
    }

    public void UpdateUsuario(Usuario usuario)
    {
        var usuarioExistente = lista.FirstOrDefault(u => u.Id == usuario.Id);
        if (usuarioExistente != null)
        {
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Contrasena = usuario.Contrasena;
            usuarioExistente.Rol = usuario.Rol;
        }
    }

    public void DeleteUsuario(int id)
    {
        var usuario = lista.FirstOrDefault(u => u.Id == id);
        
        if (usuario != null)
        {
            lista.Remove(usuario);
        }
    }
}
