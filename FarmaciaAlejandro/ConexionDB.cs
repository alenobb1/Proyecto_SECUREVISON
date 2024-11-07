using FarmaciaAlejandro.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaAlejandro
{
	public class ConexionDB : Microsoft.EntityFrameworkCore.DbContext
	{
		public ConexionDB(DbContextOptions<ConexionDB> options) : base(options)
		{
		}
		public virtual DbSet<Usuario> Usuario { get; set; }
		public virtual DbSet<Proveedor> Proveedor { get; set; }
		public virtual DbSet<Cliente> Cliente { get; set; }
		public virtual DbSet<Compra> Compra { get; set; }
		public virtual DbSet<MedicinaFarmacia> MedicinaFarmacia { get; set; }


        public virtual DbSet<ClienteFarmacia> ClienteFarmacia { get; set; }
        public virtual DbSet<VentaFarmacia> VentaFarmacia { get; set; }
        public virtual DbSet<DetalleVentaFarmacia> DetalleVentaFarmacia { get; set; }
        public virtual DbSet<DepartamentoFarmacia> DepartamentoFarmacia	 { get; set; }

        public virtual DbSet<EmpleadoFarmacia> EmpleadoFarmacia { get; set; }


    }
}
