using System;
using System.ComponentModel.DataAnnotations;

namespace FitRoutineApp.Web.Models
{
    public class Cliente 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Cedula { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Sexo { get; set; }

        [Phone]
        public string Telefono { get; set; }
    }
}

