using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FitRoutineApp.Web.Models
{
    public class HistorialDeActividades
    {
        [Key]
        public int Id { get; set; }

        [ValidateNever]
        public Usuario? Usuario { get; set; }

        public DateTime FechaActividad { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; } = null!;

        [StringLength(500)]
        public string? Observaciones { get; set; }
    }
}