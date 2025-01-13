using WebAPIBlazor.Components.DTO;

namespace WebAPIBlazor.Components.Services
{
    public interface IUsuarioService
    {
        List<Usuario> GetUsuarios(string token);

        Usuario GetUsuario(int id, string token);

        bool PostUsuario(Usuario usuario);

        bool PutUsuario(Usuario usuario, string token);

        bool DeleteUsuario(Usuario usuario, string token);

        int Login(Usuario usuario, string token);

        string ObtenerToken(Usuario usuario);

    }
}
