using Microsoft.AspNetCore.Components;
using WebAPIBlazor.Components.Extensions;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class BorrarReceta : ComponentBase
    {

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IRecetaService RecetaService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }

        protected override void OnInitialized()
        {
            var id = ObjectTransporter.RetrieveData("id");
            var token = ObjectTransporter.RetrieveData("token");
            if (id != null && token != null)
            {
                var receta = RecetaService.GetReceta(Id);
                if (receta.IdAutor == (int)id)
                {
                    RecetaService.DeleteReceta(receta, token.ToString());
                }
                NavigationManager.NavigateTo("/perfil", true);
                base.OnInitialized();
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
