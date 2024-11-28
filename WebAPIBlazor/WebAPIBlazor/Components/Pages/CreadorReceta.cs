using Microsoft.AspNetCore.Components;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Extensions;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class CreadorReceta : ComponentBase
    {
        [SupplyParameterFromForm]
        public Receta Receta { get; set; }

        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IRecetaService RecetaService { get; set; }

        private bool HuboError = false;

        private string MensajeError = string.Empty;

        protected override void OnInitialized()
        {
            if (ObjectTransporter.RetrieveData("id") != null)
            {
                Receta = new();
                base.OnInitialized();
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }

        public void GuardarReceta()
        {
            if ((!Receta.Imagen.StartsWith("http") || !Receta.Imagen.StartsWith("https")) &&
                (!Receta.Imagen.EndsWith("jpg") || !Receta.Imagen.EndsWith("png") || !Receta.Imagen.EndsWith("jpeg")
                || !Receta.Imagen.EndsWith("gif") || !Receta.Imagen.EndsWith("webp") || !Receta.Imagen.EndsWith("svg")
                || !Receta.Imagen.EndsWith("bmp") || !Receta.Imagen.EndsWith("tiff")))
            {
                HuboError = true;
                MensajeError = "La url introducida para la imagen no es válida";
            }
            else
            {
                Receta.IdAutor = (int)ObjectTransporter.RetrieveData("id");
                Receta.Ingredientes = Receta.Ingredientes.Replace("\n", ";");
                if (Receta.Referencias != null)
                {
                    Receta.Referencias = Receta.Referencias.Replace("\n", ";");
                }
                var resultado = RecetaService.PostReceta(Receta);
                if (resultado != null)
                {
                    NavigationManager.NavigateTo($"receta/{resultado.Id}", true);
                }
                else
                {
                    HuboError = true;
                    MensajeError = "Se ha producido un error al tratar de guardar la receta";
                }
            }
        }

        public void CambiaCategoria(ChangeEventArgs args)
        {
            Receta.Categoria = (Categoria)args.Value;
        }

        public void CambiaDificultad(ChangeEventArgs args)
        {
            Receta.Dificultad = (Dificultad)args.Value;
        }

    }
}
