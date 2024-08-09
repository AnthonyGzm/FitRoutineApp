namespace FitRoutineApp.Web.Models
{
    public class Entrenador
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Especialidad { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName => $"{Nombre} {Apellido}";
    }
}