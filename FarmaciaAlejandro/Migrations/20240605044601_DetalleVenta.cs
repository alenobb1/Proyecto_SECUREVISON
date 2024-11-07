using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaAlejandro.Migrations
{
    /// <inheritdoc />
    public partial class DetalleVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleVentaFarmacia",
                columns: table => new
                {
                    IDDetalleVentaFarmacia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVenta = table.Column<int>(type: "int", nullable: false),
                    IDMedicina = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVentaFarmacia", x => x.IDDetalleVentaFarmacia);
                    table.ForeignKey(
                        name: "FK_DetalleVentaFarmacia_MedicinaFarmacia_IDMedicina",
                        column: x => x.IDMedicina,
                        principalTable: "MedicinaFarmacia",
                        principalColumn: "IDMedicamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVentaFarmacia_VentaFarmacia_IDVenta",
                        column: x => x.IDVenta,
                        principalTable: "VentaFarmacia",
                        principalColumn: "IdVentaFarmacia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentaFarmacia_IDMedicina",
                table: "DetalleVentaFarmacia",
                column: "IDMedicina");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentaFarmacia_IDVenta",
                table: "DetalleVentaFarmacia",
                column: "IDVenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVentaFarmacia");
        }
    }
}
