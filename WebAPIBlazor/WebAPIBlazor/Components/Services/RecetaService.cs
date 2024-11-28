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

        public Receta GetReceta(int id)
        {
            var response = HttpClient.GetAsync($"getReceta/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var ListaRecetas = JsonConvert.DeserializeObject<Receta>(json);

                return ListaRecetas;
            }
            else
            {
                return null;
            }
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
            var response = HttpClient.GetAsync($"getRecetasCategoria/{idCategoria}").Result;
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

        public List<Receta> GetRecetasDificultad(int idDificultad)
        {
            var response = HttpClient.GetAsync($"getRecetasDificultad/{idDificultad}").Result;
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

        public List<Receta> GetRecetasUsuario(int idAutor)
        {
            var response = HttpClient.GetAsync($"getRecetasUsuario/{idAutor}").Result;
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

        public Receta PostReceta(Receta receta)
        {
            var response = HttpClient.PostAsJsonAsync($"postReceta", receta).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Receta>(json);
            }
            else
            {
                var body = response.Content.ReadAsStringAsync().Result;
                return null;
            }
        }

        public bool PutReceta(Receta receta)
        {
            var response = HttpClient.PutAsJsonAsync($"putReceta/{receta.Id}", receta).Result;
            return response.IsSuccessStatusCode ? true : false;
        }

        public bool DeleteReceta(Receta receta)
        {
            var response = HttpClient.DeleteAsync($"deleteReceta/{receta.Id}").Result;
            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
