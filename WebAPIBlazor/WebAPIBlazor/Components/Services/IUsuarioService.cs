using WebAPIBlazor.Components.DTO;

namespace WebAPIBlazor.Components.Services
{
    public interface IUsuarioService
    {
        List<Usuario> GetUsuarios();

        Usuario GetUsuario(int id);

        Task<bool> PostUsuario(Usuario usuario);

        Task<bool> PutUsuario(Usuario usuario);

        Task<bool> DeleteUsuario(Usuario usuario);

        Task<bool> Login(Usuario usuario);

    }
}
