using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebasAPIBlazor.Migrations
{
    /// <inheritdoc />
    public partial class ColumnaIdAutorReceta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                table: "Recetas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAutor",
                table: "Recetas");
        }
    }
}
