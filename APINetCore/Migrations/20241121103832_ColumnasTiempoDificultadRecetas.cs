using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebasAPIBlazor.Migrations
{
    /// <inheritdoc />
    public partial class ColumnasTiempoDificultadRecetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dificultad",
                table: "Recetas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tiempo",
                table: "Recetas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dificultad",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Tiempo",
                table: "Recetas");
        }
    }
}
