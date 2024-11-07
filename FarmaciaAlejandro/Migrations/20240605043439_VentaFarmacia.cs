using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaAlejandro.Migrations
{
    /// <inheritdoc />
    public partial class VentaFarmacia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VentaFarmacia",
                columns: table => new
                {
                    IdVentaFarmacia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClienteFarmacia = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaFarmacia", x => x.IdVentaFarmacia);
                    table.ForeignKey(
                        name: "FK_VentaFarmacia_ClienteFarmacia_IdClienteFarmacia",
                        column: x => x.IdClienteFarmacia,
                        principalTable: "ClienteFarmacia",
                        principalColumn: "Idcliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentaFarmacia_IdClienteFarmacia",
                table: "VentaFarmacia",
                column: "IdClienteFarmacia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentaFarmacia");
        }
    }
}
