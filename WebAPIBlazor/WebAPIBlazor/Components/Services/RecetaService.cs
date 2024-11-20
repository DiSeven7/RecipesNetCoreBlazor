using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebAPIBlazor.Components.DTO;

namespace WebAPIBlazor.Components.Services
{
    public class RecetaService : IRecetaService
    {
        private HttpClient HttpClient { get; set; }
        public RecetaService(HttpClient httpClient)
        {
            HttpClient = httpClient;            
        }

        public Task<bool> DeleteReceta(Receta receta)
        {
            throw new NotImplementedException();
        }

        public Receta GetReceta(int id)
        {
            throw new NotImplementedException();
        }

        public List<Receta> GetRecetas()
        {
            var response = HttpClient.GetAsync("getRecetas").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var ListaRecetas = JsonConvert.DeserializeObject<List<Receta>>(json);

                return ListaRecetas;
            }
            else
            {
                return null;
            }
        }

        public List<Receta> GetRecetasCategoria(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public List<Receta> GetRecetasUsuario(int idAutor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostReceta(Receta receta)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutReceta(Receta receta)
        {
            throw new NotImplementedException();
        }
    }
}
