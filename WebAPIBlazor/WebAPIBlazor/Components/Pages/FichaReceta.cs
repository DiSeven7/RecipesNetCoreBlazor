using Microsoft.AspNetCore.Components;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Extensions;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class FichaReceta : ComponentBase
    {

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IRecetaService RecetaService { get; set; }

        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Autor { get; set; }

        public Receta Receta { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var objetivo = RecetaService.GetReceta(Id);
            if (objetivo != null)
            {
                Receta = objetivo;
                Autor = "admin";
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
