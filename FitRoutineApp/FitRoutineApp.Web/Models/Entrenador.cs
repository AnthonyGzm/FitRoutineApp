﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitRoutineApp.Web.Models
{
    public class Entrenador
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

        [ForeignKey(nameof(EspecialidadId))]
        public Actividad Especialidad { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Actividades { get; set; }
    }
}
