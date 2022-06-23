using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mockaco.Gui
{
    internal static class GuiExtensions
    {

        public static IApplicationBuilder UseGui(this IApplicationBuilder app)
        {
            var guiPath = new PathString($"/_mockaco/gui");
            app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments(guiPath) , first =>
            {
                first.UseBlazorFrameworkFiles(guiPath);
                first.UseStaticFiles();
                first.UseStaticFiles(guiPath);
                first.UseRouting();

                first.UseEndpoints(endpoints =>
                {
                    endpoints.MapFallbackToFile(guiPath + "/{*path:nonfile}", 
                        guiPath + "/index.html");
                });
            });
            
            return app;
        }
    }
}