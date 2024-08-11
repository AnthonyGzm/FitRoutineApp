using FitRoutineApp.Web.Models;

namespace FitRoutineApp.Web.Services
{
    public interface IServicioUsuario
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario usuario);
        Task<Usuario> GetUsuario(string nombreUsuario);
    }
}
