namespace FitRoutineApp.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;

    public class SesionViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int EntrenadorId { get; set; }
        public int ActividadId { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<SelectListItem> Clientes { get; set; }
        public IEnumerable<SelectListItem> Entrenadores { get; set; }
        public IEnumerable<SelectListItem> Actividades { get; set; }
    }
}