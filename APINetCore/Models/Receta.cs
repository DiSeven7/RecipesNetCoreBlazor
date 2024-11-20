using System.ComponentModel.DataAnnotations.Schema;

namespace PruebasAPIBlazor.Models
{
    [Table("Recetas")]
    public class Receta
    {
        public int Id { get; set; }

        public required int IdAutor { get; set; }

        public required string NombreReceta { get; set; }

        public required string Ingredientes { get; set; }

        public required string Descripcion { get; set; }

        public required Categoria Categoria { get; set; }

        public required byte[] Imagen { get; set; }

        public string? Referencias { get; set; }
    }

}
