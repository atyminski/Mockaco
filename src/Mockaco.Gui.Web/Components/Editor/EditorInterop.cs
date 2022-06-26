using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Mockaco.Gui.Web.Components.Editor
{
    internal class EditorInterop
    {
        private const string InteropPrefix = "mockaco.gui.editor.";

        private readonly IJSRuntime jsRuntime;
        private readonly ILogger logger;

        public EditorInterop(IJSRuntime jsRuntime, ILogger<EditorInterop> logger)
        {
            this.jsRuntime = jsRuntime;
            this.logger = logger;
        }

        public async Task CreateEditorAsync(ElementReference element)
        {
            var editorId = Guid.NewGuid().ToString();

            await CreateEditorAsync(editorId, element);
        }

        public async Task CreateEditorAsync(string editorId, ElementReference element)
        {
            await InvokeVoidAsync("createEditor", editorId, element);
        }

        public ValueTask<TResult> InvokeAsync<TResult>(string methodName, params object[] args)
        {
            var fullname = InteropPrefix + methodName;
            logger.LogDebug("InvokeAsync: {0}", fullname);
            return jsRuntime.InvokeAsync<TResult>(fullname, args);
        }

        public ValueTask InvokeVoidAsync(string methodName, params object[] args)
        {
            var fullname = InteropPrefix + methodName;
            logger.LogDebug("InvokeAsyncVoid: {0}", fullname);
            return jsRuntime.InvokeVoidAsync(fullname, args);
        }
    }
}
