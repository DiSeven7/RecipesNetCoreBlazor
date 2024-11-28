using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.ComponentModel.DataAnnotations;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Extensions;
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

        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }

        [Required(ErrorMessage = "El campo confirmación contraseña es obligatorio")]
        private string ConfirmacionContraseña = string.Empty;

        private bool RegistroIncorrecto = false;

        private string MensajeError = string.Empty;

        protected override void OnInitialized()
        {
            if (ObjectTransporter.RetrieveData("id") == null)
            {
                base.OnInitialized();
                Usuario = new Usuario();
            }
            else
            {
                NavigationManager.NavigateTo("/perfil");
            }
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
                        NavigationManager.NavigateTo("/login/fromRegister");
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
