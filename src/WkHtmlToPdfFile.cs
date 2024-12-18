namespace Html2Pdf.Lib;

internal static class WkHtmlToPdfFile
{
    private static readonly object _lock = new();
    private static string _wkhtmltopdfFilePath = string.Empty;
    public static string GetFilePath()
    {
        lock (_lock)
        {
            if (!string.IsNullOrEmpty(_wkhtmltopdfFilePath))
                return _wkhtmltopdfFilePath;
        }

        const string wkhtmltopdf = "wkhtmltopdf";

        var folderPath = AppContext.BaseDirectory;
        folderPath = Path.Combine(folderPath, wkhtmltopdf);

        string wkhtmltopdfFilePath;
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            wkhtmltopdfFilePath = Path.Combine(folderPath, "Windows", $"{wkhtmltopdf}.exe");
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            wkhtmltopdfFilePath = Path.Combine(folderPath, "Mac", wkhtmltopdf);
        else
            wkhtmltopdfFilePath = Path.Combine(folderPath, "Linux", wkhtmltopdf);
        
        lock (_lock)
            _wkhtmltopdfFilePath = wkhtmltopdfFilePath;

        if (!File.Exists(_wkhtmltopdfFilePath))
            throw new FileNotFoundException($"{_wkhtmltopdfFilePath} not found");

        return _wkhtmltopdfFilePath;
    }
}