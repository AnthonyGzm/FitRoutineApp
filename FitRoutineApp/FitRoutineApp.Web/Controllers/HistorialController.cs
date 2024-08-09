using FitRoutineApp.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitRoutineApp.Web.Controllers
{
    public class HistorialController : Controller
    {
        private readonly DataContext _context;

        public HistorialController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? idUsuario)
        {
            List<SelectListItem> list = await _context.Usuarios.OrderBy(p => p.Nombre).Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            })
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un usuario...]",
                Value = "0"
            });

            idUsuario ??= 0;

            var historialDeActividades = await _context.HistorialDeActividades
                .Where(h => h.Usuario!.Id == idUsuario)
                .ToListAsync();

            var viewModel = new HistorialDeActividadesViewModel
            {
                IdUsuario = idUsuario.Value,
                HistorialesDeActividades = historialDeActividades
            };

            ViewBag.Usuarios = list;
            return View(viewModel);
        }

        public IActionResult Create(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(p => p.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var viewModel = new HistorialDeActividadesViewModel
            {
                IdUsuario = id,
                Usuario = usuario
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HistorialDeActividadesViewModel viewModel)
        {
            var usuario = _context.Usuarios.FirstOrDefault(p => p.Id == viewModel.Usuario!.Id);

            if (ModelState.IsValid)
            {
                var historialDeActividades = new HistorialDeActividades
                {
                    Usuario = usuario,
                    FechaActividad = DateTime.Now,  // Asumimos que esto se relaciona con la fecha de la actividad
                    Descripcion = viewModel.Descripcion,
                    Observaciones = viewModel.Observaciones
                };
                _context.HistorialDeActividades.Add(historialDeActividades);
                await _context.SaveChangesAsync();

                TempData["AlertMessage"] = "Registro creado exitosamente.";
                return RedirectToAction(nameof(Index), new { id = viewModel.IdUsuario });
            }
            return View(viewModel);
        }
    }
}
