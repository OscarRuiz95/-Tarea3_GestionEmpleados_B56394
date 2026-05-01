using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionEmpleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }

    [Required, StringLength(80)]
    public string Nombre { get; set; }

    [Required, StringLength(100)]
    public string Apellidos { get; set; }

    [Required]
    public string Departamento { get; set; }

    [Required, Range(400000, 10000000)]
    public decimal Salario { get; set; }

    public DateTime FechaIngreso { get; set; }

    public bool Activo { get; set; } = true;

    public string NombreCompleto => $"{Nombre} {Apellidos}";
}
}
