using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebasAPIBlazor.Migrations
{
    /// <inheritdoc />
    public partial class ColumnaCategoriaRecetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Recetas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Recetas");
        }
    }
}
