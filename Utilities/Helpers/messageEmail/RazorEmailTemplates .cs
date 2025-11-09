using RazorLight;
using Utilities.Helpers.interfaces;

namespace Utilities.Helpers.messageEmail
{
    // Clase "marca" para ubicar los recursos embebidos
    public sealed class RazorEmailTemplates { }

    public class RazorLightEmailTemplateRenderer : IEmailTemplateRenderer
    {
        private readonly RazorLightEngine _engine;


        public RazorLightEmailTemplateRenderer()
        {
            _engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(RazorEmailTemplates).Assembly, "Utilities")
                .UseMemoryCachingProvider()
                .UseOptions(new RazorLight.RazorLightOptions { EnableDebugMode = true })
                .Build();
        }

        public Task<string> RenderAsync<TModel>(string templateKey, TModel model)
        {
            // templateKey = "Templates.Welcome.cshtml"
            return _engine.CompileRenderAsync(templateKey, model);
        }
    }
    
}
