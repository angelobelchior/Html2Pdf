namespace Html2Pdf.Lib;

internal static class WkHtmlToPdfFile
{
    public static string GetFilePath()
    {
        const string wkhtmltopdf = "wkhtmltopdf";

        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return wkhtmltopdf;
        
        var folderPath = AppContext.BaseDirectory;
        folderPath = Path.Combine(folderPath, wkhtmltopdf);
        
        var wkhtmltopdfFilePath = Path.Combine(folderPath, "Windows", $"{wkhtmltopdf}.exe");
        if (!File.Exists(wkhtmltopdfFilePath))
            throw new FileNotFoundException($"{wkhtmltopdfFilePath} not found");

        return wkhtmltopdfFilePath;
    }
}