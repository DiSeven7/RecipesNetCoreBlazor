using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Extensions;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class Perfil : ComponentBase
    {
        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        [Inject]
        public IRecetaService RecetaService { get; set; }

        [Inject]
        public ConfigurationManager Configuration { get; set; }

        [Required(ErrorMessage = "Debe introducir la contraseña actual")]
        private string ContraseñaActual = string.Empty;

        [Required(ErrorMessage = "Debe introducir una nueva contraseña")]
        [Length(6, 50, ErrorMessage = "La nueva contraseña debe tener entre 6 y 50 caracteres")]
        private string NuevaContraseña = string.Empty;

        [SupplyParameterFromForm]
        public Receta Receta { get; set; }

        private Usuario Usuario { get; set; }

        private bool HuboError = false;

        private bool Modificado = false;

        private bool VerRecetas = false;

        private string MensajeError = string.Empty;

        private List<Receta>? Recetas;

        protected override void OnInitialized()
        {
            var id = ObjectTransporter.RetrieveData("id");
            var token = ObjectTransporter.RetrieveData("token");
            if (id != null && token != null)
            {
                Usuario = UsuarioService.GetUsuario((int)id, token.ToString());
                Recetas = RecetaService.GetRecetasUsuario(Usuario.Id);
                base.OnInitialized();
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }

        public void CerrarSesion()
        {
            ObjectTransporter.RemoveData("id");
            ObjectTransporter.RemoveData("token");
            NavigationManager.NavigateTo("/", true);
        }

        public void MuestraDatos()
        {
            VerRecetas = false;
        }

        public void MuestraRecetas()
        {
            VerRecetas = true;
        }

        public void AñadeReceta()
        {
            VerRecetas = false;
        }

        public void CambiarContraseña()
        {
            if (!PasswordHelpers.Encrypt(ContraseñaActual, Configuration.GetSection("Salt").Value).Equals(Usuario.Contraseña))
            {
                HuboError = true;
                Modificado = false;
                MensajeError = "La contraseña actual indicada no es correcta";
            }
            else if (NuevaContraseña.Length < 6 || NuevaContraseña.Length > 50)
            {
                HuboError = true;
                Modificado = false;
                MensajeError = "La nueva contraseña debe tener entre 6 y 50 caracteres";
            }
            else
            {
                Usuario.Contraseña = NuevaContraseña;
                if (UsuarioService.PutUsuario(Usuario, ObjectTransporter.RetrieveData("token").ToString()))
                {
                    Modificado = true;
                    HuboError = false;
                }
                else
                {
                    HuboError = true;
                    Modificado = false;
                    MensajeError = "Se ha producido un error al tratar de actualizar la contraseña";
                }
            }
        }
    }
}
