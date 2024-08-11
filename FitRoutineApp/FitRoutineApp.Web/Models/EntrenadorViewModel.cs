using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitRoutineApp.Web.Models
{
    public class EntrenadorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int EspecialidadId { get; set; }

        // Lista de actividades para el dropdown
        public IEnumerable<SelectListItem> Actividades { get; set; }
    }
}
