using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Html2Pdf.Lib;

internal static class WkHtmlToPdf
{
    /// <summary>
    /// Converts an HTML content string to PDF byte array format.
    /// </summary>
    /// <param name="timeout">Timeout to convert to PDF in milliseconds. If null value, it will be changed to default value <see cref="Arguments"/> DefaultTimeout</param>
    /// <param name="logger"><see cref="ILogger"/>Logger interface</param>
    /// <param name="html">String containing HTML code that should be converted to PDF.</param>
    /// <param name="arguments">Arguments that will be passed to wkhtmltopdf binary.</param>
    /// <param name="filename">full path to file PDF</param>
    /// <returns>PDF as byte array or file in type <see cref="ConvertResult"/></returns>
    public static ConvertResult ConvertFromHtml(int? timeout, ILogger? logger, string html, string arguments = "", string? filename = null)
    {
        if (string.IsNullOrEmpty(html))
            throw new ArgumentNullException(nameof(html));
        var tempFile = Guid.NewGuid();
        var tempFileHtml = $"{tempFile}.html";
        var filePdf = filename ?? $"{tempFile}.pdf";
        var istmpfile = string.IsNullOrEmpty(filename);

        timeout ??= Arguments.DefaultTimeout;

        if (!filePdf.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
        {
            filePdf += ".pdf";
        }

        ConvertResult result;
        var sw = Stopwatch.StartNew();
        try
        {
            File.WriteAllText(tempFileHtml, html);
            arguments += $" \"{tempFileHtml}\" \"{filePdf}\"";

            (var bytesFile, var error) = Execute(timeout.Value, logger, arguments, filePdf, istmpfile);

            result = new ConvertResult(sw.Elapsed,
                istmpfile ? bytesFile : null,
                istmpfile ? null : filePdf,
                string.IsNullOrEmpty(error) ? null : new Exception(error));
        }
        catch (Exception e)
        {
            logger?.LogError(e, "Html2Pdf.Lib: Error ConvertFromHtml");
            result = new ConvertResult(sw.Elapsed, null, null, e);
        }
        finally
        {
            if (File.Exists(tempFileHtml))
            {
                try
                {
                    File.Delete(tempFileHtml);
                }
                catch (Exception e)
                {
                    logger?.LogError(e, "Html2Pdf.Lib ConvertFromHtml: cannot remove tmpfile : {tmp}", tempFileHtml);
                    result = new ConvertResult(sw.Elapsed, null, null, e);
                }
            }
            if (istmpfile)
            {
                if (File.Exists(filePdf))
                {
                    try
                    {
                        File.Delete(filePdf);
                    }
                    catch (Exception e)
                    {
                        logger?.LogError(e, "Html2Pdf.Lib ConvertFromHtml: cannot remove tmpfile : {tmp}", filePdf);
                        result = new ConvertResult(sw.Elapsed, null, null, e);
                    }
                }
            }
        }
        return result;
    }

    /// <summary>
    /// Converts an HTML content string to PDF byte array format.
    /// </summary>
    /// <param name="timeout">Timeout to convert to PDF in milliseconds. If null value, it will be changed to default value <see cref="Arguments"/> DefaultTimeout</param>
    /// <param name="logger"><see cref="ILogger"/>Logger interface</param>
    /// <param name="url">URL that should be converted to PDF.</param>
    /// <param name="arguments">Arguments that will be passed to wkhtmltopdf binary.</param>
    /// <param name="filename">full path to file PDF</param>
    /// <returns>PDF as byte array or file in type <see cref="ConvertResult"/></returns>
    public static ConvertResult ConvertFromUrl(int? timeout, ILogger? logger, Uri url, string arguments = "", string? filename = null)
    {
        var filePdf = filename ?? $"{Guid.NewGuid()}.pdf";
        var istmpfile = string.IsNullOrEmpty(filename);

        timeout ??= Arguments.DefaultTimeout;

        if (!filePdf.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
        {
            filePdf += ".pdf";
        }

        ConvertResult result;
        var sw = Stopwatch.StartNew();
        try
        {
            arguments += $" \"{url}\" \"{filePdf}\"";

            string? error;
            (var bytesFile, error) = Execute(timeout.Value, logger, arguments, filePdf, istmpfile);


            result = new ConvertResult(sw.Elapsed,
                istmpfile ? bytesFile : null,
                istmpfile ? null : filePdf,
                string.IsNullOrEmpty(error) ? null : new Exception(error));
        }
        catch (Exception e)
        {
            logger?.LogError(e, "Error ConvertFromUrl");
            result = new ConvertResult(sw.Elapsed, null, null, e);
        }
        finally
        {
            if (istmpfile)
            {
                if (File.Exists(filePdf))
                {
                    try
                    {
                        File.Delete(filePdf);
                    }
                    catch (Exception e)
                    {
                        logger?.LogWarning(e, "Html2Pdf.Lib ConvertFromUrl: cannot remove tmpfile : {tmp}", filePdf);
                        result = new ConvertResult(sw.Elapsed, null, null, e);
                    }
                }
            }
        }
        return result;
    }

    private static (byte[] pdfFile, string error) Execute(int timeout, ILogger? logger, string arguments, string filePdf, bool istmpfile)
    {
        arguments = "-q " + arguments.Trim();

        string error = string.Empty;
        int exitcode;
        using (var process = CreateProcess(logger, arguments))
        {
            process.Start();
            if (!process.WaitForExit(timeout) && !process.HasExited)
            {
                error = $"Timeout Execute Process {process.ProcessName}: {timeout}ms";
                process.Kill();
            }
            else
            {
                error = process.StandardError.ReadToEnd();
            }
            exitcode = process.ExitCode;
        }
        if (File.Exists(filePdf) && exitcode != 0 && !istmpfile)
        {
            logger?.LogError("Html2Pdf.Lib Execute exitcode({exitcode}) for file {filePdf}", exitcode, filePdf);
        }
        if (!File.Exists(filePdf) || exitcode != 0 || !istmpfile)
        {
            return (Array.Empty<byte>(), error);
        }
        //only for tmp PDF file
        using var ms = new MemoryStream();
        using var fileStream = new FileStream(filePdf, FileMode.Open, FileAccess.Read);
        fileStream.CopyTo(ms);
        return (ms.ToArray(), string.Empty);
    }

    private static Process CreateProcess(ILogger? logger, string arguments)
    {
        logger?.LogDebug("{value}", arguments);
        return new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = WkHtmlToPdfFile.GetFilePath(),
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }
        };
    }
}