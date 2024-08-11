using Microsoft.AspNetCore.Mvc;

namespace FitRoutineApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ShowHeaderSection"] = true;
            return View();
        }
    }
}
