using GestionEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestionEmpleados.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Redirect root to Empleados index as main page
            return RedirectToAction("Index", "Empleados");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
