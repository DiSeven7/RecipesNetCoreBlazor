using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebasAPIBlazor.Migrations
{
    /// <inheritdoc />
    public partial class ColumaImagenRecetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Recetas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Recetas");
        }
    }
}
