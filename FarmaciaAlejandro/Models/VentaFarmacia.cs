using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAlejandro.Models
{
    public class VentaFarmacia
    {
        [Key]//Indica que es llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//indicamos que sea autoincremental
        public int IdVentaFarmacia { get; set; }
        public int IdClienteFarmacia { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        //Relaciones externas
        [ForeignKey("IdClienteFarmacia")]
        public virtual Cliente Cliente { get; set; }
    }
}
