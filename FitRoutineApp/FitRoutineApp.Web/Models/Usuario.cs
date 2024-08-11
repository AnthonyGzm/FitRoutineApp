using System.ComponentModel.DataAnnotations;

namespace FitRoutineApp.Web.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Clave { get; set; } = null!;

    }
}
