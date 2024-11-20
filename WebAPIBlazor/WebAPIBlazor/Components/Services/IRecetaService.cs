using WebAPIBlazor.Components.DTO;

namespace WebAPIBlazor.Components.Services
{
    public interface IRecetaService
    {
        List<Receta> GetRecetas();

        List<Receta> GetRecetasUsuario(int idAutor);

        List<Receta> GetRecetasCategoria(int idCategoria);

        Receta GetReceta(int id);

        Task<bool> PostReceta(Receta receta);

        Task<bool> PutReceta(Receta receta);

        Task<bool> DeleteReceta(Receta receta);
    }
}
