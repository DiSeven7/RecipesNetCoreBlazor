using Newtonsoft.Json;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Extensions;

namespace WebAPIBlazor.Components.Services
{
    public class UsuarioService : IUsuarioService
    {
        private HttpClient HttpClient { get; set; }

        private ConfigurationManager Configuration { get; set; }

        public UsuarioService(HttpClient httpClient, ConfigurationManager configuration)
        {
            HttpClient = httpClient;
            Configuration = configuration;
        }

        public Usuario GetUsuario(int id)
        {
            var response = HttpClient.GetAsync($"getUsuario/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var usuario = JsonConvert.DeserializeObject<Usuario>(json);

                return usuario;
            }
            else
            {
                return null;
            }
        }

        public List<Usuario> GetUsuarios()
        {
            var response = HttpClient.GetAsync($"getUsuarios").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var usuario = JsonConvert.DeserializeObject<List<Usuario>>(json);

                return usuario;
            }
            else
            {
                return null;
            }
        }

        public bool PostUsuario(Usuario usuario)
        {
            var response = HttpClient.PostAsJsonAsync($"postUsuario", usuario).Result;
            return response.IsSuccessStatusCode ? true : false;
        }

        public bool PutUsuario(Usuario usuario)
        {
            var response = HttpClient.PutAsJsonAsync($"putUsuario/{usuario.Id}", usuario).Result;
            return response.IsSuccessStatusCode ? true : false;
        }

        public bool DeleteUsuario(Usuario usuario)
        {
            var response = HttpClient.DeleteAsync($"deleteUsuario/{usuario.Id}").Result;
            return response.IsSuccessStatusCode ? true : false;
        }

        public int Login(Usuario usuario)
        {
            var response = HttpClient.PostAsJsonAsync($"login", usuario).Result;
            if (response.IsSuccessStatusCode)
            {
                string id = response.Content.ReadAsStringAsync().Result;

                return int.Parse(id);
            }
            else
            {
                return -1;
            }
        }

    }
}
