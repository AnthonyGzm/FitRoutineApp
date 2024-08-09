namespace FitRoutineApp.Web.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName => $"{Nombre} {Apellidos}";

        public ICollection<HistorialDeActividades>? HistorialDeActividades { get; set; }

        // Propiedades adicionales para autenticación
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Rol { get; set; } = null!;

        // Fechas importantes
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
