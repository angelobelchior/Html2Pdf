// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

using RazorEngineCore;

namespace Html2PdfLib.core
{
    internal static class RazorHelpper
    {
        public static string CompileTemplate<T>(string razorTemplate, T model)
        {
            var razorEngine = new RazorEngine();
            var template = razorEngine.Compile<RazorEngineTemplateBase<T>>(razorTemplate, builderAction: builder =>
            {
                builder.AddAssemblyReferenceByName("System");
                builder.AddAssemblyReferenceByName("System.Linq");
                builder.AddAssemblyReferenceByName("System.Collections");
            });
            return template.Run(instance =>
            {
                instance.Model = model;
            });
        }
    }
}
