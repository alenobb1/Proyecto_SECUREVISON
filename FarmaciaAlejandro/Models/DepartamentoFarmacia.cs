using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAlejandro.Models
{
    public class DepartamentoFarmacia
    {
        [Key]//Indica que es llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//indicamos que sea autoincremental

        public int IDDepartamento { get; set; }

        public string? Nombre { get; set; }


        public string? Descripcion { get; set; }




    }
}
