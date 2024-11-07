﻿// <auto-generated />
using System;
using FarmaciaAlejandro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmaciaAlejandro.Migrations
{
    [DbContext(typeof(ConexionDB))]
    [Migration("20240605060815_DepartamentoFarmacia")]
    partial class DepartamentoFarmacia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmaciaAlejandro.Models.Cliente", b =>
                {
                    b.Property<int>("Idcliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcliente"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idcliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.ClienteFarmacia", b =>
                {
                    b.Property<int>("Idcliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcliente"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idcliente");

                    b.ToTable("ClienteFarmacia");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.Compra", b =>
                {
                    b.Property<int>("Idcompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcompra"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<double>("TotalCompra")
                        .HasColumnType("float");

                    b.HasKey("Idcompra");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.DetalleVentaFarmacia", b =>
                {
                    b.Property<int>("IDDetalleVentaFarmacia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDetalleVentaFarmacia"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IDMedicina")
                        .HasColumnType("int");

                    b.Property<int>("IDVenta")
                        .HasColumnType("int");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.HasKey("IDDetalleVentaFarmacia");

                    b.HasIndex("IDMedicina");

                    b.HasIndex("IDVenta");

                    b.ToTable("DetalleVentaFarmacia");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.MedicinaFarmacia", b =>
                {
                    b.Property<int>("IDMedicamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDMedicamento"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IDMedicamento");

                    b.ToTable("MedicinaFarmacia");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.Proveedor", b =>
                {
                    b.Property<int>("Idproveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idproveedor"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idproveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.VentaFarmacia", b =>
                {
                    b.Property<int>("IdVentaFarmacia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVentaFarmacia"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClienteFarmacia")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("IdVentaFarmacia");

                    b.HasIndex("IdClienteFarmacia");

                    b.ToTable("VentaFarmacia");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.Compra", b =>
                {
                    b.HasOne("FarmaciaAlejandro.Models.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.DetalleVentaFarmacia", b =>
                {
                    b.HasOne("FarmaciaAlejandro.Models.MedicinaFarmacia", "MedicinaFarmacia")
                        .WithMany()
                        .HasForeignKey("IDMedicina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmaciaAlejandro.Models.VentaFarmacia", "VentaFarmacia")
                        .WithMany()
                        .HasForeignKey("IDVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicinaFarmacia");

                    b.Navigation("VentaFarmacia");
                });

            modelBuilder.Entity("FarmaciaAlejandro.Models.VentaFarmacia", b =>
                {
                    b.HasOne("FarmaciaAlejandro.Models.ClienteFarmacia", "ClienteFarmacia")
                        .WithMany()
                        .HasForeignKey("IdClienteFarmacia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClienteFarmacia");
                });
#pragma warning restore 612, 618
        }
    }
}
