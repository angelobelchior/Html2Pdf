namespace Html2Pdf.Lib;

internal static class WkHtmlToPdfFile
{
    private static readonly object _lock = new();
    private static string _wkhtmltopdfFilePath = string.Empty;

    public static string GetFilePath()
    {
        if (!string.IsNullOrEmpty(_wkhtmltopdfFilePath))
            return _wkhtmltopdfFilePath;

        const string wkhtmltopdf = "wkhtmltopdf";

        var folderPath = AppContext.BaseDirectory;
        folderPath = Path.Combine(folderPath, wkhtmltopdf);

        var wkhtmltopdfFilePath = wkhtmltopdf;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            wkhtmltopdfFilePath = Path.Combine(folderPath, "Windows", $"{wkhtmltopdf}.exe");
            if (!File.Exists(wkhtmltopdfFilePath))
                throw new FileNotFoundException($"{wkhtmltopdfFilePath} not found");
        }

        _wkhtmltopdfFilePath = wkhtmltopdfFilePath;
        return _wkhtmltopdfFilePath;
    }
}