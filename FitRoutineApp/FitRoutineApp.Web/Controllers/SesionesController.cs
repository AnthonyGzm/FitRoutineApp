using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitRoutineApp.Web.Models;
using FitRoutineApp.Web.Services;
using System.Threading.Tasks;
using System.Linq;

namespace FitRoutineApp.Web.Controllers
{
    public class SesionesController : Controller
    {
        private readonly FitRoutineContext _context;
        private readonly IServicioLista _servicioLista;

        public SesionesController(FitRoutineContext context, IServicioLista servicioLista)
        {
            _context = context;
            _servicioLista = servicioLista;
        }

        public async Task<IActionResult> Lista()
        {
            var sesiones = await _context.Sesiones
                .Include(s => s.Cliente)
                .Include(s => s.Entrenador)
                .Include(s => s.Actividad)
                .ToListAsync();

            // Manejar posibles valores nulos en la vista
            foreach (var sesion in sesiones)
            {
                sesion.Cliente = sesion.Cliente ?? new Cliente { Nombre = "Desconocido" };
                sesion.Entrenador = sesion.Entrenador ?? new Entrenador { Nombre = "Desconocido" };
                sesion.Actividad = sesion.Actividad ?? new Actividad { Nombre = "Desconocido" };
            }

            return View(sesiones);
        }

        public async Task<IActionResult> Crear()
        {
            var viewModel = new SesionViewModel
            {
                Clientes = await _servicioLista.GetListaClientes(),
                Actividades = await _servicioLista.GetListaActividades(),
                Entrenadores = await _servicioLista.GetListaEntrenadores()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SesionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var sesion = new Sesion
                {
                    Fecha = viewModel.Fecha,
                    ClienteId = viewModel.ClienteId,
                    EntrenadorId = viewModel.EntrenadorId,
                    ActividadId = viewModel.ActividadId,
                   
                };

                try
                {
                    _context.Sesiones.Add(sesion);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Sesión creada exitosamente!!!";
                    return RedirectToAction(nameof(Lista));
                }
                catch (DbUpdateException dbEx)
                {
                    ModelState.AddModelError(string.Empty, $"Error al crear la sesión: {dbEx.Message} - {dbEx.InnerException?.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error al crear la sesión: {ex.Message} - {ex.InnerException?.Message}");
                }
            }

            // Repopulate dropdown lists if validation fails
            viewModel.Clientes = await _servicioLista.GetListaClientes();
            viewModel.Actividades = await _servicioLista.GetListaActividades();
            viewModel.Entrenadores = await _servicioLista.GetListaEntrenadores();

            return View(viewModel);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesion = await _context.Sesiones
                .Include(s => s.Cliente)
                .Include(s => s.Entrenador)
                .Include(s => s.Actividad)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (sesion == null)
            {
                return NotFound();
            }

            var viewModel = new SesionViewModel
            {
                Id = sesion.Id,
                Fecha = sesion.Fecha,
                ClienteId = sesion.ClienteId,
                EntrenadorId = sesion.EntrenadorId,
                ActividadId = sesion.ActividadId,
                Clientes = await _servicioLista.GetListaClientes(),
                Actividades = await _servicioLista.GetListaActividades(),
                Entrenadores = await _servicioLista.GetListaEntrenadores()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, SesionViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var sesion = await _context.Sesiones.FindAsync(id);
                    if (sesion == null)
                    {
                        return NotFound();
                    }

                    sesion.Fecha = viewModel.Fecha;
                    sesion.ClienteId = viewModel.ClienteId;
                    sesion.EntrenadorId = viewModel.EntrenadorId;
                    sesion.ActividadId = viewModel.ActividadId;

                    _context.Update(sesion);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Sesión editada exitosamente!!!";
                    return RedirectToAction(nameof(Lista));
                }
                catch (DbUpdateConcurrencyException dbEx)
                {
                    if (!_context.Sesiones.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"Error al editar la sesión: {dbEx.Message} - {dbEx.InnerException?.Message}");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error al editar la sesión: {ex.Message} - {ex.InnerException?.Message}");
                }
            }

            // Repopulate dropdown lists if validation fails
            viewModel.Clientes = await _servicioLista.GetListaClientes();
            viewModel.Actividades = await _servicioLista.GetListaActividades();
            viewModel.Entrenadores = await _servicioLista.GetListaEntrenadores();

            return View(viewModel);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Sesiones == null)
            {
                return NotFound();
            }

            var sesion = await _context.Sesiones
                .Include(s => s.Cliente)
                .Include(s => s.Entrenador)
                .Include(s => s.Actividad)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (sesion == null)
            {
                return NotFound();
            }

            return View(sesion);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmed(int id)
        {
            var sesion = await _context.Sesiones.FindAsync(id);
            if (sesion != null)
            {
                _context.Sesiones.Remove(sesion);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Sesión eliminada exitosamente!!!";
            }
            else
            {
                TempData["AlertMessage"] = "No se encontró la sesión.";
            }

            return RedirectToAction(nameof(Lista));
        }
    }
}
