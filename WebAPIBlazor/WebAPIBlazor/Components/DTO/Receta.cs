namespace WebAPIBlazor.Components.DTO
{
    public class Receta
    {
        public int Id { get; set; }

        public int IdAutor { get; set; }

        public string NombreReceta { get; set; }

        public string Ingredientes { get; set; }

        public string Descripcion { get; set; }

        public int Tiempo { get; set; }

        public Categoria Categoria { get; set; }

        public Dificultad Dificultad { get; set; }

        public string Imagen { get; set; }

        public string?Referencias { get; set; }

        public Receta() { }

        public Receta(int id, int idAutor, string nombreReceta, string ingredientes, string descripcion, int tiempo, Categoria categoria, Dificultad dificultad, string imagen, string? referencias)
        {
            Id = id;
            IdAutor = idAutor;
            NombreReceta = nombreReceta;
            Ingredientes = ingredientes;
            Descripcion = descripcion;
            Tiempo = tiempo;
            Categoria = categoria;
            Dificultad = dificultad;
            Imagen = imagen;
            Referencias = referencias;
        }
    }
}
