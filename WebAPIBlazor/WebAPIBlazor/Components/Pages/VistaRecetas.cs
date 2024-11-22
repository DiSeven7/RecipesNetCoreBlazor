using Microsoft.AspNetCore.Components;
using WebAPIBlazor.Components.DTO;
using WebAPIBlazor.Components.Services;

namespace WebAPIBlazor.Components.Pages
{
    public partial class VistaRecetas : ComponentBase
    {
        [Parameter]
        public required string Tipo { get; set; }

        [Parameter]
        public required int Id { get; set; }

        [Inject]
        public IRecetaService RecetaService { get; set; }

        public string Titulo { get; set; }

        public List<Receta> Recetas = new List<Receta>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            GetRecetas(Tipo, Id);
        }

        public void GetRecetas(string tipo, int id)
        {
            switch (tipo)
            {
                case "categorias":
                    Recetas = RecetaService.GetRecetasCategoria(id);
                    Titulo = Recetas != null ? $"Recetas de {Recetas.First().Categoria.ToString()}" : "¡No hay recetas (todavía)!";
                    break;
                case "dificultad":
                    Recetas = RecetaService.GetRecetasDificultad(id);
                    Titulo = Recetas != null ? $"Recetas de dificultad {Recetas.First().Dificultad.ToString()}" : "¡No hay recetas (todavía)!";
                    break;
                default:
                    Recetas = null;
                    break;
            }
        }
    }
}
