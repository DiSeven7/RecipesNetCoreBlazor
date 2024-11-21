using Microsoft.AspNetCore.Components;

namespace WebAPIBlazor.Components.Pages
{
    public partial class VistaRecetas : ComponentBase
    {
        [Parameter]
        public required string Tipo { get; set; }

        [Parameter]
        public required int Nivel { get; set; }
    }
}
