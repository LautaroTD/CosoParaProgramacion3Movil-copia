using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CosoParaProgramacion3Movil.Models;
using CosoParaProgramacion3Movil.Services;

namespace CosoParaProgramacion3Movil.Services
{
    public class SesionService
    {
        private readonly UsuarioService _usuarioService;
        public string UsuarioActual { get; private set; } = null;
        public bool EstaAutenticado => !string.IsNullOrEmpty(UsuarioActual);

        public SesionService(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public bool Login(string nombre, string contrasena)
        {
            var usuarios = _usuarioService.GetUsuarios();

            var usuario = usuarios.FirstOrDefault(u =>
                u.Nombre == nombre && u.Contrasena == contrasena);

            if (usuario != null)
            {
                UsuarioActual = usuario.Nombre;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            UsuarioActual = null;
        }
    }
}
