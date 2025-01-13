using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Extensions;

namespace WebAPIBlazor.Components.Services
{
    public class RecetaService : IRecetaService
    {
        private ObjectTransporter ObjectTransporter { get; set; }

        private HttpClient HttpClient { get; set; }

        public RecetaService(ObjectTransporter objectTransporter, HttpClient httpClient)
        {
            ObjectTransporter = objectTransporter;
            HttpClient = httpClient;
            if (ObjectTransporter.RetrieveData("token") != null)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ObjectTransporter.RetrieveData("token").ToString());
            }
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

        public Receta PostReceta(Receta receta, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

        public bool PutReceta(Receta receta, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = HttpClient.PutAsJsonAsync($"putReceta/{receta.Id}", receta).Result;
            return response.IsSuccessStatusCode ? true : false;
        }

        public bool DeleteReceta(Receta receta, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = HttpClient.DeleteAsync($"deleteReceta/{receta.Id}").Result;
            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
