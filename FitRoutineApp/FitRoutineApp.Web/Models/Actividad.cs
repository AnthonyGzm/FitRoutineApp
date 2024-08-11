using System;
using System.ComponentModel.DataAnnotations;

namespace FitRoutineApp.Web.Models
{
    public class Actividad 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
    }
}
