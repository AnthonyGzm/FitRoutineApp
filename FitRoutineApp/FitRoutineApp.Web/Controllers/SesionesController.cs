using FitRoutineApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FitRoutineApp.Controllers
{
    public class SesionesController : Controller
    {
        private readonly DataContext _context;

        public SesionesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sesiones = await _context.Sesiones
                .Include(s => s.Usuario)
                .Include(s => s.Entrenador)
                .ToListAsync();

            return View(sesiones);
        }
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listUsuarios = await _context.Usuarios.OrderBy(u => u.Nombre).Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            })
            .ToListAsync();

            listUsuarios.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un usuario...]",
                Value = "0"
            });

            List<SelectListItem> listEntrenadores = await _context.Entrenadores.OrderBy(i => i.Nombre).Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            })
            .ToListAsync();

            listEntrenadores.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un entrenador...]",
                Value = "0"
            });

            ViewBag.Usuarios = listUsuarios;
            ViewBag.Entrenadores = listEntrenadores;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sesion sesion)
        {
            if (ModelState.IsValid)
            {
                var entrenador = _context.Entrenadores.FirstOrDefault(c => c.Id == sesion.IdEntrenador);
                var usuario = _context.Usuarios.FirstOrDefault(c => c.Id == sesion.IdUsuario);
                var nuevaSesion = new Sesion()
                {
                    IdEntrenador = sesion.IdEntrenador,
                    Entrenador = entrenador,
                    IdUsuario = sesion.IdUsuario,
                    Usuario = usuario,
                    Descripcion = sesion.Descripcion,
                    FechaSesion = sesion.FechaSesion,
                    HoraSesion = sesion.HoraSesion
                };
                _context.Add(nuevaSesion);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Sesión creada exitosamente!!!";
                return RedirectToAction("Index");
            }
            return View(sesion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sesiones == null)
            {
                return NotFound();
            }

            var sesion = await _context.Sesiones.FirstOrDefaultAsync(e => e.Id == id);

            if (sesion == null)
            {
                return NotFound();
            }

            _context.Sesiones.Remove(sesion);
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Sesión eliminada exitosamente!!!";
            return RedirectToAction("Index");
        }

        public IActionResult Calendar()
        {
            List<Sesion> eventos = _context.Sesiones.ToList();
            List<object> items = new List<object>();

            foreach (Sesion evento in eventos)
            {
                var item = new
                {
                    id = evento.Id,
                    title = evento.Descripcion,
                    start = evento.FechaSesion.AddHours(10),
                    end = evento.FechaSesion.AddHours(11)
                };
                items.Add(item);
            }

            ViewBag.Eventos = JsonConvert.SerializeObject(items);
            return View();
        }

        public IActionResult Pagar()
        {
            return View();
        }
    }
}