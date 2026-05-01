using GestionEmpleados.BL;
using GestionEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GestionEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repo;

        public EmpleadosController(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string busqueda = "", int pagina = 1, int tamano = 5)
        {
            var total = _repo.ContarTotal(busqueda);
            var empleados = _repo.ObtenerPaginado(pagina, tamano, busqueda).ToList();
            var totalPages = (int)Math.Ceiling((double)total / tamano);

            ViewBag.Busqueda = busqueda ?? string.Empty;
            ViewBag.Pagina = Math.Max(1, pagina);
            ViewBag.Tamano = tamano;
            ViewBag.Total = total;
            ViewBag.TotalPages = Math.Max(1, totalPages);

            return View(empleados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            if (empleado.FechaIngreso == default)
                empleado.FechaIngreso = DateTime.Now;

            _repo.Agregar(empleado);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var emp = _repo.ObtenerPorId(id);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            _repo.Actualizar(empleado);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleActivo(int id, string busqueda = "", int pagina = 1)
        {
            _repo.ToggleActivo(id);
            return RedirectToAction(nameof(Index), new { busqueda, pagina });
        }
    }
}
