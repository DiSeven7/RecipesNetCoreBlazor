using WebAPIBlazor.Components.DTO;

namespace WebAPIBlazor.Components.Services
{
    public interface IUsuarioService
    {
        List<Usuario> GetUsuarios();

        Usuario GetUsuario(int id);

        bool PostUsuario(Usuario usuario);

        bool PutUsuario(Usuario usuario);

        bool DeleteUsuario(Usuario usuario);

        int Login(Usuario usuario);

    }
}
