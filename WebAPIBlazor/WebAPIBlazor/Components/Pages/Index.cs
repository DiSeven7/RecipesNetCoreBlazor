using Microsoft.AspNetCore.Components;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class Index : ComponentBase
    {
        private List<Receta> Recetas = new List<Receta>();

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

    }
}
