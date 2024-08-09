using FitRoutineApp.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace FitRoutineApp.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Usuario usuario)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == usuario.Email && u.Contraseña == usuario.Contraseña);

            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Rol)
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }


            ModelState.AddModelError(string.Empty, "Correo electrónico o contraseña incorrectos.");
            return View(usuario);
        }
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Rol = "Usuario";

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Usuario registrado exitosamente!!!";
                return RedirectToAction("IniciarSesion");
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}