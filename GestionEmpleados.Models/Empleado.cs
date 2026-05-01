using System.ComponentModel.DataAnnotations;

namespace GestionEmpleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(80, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres.")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(400000, 10000000, ErrorMessage = "El campo {0} debe estar entre {1} y {2}.")]
        [Display(Name = "Salario")]
        public decimal Salario { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; } = true;

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto => $"{Nombre} {Apellidos}";
    }
}
