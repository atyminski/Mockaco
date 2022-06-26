using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Mockaco.Gui.Web.Components.Editor
{
    public partial class Editor
    {
        private ElementReference editorContainer;

        [Inject]
        private EditorInterop Interop { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Interop.CreateEditorAsync(editorContainer);
            }
        }
    }
}
