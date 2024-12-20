using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Html2Pdf.Lib;

internal static class WkHtmlToPdfFile
{
    private static readonly string _wkhtmltopdfFilePath;

    static WkHtmlToPdfFile()
    {
        const string wkhtmltopdf = "wkhtmltopdf";

        var folderPath = AppContext.BaseDirectory;
        folderPath = Path.Combine(folderPath, wkhtmltopdf);

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            _wkhtmltopdfFilePath = Path.Combine(folderPath, "Windows", $"{wkhtmltopdf}.exe");
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            _wkhtmltopdfFilePath = Path.Combine(folderPath, "Mac", wkhtmltopdf);
        else
            _wkhtmltopdfFilePath = Path.Combine(folderPath, "Linux", wkhtmltopdf);

        if (!File.Exists(_wkhtmltopdfFilePath))
            throw new FileNotFoundException($"{_wkhtmltopdfFilePath} not found");
    }

    public static string GetFilePath() => _wkhtmltopdfFilePath;
}