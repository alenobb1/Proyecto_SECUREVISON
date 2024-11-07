using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaAlejandro.Models
{
	public class Usuario
	{
		[Key]//Indica que es llave primaria
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//indicamos que sea autoincremental
		public int IdUsuario { get; set; }

		public string? Nombre { get; set; }

		public string? Contrasenia { get; set; }
	}
}
