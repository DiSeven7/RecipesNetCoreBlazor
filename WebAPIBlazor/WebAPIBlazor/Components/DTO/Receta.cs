namespace WebAPIBlazor.Components.DTO
{
    public class Receta
    {
        public int Id { get; set; }

        public string NombreReceta { get; set; }

        public string Ingredientes { get; set; }

        public string Descripcion { get; set; }

        public Categoria Categoria { get; set; }

        public byte[] Imagen { get; set; }

        public string Referencias { get; set; }

        public Receta() { }

        public Receta(int id, string nombreReceta, string ingredientes, string descripcion, Categoria categoria, byte[] imagen, string? referencias)
        {
            Id = id;
            NombreReceta = nombreReceta;
            Ingredientes = ingredientes;
            Descripcion = descripcion;
            Categoria = categoria;
            Imagen = imagen;
            Referencias = referencias;
        }
    }
}
