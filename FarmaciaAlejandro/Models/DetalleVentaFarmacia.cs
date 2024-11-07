using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAlejandro.Models
{
    public class DetalleVentaFarmacia
    {
        [Key] // Indica que esta propiedad es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que el valor es generado automáticamente por la base de datos
        public int IDDetalleVentaFarmacia { get; set; } // Propiedad para el ID del medicamento
        public int IDVenta { get; set; } // Propiedad para el ID del medicamento
        public int IDMedicina { get; set; } // Propiedad para el ID del medicamento
        public int Cantidad { get; set; } // Propiedad para el ID del medicamento
        public double SubTotal { get; set; } // Propiedad para el ID del medicamento


        //Relaciones externas
        [ForeignKey("IDVenta")]
        public virtual VentaFarmacia VentaFarmacia { get; set; }
        //Relaciones externas
        [ForeignKey("IDMedicina")]
        public virtual MedicinaFarmacia MedicinaFarmacia { get; set; }
    }
}
