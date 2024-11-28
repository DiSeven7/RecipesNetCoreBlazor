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
            if (ObjectTransporter.RetrieveData("id") != null)
            {
                var receta = RecetaService.GetReceta(Id);
                if (receta.IdAutor == (int)ObjectTransporter.RetrieveData("id"))
                {
                    RecetaService.DeleteReceta(receta);
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
