using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario_2.Models
{
    public partial class AsientoContable
    {
        [Key] // Indica que esta propiedad es la clave primaria
        public int IdMovimiento { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(50, ErrorMessage = "La longitud máxima de la descripción es de 50 caracteres.")]
        public string Descripcion { get; set; } = null!;

        [NotMapped] // No se mapea a la base de datos
        public int? Auxiliar { get; set; }

        [Required(ErrorMessage = "La cuenta débito es obligatoria.")]
        [Display(Name = "Cuenta Débito")]
        public int CuentaDb { get; set; }

        [NotMapped] // No se mapea a la base de datos
        public string? CuentaDbDesc { get; set; }

        [Required(ErrorMessage = "La cuenta crédito es obligatoria.")]
        [Display(Name = "Cuenta Crédito")]
        public int CuentaCr { get; set; }

        [NotMapped] // No se mapea a la base de datos
        public string? CuentaCrDesc { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser mayor o igual a cero.")]
        public decimal? Monto { get; set; }
    }
}
