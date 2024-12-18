using RazorEngineCore;

namespace Html2Pdf.Lib;

/// <summary>
/// Converter HTML to PDF
/// </summary>
public static class Converter
{
    /// <summary>
    /// Content Type
    /// </summary>
    public static readonly string ContentType = "application/pdf";
    
    /// <summary>
    /// Converts the HTML to PDF
    /// </summary>
    /// <param name="html">html</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>PDF as byte array</returns>
    public static byte[] FromHtml(string html, Arguments? arguments = null)
    {
        var buffer = WkHtmlToPdf.ConvertFromHtml(html, arguments?.ToString() ?? string.Empty);
        return buffer;
    }

    /// <summary>
    /// Converts the URL to PDF
    /// </summary>
    /// <param name="url">Url</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>PDF as byte array</returns>
    public static byte[] FromUrl(Uri url, Arguments? arguments = null)
    {
        var buffer = WkHtmlToPdf.ConvertFromUrl(url, arguments?.ToString() ?? string.Empty);
        return buffer;
    }

    /// <summary>
    /// Converts the Razor Template to PDF
    /// </summary>
    /// <param name="razorTemplate">Razor Template</param>
    /// <param name="model">Object model</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>PDF as byte array</returns>
    public static byte[] FromRazorTemplate<T>(string razorTemplate, T model, Arguments? arguments = null)
    {
        var template = CompileRazorTemplate<T>(razorTemplate);
        var buffer = RunTemplateAndCreatePdf(template, model, arguments);
        return buffer;
    }

    /// <summary>
    /// Converts the Razor Template to PDF
    /// </summary>
    /// <param name="razorTemplate">Razor Template</param>
    /// <param name="models">Object models list</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>PDF as byte array</returns>
    public static IReadOnlyCollection<byte[]> FromRazorTemplateBatch<T>(
        string razorTemplate, 
        IReadOnlyCollection<T> models,
        Arguments? arguments = null)
    {
        var template = CompileRazorTemplate<T>(razorTemplate);

        var buffers = new List<byte[]>();
        foreach (var model in models)
        {
            var buffer = RunTemplateAndCreatePdf(template, model, arguments);
            buffers.Add(buffer);
        }

        return buffers;
    }

    private static byte[] RunTemplateAndCreatePdf<T>(IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template, T model,
        Arguments? arguments = null)
    {
        var razorCompiledAsHtml = template.Run(instance =>
        {
            instance.Model = model;
        });
        var buffer = WkHtmlToPdf.ConvertFromHtml(razorCompiledAsHtml, arguments?.ToString() ?? string.Empty);
        return buffer;
    }

    private static IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> CompileRazorTemplate<T>(string razorTemplate)
    {
        var razorEngine = new RazorEngine();
        var template = razorEngine.Compile<RazorEngineTemplateBase<T>>(razorTemplate, builderAction: builder =>
        {
            builder.AddAssemblyReferenceByName("System");
            builder.AddAssemblyReferenceByName("System.Linq");
            builder.AddAssemblyReferenceByName("System.Collections");
        });
        return template;
    }
}