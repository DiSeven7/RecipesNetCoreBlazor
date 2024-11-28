using Microsoft.AspNetCore.Components;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Extensions;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class EditorReceta : ComponentBase
    {

        [Parameter]
        public int Id { get; set; }

        [SupplyParameterFromForm]
        private Receta Receta { get; set; }

        [Inject]
        public IRecetaService RecetaService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ObjectTransporter ObjectTransporter { get; set; }

        private bool HuboError = false;

        private string MensajeError = string.Empty;

        protected override void OnInitialized()
        {
            if (ObjectTransporter.RetrieveData("id") != null)
            {
                Receta = RecetaService.GetReceta(Id);
                if (Receta.IdAutor == (int)ObjectTransporter.RetrieveData("id"))
                {
                    Receta.Ingredientes = Receta.Ingredientes.Replace(";", "\n");
                    Receta.Referencias = Receta.Referencias != null ? Receta.Referencias.Replace(";", "\r\n") : string.Empty;
                    base.OnInitialized();
                }
                else
                {
                    NavigationManager.NavigateTo("/perfil");
                }
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }

        public void EditarReceta()
        {
            if (Receta.Categoria == 0)
            {
                HuboError = true;
                MensajeError = "Debe seleccionarse una categoría";
            }
            else if (Receta.Dificultad == 0)
            {
                HuboError = true;
                MensajeError = "Debe seleccionarse una dificultad";
            }
            else if ((!Receta.Imagen.StartsWith("http") || !Receta.Imagen.StartsWith("https")) &&
                (!Receta.Imagen.EndsWith("jpg") || !Receta.Imagen.EndsWith("png") || !Receta.Imagen.EndsWith("jpeg")
                || !Receta.Imagen.EndsWith("gif") || !Receta.Imagen.EndsWith("webp") || !Receta.Imagen.EndsWith("svg")
                || !Receta.Imagen.EndsWith("bmp") || !Receta.Imagen.EndsWith("tiff")))
            {
                HuboError = true;
                MensajeError = "La url introducida para la imagen no es válida";
            }
            else
            {
                Receta.Ingredientes = Receta.Ingredientes.Replace("\n", ";");
                Receta.Referencias = Receta.Referencias.Replace("\n", ";");
                if (RecetaService.PutReceta(Receta))
                {
                    NavigationManager.NavigateTo($"receta/{Receta.Id}", true);
                }
                else
                {
                    HuboError = true;
                    MensajeError = "Se ha producido un error al actualizar la receta";
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
