using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Extensions;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class Login : ComponentBase
    {

        [SupplyParameterFromForm]
        private Usuario Usuario { get; set; }

        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }

        private bool SesionIncorrecta = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Usuario = new Usuario();
        }

        private void IniciarSesion()
        {
            Usuario.Id = 0;
            var usuarioId = UsuarioService.Login(Usuario);
            if (usuarioId != -1)
            {
                ObjectTransporter.AddData("id", usuarioId);
                NavigationManager.NavigateTo("/");
            }
            else
            {
                SesionIncorrecta = true;
            }
        }

    }
}
