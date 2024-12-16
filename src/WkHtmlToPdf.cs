using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Html2Pdf.Lib;

internal static class WkHtmlToPdf
{
    /// <summary>
    /// Converts an HTML content string to PDF byte array format.
    /// </summary>
    /// <param name="arguments">Arguments that will be passed to wkhtmltopdf binary.</param>
    /// <param name="html">String containing HTML code that should be converted to PDF.</param>
    /// <returns>PDF as byte array.</returns>
    public static byte[] ConvertFromHtml(string html, string arguments = "")
    {
        if (string.IsNullOrEmpty(html))
            throw new ArgumentNullException(nameof(html));

        var error = string.Empty;
        var tempFile = Guid.NewGuid();
        var tempFileHtml = $"{tempFile}.html";
        var tempFilePdf = $"{tempFile}.pdf";

        var rawHtml = EscapeNonAsciiCharacters(html);
        try
        {
            File.WriteAllText(tempFileHtml, rawHtml);
            arguments += $" {tempFileHtml} {tempFilePdf}";

            (var pdfFile, error) = Execute(arguments, tempFilePdf);

            return pdfFile;
        }
#if DEBUG
        catch (Exception e)
        {
            if (!string.IsNullOrEmpty(error)) throw new Exception(error);

            Console.WriteLine(e);

            throw;
        }
#else
        catch
        {
            if (!string.IsNullOrEmpty(error)) throw new Exception(error);
            throw;
        }
#endif
        finally
        {
            if (File.Exists(tempFileHtml)) File.Delete(tempFileHtml);
            if (File.Exists(tempFilePdf)) File.Delete(tempFilePdf);
        }
    }

    /// <summary>
    /// Converts an HTML content string to PDF byte array format.
    /// </summary>
    /// <param name="arguments">Arguments that will be passed to wkhtmltopdf binary.</param>
    /// <param name="url">URL that should be converted to PDF.</param>
    /// <returns>PDF as byte array.</returns>
    public static byte[] ConvertFromUrl(Uri url, string arguments = "")
    {
        var error = string.Empty;
        var tempFilePdf = $"{Guid.NewGuid()}.pdf";

        try
        {
            arguments += $" {url} {tempFilePdf}";

            (var pdfFile, error) = Execute(arguments, tempFilePdf);

            return pdfFile;
        }
#if DEBUG
        catch (Exception e)
        {
            if (!string.IsNullOrEmpty(error)) throw new Exception(error);

            Console.WriteLine(e);
            throw;
        }
#else
        catch 
        {
            if (!string.IsNullOrEmpty(error)) throw new Exception(error);
            throw;
        }
#endif
        finally
        {
            if (File.Exists(tempFilePdf)) File.Delete(tempFilePdf);
        }
    }

    private static (byte[] pdfFile, string error) Execute(string arguments, string tempFilePdf)
    {
        arguments = "-q " + arguments.Trim();

        using var process = CreateProcess(arguments);
        process.Start();
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit();

#if DEBUG
        Console.WriteLine(error);
#endif

        using var ms = new MemoryStream();
        using var fileStream = new FileStream(tempFilePdf, FileMode.Open, FileAccess.Read);
        fileStream.CopyTo(ms);

        if (ms.Length == 0) throw new Exception(error);

        return (ms.ToArray(), error);
    }

    private static Process CreateProcess(string arguments)
    {
#if DEBUG
        Console.WriteLine(arguments);
#endif
        
        var wkhtmltopdfFilePath = WkHtmlToPdfFile.GetFilePath();
        var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = wkhtmltopdfFilePath,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        return process;
    }

    private static string EscapeNonAsciiCharacters(string html)
    {
        var escaped = new StringBuilder(html.Length + (int)(html.Length * 0.1));
        foreach (var c in html)
        {
            if (c > 127) escaped.AppendFormat("&#{0};", c);
            else escaped.Append(c);
        }
        return escaped.ToString();
    }
}