using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitRoutineApp.Web.Models; 
using FitRoutineApp.Web.Services;

namespace FitRoutineApp.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly FitRoutineContext _context;

        public ClientesController(FitRoutineContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de clientes
        public async Task<IActionResult> Lista()
        {
            ViewData["ShowHeaderSection"] = false;
            return View(await _context.Clientes.ToListAsync());
        }

        // Acción para mostrar el formulario de creación de cliente
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para manejar la creación de un nuevo cliente
        [HttpPost]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cliente creado exitosamente!!!";
                    return RedirectToAction("Lista");
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
                }
            }
            return View(cliente);
        }

        // Acción para mostrar el formulario de edición de cliente
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // Acción para manejar la edición de un cliente
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cliente actualizado exitosamente!!!";
                    return RedirectToAction("Lista");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrió un error al actualizar");
                }
            }
            return View(cliente);
        }

        // Acción para mostrar el formulario de eliminación de cliente
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cliente eliminado exitosamente!!!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrió un error, no se pudo eliminar el registro");
            }

            return RedirectToAction(nameof(Lista));
        }
    }
}