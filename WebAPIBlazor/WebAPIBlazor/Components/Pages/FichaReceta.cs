using Microsoft.AspNetCore.Components;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class FichaReceta : ComponentBase
    {
        [Inject]
        public IRecetaService RecetaService { get; set; }

        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public string Autor { get; set; }

        public Receta Receta { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Receta = RecetaService.GetReceta(Id);
            Autor = UsuarioService.GetUsuario(Receta.IdAutor).Email;
        }

    }
}
