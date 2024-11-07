using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAlejandro.Models
{
	public class Proveedor
	{
		[Key]//Indica que es llave primaria
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//indicamos que sea autoincremental
		public int Idproveedor { get; set; }

		public string? Nombre { get; set; }

		public string? Direccion { get; set; }

		public string? Telefono { get; set; }

		public string? Email { get; set; }

	}
}
