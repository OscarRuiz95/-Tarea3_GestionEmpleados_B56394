using GestionEmpleados.DA;
using GestionEmpleados.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleados.BL
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> ObtenerTodos() =>
            _context.Empleados.AsNoTracking().ToList();

        public Empleado ObtenerPorId(int id) =>
            _context.Empleados.Find(id);

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return ObtenerTodos();

            termino = termino.ToLower();
            return _context.Empleados
                .Where(e => e.Nombre.ToLower().Contains(termino) ||
                            e.Apellidos.ToLower().Contains(termino) ||
                            e.Departamento.ToLower().Contains(termino))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string busqueda)
        {
            var query = BuscarPorNombreODepartamento(busqueda);
            return query.Skip((pagina - 1) * tamano).Take(tamano);
        }

        public int ContarTotal(string busqueda) =>
            BuscarPorNombreODepartamento(busqueda).Count();

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public void ToggleActivo(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                empleado.Activo = !empleado.Activo;
                _context.SaveChanges();
            }
        }
    }
}
