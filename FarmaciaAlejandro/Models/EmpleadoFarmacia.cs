using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAlejandro.Models
{
    public class EmpleadoFarmacia
    {
        [Key]//Indica que es llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//indicamos que sea autoincremental
        public int IdEmpleado  { get; set; }
        public int IDDepartamento { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? puesto { get; set; }

        public double? salario { get; set; }

        //Relaciones externas
        [ForeignKey("IDDepartamento")]
        public virtual DepartamentoFarmacia DepartamentoFarmacia { get; set; }

    }
}
