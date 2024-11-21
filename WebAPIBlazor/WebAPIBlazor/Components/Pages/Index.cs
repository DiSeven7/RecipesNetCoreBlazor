using Microsoft.AspNetCore.Components;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Services;
namespace WebAPIBlazor.Components.Pages
{
    public partial class Index : ComponentBase
    {
        private List<Receta> Recetas = new List<Receta>();

        private List<int> obtenidos = new List<int>();

        [Inject]
        public IRecetaService RecetaService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var recetas = RecetaService.GetRecetas();
            if (recetas != null)
            {
                Recetas = recetas;
            }
        }

        public int GetRecetaRandom()
        {
            var random = new Random();
            int obtenido = random.Next(0, Recetas.Count - 3);
            if (!obtenidos.Any(x => x == obtenido))
            {
                obtenidos.Add(obtenido);
                return obtenido;
            }
            else
            {
                while (obtenidos.Any(x => x == obtenido))
                {
                    obtenido = random.Next(0, Recetas.Count - 3);
                }
                obtenidos.Add(obtenido);
                return obtenido;
            }
        }

    }
}
