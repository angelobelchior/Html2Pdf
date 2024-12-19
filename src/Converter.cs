using System;
using System.Collections.Generic;
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
    /// <returns>PDF as byte array in type <see cref="ConvertResult"/>, property: Content</returns>
    public static ConvertResult FromHtml(string html, Arguments? arguments = null)
    {
        return WkHtmlToPdf.ConvertFromHtml(arguments?.GetTimeout(), arguments?.GetLogger(), html, arguments?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Converts the HTML to file PDF
    /// </summary>
    /// <param name="filename">full path to file PDF</param>
    /// <param name="html">html</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>Name created PDF filename in type <see cref="ConvertResult"/>, property: FileName</returns>
    public static ConvertResult FromHtml(string filename, string html, Arguments? arguments = null)
    {
        return WkHtmlToPdf.ConvertFromHtml(arguments?.GetTimeout(), arguments?.GetLogger(), html, arguments?.ToString() ?? string.Empty, filename);
    }

    /// <summary>
    /// Converts the URL to PDF
    /// </summary>
    /// <param name="url">Url</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>PDF as byte array in type <see cref="ConvertResult"/>, property: Content</returns>
    public static ConvertResult FromUrl(Uri url, Arguments? arguments = null)
    {
        return WkHtmlToPdf.ConvertFromUrl(arguments?.GetTimeout(), arguments?.GetLogger(), url, arguments?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Converts the URL to PDF
    /// </summary>
    /// <param name="filename">full path to file PDF</param>
    /// <param name="url">Url</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>Name created PDF filename in type <see cref="ConvertResult"/>, property: FileName</returns>
    public static ConvertResult FromUrl(string filename, Uri url, Arguments? arguments = null)
    {
        return WkHtmlToPdf.ConvertFromUrl(arguments?.GetTimeout(), arguments?.GetLogger(), url, arguments?.ToString() ?? string.Empty, filename);
    }

    /// <summary>
    /// Converts the Razor Template to PDF
    /// </summary>
    /// <param name="razorTemplate">Razor Template</param>
    /// <param name="model">Object model</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>PDF as byte array in type <see cref="ConvertResult"/>, property: Content</returns>
    public static ConvertResult FromRazorTemplate<T>(string razorTemplate, T model, Arguments? arguments = null)
    {
        return RunTemplateAndCreatePdf(CompileRazorTemplate<T>(razorTemplate), model, arguments);
    }

    /// <summary>
    /// Converts the Razor Template to PDF
    /// </summary>
    /// <param name="filename">full path to file PDF</param>
    /// <param name="razorTemplate">Razor Template</param>
    /// <param name="model">Object model</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>Name created PDF filename in type <see cref="ConvertResult"/>, property: FileName</returns>
    public static ConvertResult FromRazorTemplate<T>(string filename, string razorTemplate, T model, Arguments? arguments = null)
    {
        return RunTemplateAndCreatePdf(CompileRazorTemplate<T>(razorTemplate), model, arguments, filename);
    }

    /// <summary>
    /// Converts the Razor Template to PDF as byte array
    /// </summary>
    /// <param name="razorTemplate">Razor Template</param>
    /// <param name="models">Object models list</param>
    /// <param name="arguments"><see cref="Arguments">Arguments</see></param>
    /// <returns>PDF as byte array in type  array of <see cref="ConvertResult"/>, property: Content</returns>
    public static IReadOnlyCollection<ConvertResult> FromRazorTemplateBatch<T>(
        string razorTemplate,
        IReadOnlyCollection<T> models,
        Arguments? arguments = null)
    {
        var template = CompileRazorTemplate<T>(razorTemplate);

        var buffers = new List<ConvertResult>();
        foreach (var model in models)
        {
            buffers.Add(RunTemplateAndCreatePdf(template, model, arguments));
        }
        return buffers;
    }

    private static ConvertResult RunTemplateAndCreatePdf<T>(IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template,
        T model,
        Arguments? arguments = null, string? filename = null)
    {
        var razorCompiledAsHtml = template.Run(instance =>
        {
            instance.Model = model;
        });
        return WkHtmlToPdf.ConvertFromHtml(arguments?.GetTimeout(), arguments?.GetLogger(), razorCompiledAsHtml, arguments?.ToString() ?? string.Empty, filename);
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