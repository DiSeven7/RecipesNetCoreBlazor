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

        [Parameter]
        public string? DesdeRegistro { get; set; }

        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }

        private string DisplayError = "none";

        private bool VieneDeRegistro = false;

        protected override void OnInitialized()
        {
            if (ObjectTransporter.RetrieveData("id") == null)
            {
                Usuario = new Usuario();
                if (DesdeRegistro != null && DesdeRegistro.Equals("fromRegister"))
                {
                    VieneDeRegistro = true;
                }
                base.OnInitialized();
            }
            else
            {
                NavigationManager.NavigateTo("/perfil");
            }
        }

        private void IniciarSesion()
        {
            var token = UsuarioService.ObtenerToken(Usuario);
            if (token != null)
            {
                ObjectTransporter.AddData("token", token);
                var usuarioId = UsuarioService.Login(Usuario, token);
                if (usuarioId != -1)
                {
                    ObjectTransporter.AddData("id", usuarioId);
                    NavigationManager.NavigateTo("/", true);
                }
                else
                {
                    DisplayError = "block";
                }
            }
        }

    }
}
