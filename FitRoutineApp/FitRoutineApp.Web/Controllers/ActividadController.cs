using FitRoutineApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FitRoutineApp.Web.Controllers
{
    public class ActividadController : Controller
    {
        private readonly FitRoutineContext _context;

        public ActividadController(FitRoutineContext context)
        {
            _context = context;
        }

        // Acción para listar actividades
        public async Task<IActionResult> Lista()
        {
            return View(await _context.Actividades.ToListAsync());
        }

        // Acción para mostrar el formulario de creación
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(actividad);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Actividad creada exitosamente!!!";
                    return RedirectToAction("Lista");
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
                }
            }
            return View(actividad);
        }

        // Acción para mostrar el formulario de edición
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Actividades == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }
            return View(actividad);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividad);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Actividad actualizada exitosamente!!!";
                    return RedirectToAction("Lista");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrió un error al actualizar");
                }
            }
            return View(actividad);
        }

        // Acción para mostrar el formulario de eliminación
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Actividades == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividades
                .FirstOrDefaultAsync(m => m.Id == id);

            if (actividad == null)
            {
                return NotFound();
            }

            try
            {
                _context.Actividades.Remove(actividad);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Actividad eliminada exitosamente!!!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrió un error, no se pudo eliminar el registro");
            }

            return RedirectToAction(nameof(Lista));
        }
    }
}
