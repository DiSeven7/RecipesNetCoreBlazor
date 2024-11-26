using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class Registro : ComponentBase
    {

        [SupplyParameterFromForm]
        private Usuario Usuario { get; set; }

        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string ConfirmacionContraseña = string.Empty;

        private bool RegistroIncorrecto = false;

        private string MensajeError = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Usuario = new Usuario();
        }

        private void RegistrarUsuario()
        {
            if (Usuario.Contraseña != null && Usuario.Email != null)
            {
                if (!Usuario.Contraseña.Equals(ConfirmacionContraseña))
                {
                    RegistroIncorrecto = true;
                    MensajeError = "La contraseña no coincide";
                }
                else
                {
                    Usuario.Id = 0;
                    Usuario.Verificado = true;
                    if (UsuarioService.PostUsuario(Usuario))
                    {
                        NavigationManager.NavigateTo("/login");
                    }
                    else
                    {
                        RegistroIncorrecto = true;
                        MensajeError = "El email ya existe o no es válido";
                    }
                }
            }
            else
            {
                RegistroIncorrecto = true;
                MensajeError = "Ningún campo puede quedar vacío";
            }
        }

    }
}
