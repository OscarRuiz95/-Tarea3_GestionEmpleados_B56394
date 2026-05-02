using GestionEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestionEmpleados.Controllers
//Test para ver si no me cargue el programa por andar jugando con los commits
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
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
