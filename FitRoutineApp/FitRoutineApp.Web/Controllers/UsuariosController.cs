using FitRoutineApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitRoutineApp.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Lista()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Asignar una fecha de nacimiento por defecto si es necesario
                // usuario.FechaNacimiento = DateTime.Now.AddYears(-25); // Ajusta si es necesario

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Usuario creado exitosamente!!!";
                return RedirectToAction("Lista");
            }
            return View(usuario);
        }

        public IActionResult Detalles(int? id)
        {
            var usuario = _context.Usuarios
                .Include(u => u.HistorialDeActividades)
                .OrderByDescending(u => u.Id)
                .FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Usuario eliminado exitosamente!!!";
            return RedirectToAction("Lista");
        }
    }
}