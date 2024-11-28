using WebAPIBlazor.Components.DTO;

namespace WebAPIBlazor.Components.Services
{
    public interface IRecetaService
    {
        List<Receta> GetRecetas();

        List<Receta> GetRecetasUsuario(int idAutor);

        List<Receta> GetRecetasCategoria(int idCategoria);

        List<Receta> GetRecetasDificultad(int idDificultad);

        Receta GetReceta(int id);

        Receta PostReceta(Receta receta);

        bool PutReceta(Receta receta);

        bool DeleteReceta(Receta receta);
    }
}
