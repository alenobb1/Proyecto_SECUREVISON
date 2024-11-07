using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaAlejandro.Migrations
{
    /// <inheritdoc />
    public partial class Correccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaFarmacia_ClienteFarmacia_IdClienteFarmacia",
                table: "VentaFarmacia");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaFarmacia_Cliente_IdClienteFarmacia",
                table: "VentaFarmacia",
                column: "IdClienteFarmacia",
                principalTable: "Cliente",
                principalColumn: "Idcliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaFarmacia_Cliente_IdClienteFarmacia",
                table: "VentaFarmacia");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaFarmacia_ClienteFarmacia_IdClienteFarmacia",
                table: "VentaFarmacia",
                column: "IdClienteFarmacia",
                principalTable: "ClienteFarmacia",
                principalColumn: "Idcliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
