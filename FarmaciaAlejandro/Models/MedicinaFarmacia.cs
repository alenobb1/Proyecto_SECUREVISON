using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAlejandro.Models
{
    public class MedicinaFarmacia
    {
        [Key] // Indica que esta propiedad es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que el valor es generado automáticamente por la base de datos
        public int IDMedicamento { get; set; } // Propiedad para el ID del medicamento

        // Indica que el campo es obligatorio
        public string Nombre { get; set; } // Propiedad para el nombre del medicamento

        // Indica que el campo es obligatorio
        public string Descripcion { get; set; } // Propiedad para la descripción del medicamento

        public decimal Precio { get; set; } // Propiedad para el precio del medicamento

        public int Stock { get; set; } // Propiedad para el stock del medicamento
    }
}
