using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitRoutineApp.Web.Models
{
    public class Sesion
    {
        [Key]
        public int Id { get; set; } // Clave primaria
   
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Cliente Cliente { get; set; } // Relación con Cliente

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Entrenador Entrenador { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Actividad Actividad { get; set; }

        public DateTime Fecha { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un cliente.")]
        public int ClienteId { get; set; } // Clave foránea

        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un entrenador.")]
        public int EntrenadorId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar una actividad.")]
        public int ActividadId { get; set; }
    }
}