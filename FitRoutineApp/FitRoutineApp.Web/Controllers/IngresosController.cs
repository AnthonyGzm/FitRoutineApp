using FitRoutineApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitRoutineApp.Controllers
{
    public class IngresosController : Controller
    {
        private readonly DataContext _context;

        public IngresosController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ingresos = _context.Pagos.Include(i => i.Sesion).ToList(); // Reemplaza Cita con Sesion
            return View(ingresos);
        }
    }
}