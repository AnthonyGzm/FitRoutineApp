using Microsoft.EntityFrameworkCore;
using FitRoutineApp.Web.Models;
using System.Threading.Tasks;

namespace FitRoutineApp.Web.Services
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly FitRoutineContext _context;

        public ServicioUsuario(FitRoutineContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            // Asegúrate de que 'clave' esté encriptada antes de la comparación
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Clave == clave);
        }

        public async Task<Usuario> GetUsuario(string nombreUsuario)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            // Asegúrate de que 'usuario.Clave' esté encriptada antes de guardar
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
