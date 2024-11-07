using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAlejandro.Models
{
    public class Compra
    {

        [Key]//Indica que es llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//indicamos que sea autoincremental
        public int Idcompra { get; set; }

        public int IdProveedor { get; set; }

        public DateTime Fecha { get; set; }

        public double TotalCompra { get; set; }

        //Relaciones externas
        [ForeignKey("IdProveedor")]
        public virtual  Proveedor Proveedor { get; set; }
    }
}
