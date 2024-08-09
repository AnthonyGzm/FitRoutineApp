using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitRoutineApp.Web.Models
{
    public class Sesion
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public int IdUsuario { get; set; }

        [NotMapped]
        public int IdEntrenador { get; set; }

        public Usuario? Usuario { get; set; }

        public Entrenador? Entrenador { get; set; }

        public DateTime FechaSesion { get; set; }

        public DateTime HoraSesion { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; } = null!;
    }
}