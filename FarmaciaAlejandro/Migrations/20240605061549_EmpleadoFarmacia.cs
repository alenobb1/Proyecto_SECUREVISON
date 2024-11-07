using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaAlejandro.Migrations
{
    /// <inheritdoc />
    public partial class EmpleadoFarmacia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartamentoFarmacia",
                columns: table => new
                {
                    IDDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoFarmacia", x => x.IDDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoFarmacia",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    puesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salario = table.Column<double>(type: "float", nullable: true),
                    IDDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoFarmacia", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_EmpleadoFarmacia_DepartamentoFarmacia_IDDepartamento",
                        column: x => x.IDDepartamento,
                        principalTable: "DepartamentoFarmacia",
                        principalColumn: "IDDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoFarmacia_IDDepartamento",
                table: "EmpleadoFarmacia",
                column: "IDDepartamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoFarmacia");

            migrationBuilder.DropTable(
                name: "DepartamentoFarmacia");
        }
    }
}
