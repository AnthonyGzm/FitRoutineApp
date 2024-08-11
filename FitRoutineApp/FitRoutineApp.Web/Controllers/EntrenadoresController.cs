using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitRoutineApp.Web.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitRoutineApp.Web.Controllers
{
    public class EntrenadoresController : Controller
    {
        private readonly FitRoutineContext _context;

        public EntrenadoresController(FitRoutineContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de entrenadores
        public async Task<IActionResult> Lista()
        {
            ViewData["ShowHeaderSection"] = false;
            return View(await _context.Entrenadores.Include(e => e.Especialidad).ToListAsync());
        }

        // Acción para mostrar el formulario de creación de entrenador
        public async Task<IActionResult> Crear()
        {
            var actividades = await _context.Actividades
                .AsNoTracking()
                .ToListAsync();

            var viewModel = new EntrenadorViewModel
            {
                Actividades = actividades.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Nombre
                }).Prepend(new SelectListItem { Value = "", Text = "Seleccione una especialidad" }).ToList()
            };

            return View(viewModel);
        }

        // Acción para manejar la creación de un nuevo entrenador
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(EntrenadorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entrenador = new Entrenador
                {
                    Nombre = viewModel.Nombre,
                    Cedula = viewModel.Cedula,
                    FechaNacimiento = viewModel.FechaNacimiento,
                    Sexo = viewModel.Sexo,
                    Telefono = viewModel.Telefono,
                    EspecialidadId = viewModel.EspecialidadId
                };

                _context.Entrenadores.Add(entrenador);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Entrenador creado exitosamente!";
                return RedirectToAction(nameof(Lista));
            }

            // Re-populate the select list if model state is invalid
            var actividades = await _context.Actividades
                .AsNoTracking()
                .ToListAsync();

            viewModel.Actividades = actividades.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Nombre
            }).Prepend(new SelectListItem { Value = "", Text = "Seleccione una especialidad" }).ToList();

            return View(viewModel);
        }

        // Acción para mostrar el formulario de edición de entrenador
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrenador = await _context.Entrenadores
                .Include(e => e.Especialidad)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (entrenador == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades
                .AsNoTracking()
                .ToListAsync();

            var viewModel = new EntrenadorViewModel
            {
                Id = entrenador.Id,
                Nombre = entrenador.Nombre,
                Cedula = entrenador.Cedula,
                FechaNacimiento = entrenador.FechaNacimiento,
                Sexo = entrenador.Sexo,
                Telefono = entrenador.Telefono,
                EspecialidadId = entrenador.EspecialidadId,
                Actividades = actividades.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Nombre
                }).Prepend(new SelectListItem { Value = "", Text = "Seleccione una especialidad" }).ToList()
            };

            return View(viewModel);
        }

        // Acción para manejar la edición de un entrenador
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, EntrenadorViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entrenador = new Entrenador
                    {
                        Id = viewModel.Id,
                        Nombre = viewModel.Nombre,
                        Cedula = viewModel.Cedula,
                        FechaNacimiento = viewModel.FechaNacimiento,
                        Sexo = viewModel.Sexo,
                        Telefono = viewModel.Telefono,
                        EspecialidadId = viewModel.EspecialidadId
                    };

                    _context.Update(entrenador);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Entrenador actualizado exitosamente!";
                    return RedirectToAction(nameof(Lista));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrenadorExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Re-populate the select list if model state is invalid
            var actividades = await _context.Actividades
                .AsNoTracking()
                .ToListAsync();

            viewModel.Actividades = actividades.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Nombre
            }).Prepend(new SelectListItem { Value = "", Text = "Seleccione una especialidad" }).ToList();

            return View(viewModel);
        }

        // Acción para mostrar el formulario de eliminación de entrenador
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrenador = await _context.Entrenadores
                .Include(e => e.Especialidad)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (entrenador == null)
            {
                return NotFound();
            }

            return View(entrenador);
        }

        // Acción para manejar la eliminación de un entrenador
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var entrenador = await _context.Entrenadores.FindAsync(id);
            if (entrenador != null)
            {
                _context.Entrenadores.Remove(entrenador);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Entrenador eliminado exitosamente!";
            }
            else
            {
                TempData["AlertMessage"] = "No se pudo encontrar el entrenador para eliminar.";
            }

            return RedirectToAction(nameof(Lista));
        }

        private bool EntrenadorExists(int id)
        {
            return _context.Entrenadores.Any(e => e.Id == id);
        }
    }
}
