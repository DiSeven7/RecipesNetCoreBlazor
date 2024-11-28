using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using WebAPIBlazor.Components.Extensions;

namespace WebAPIBlazor.Components.Layout
{
    public partial class NavBar : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage Sesion { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }    

        public int id = -1;

        protected override void OnInitialized()
        {
            var data = ObjectTransporter.RetrieveData("id");
            if (data != null)
            {
                id = (int)data;
                StateHasChanged();
            }
            base.OnInitialized();
        }
    }
}
