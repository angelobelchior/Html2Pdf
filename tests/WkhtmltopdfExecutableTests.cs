using System.Diagnostics;
using System.Runtime.InteropServices;
using Html2PdfLib.core;

namespace Html2Pdf.Tests;

public class WkhtmltopdfExecutableTests
{

    [Fact]
    public void TheBuildProcessMustCopyWkhtmltopdfFileToOutputDirectory()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var wkhtmltopdfFilePath = WkHtmlToPdfHelpper.GetFilePath();
            Assert.True(File.Exists(wkhtmltopdfFilePath));
        }

        Assert.True(true);
    }
   
#if DEBUG    
    [Fact]
    public void TheWkhtmltopdfFileMustBeExecutable()
    {
        var wkhtmltopdfFilePath = WkHtmlToPdfHelpper.GetFilePath();
        using var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = wkhtmltopdfFilePath,
            Arguments = " --version",
            UseShellExecute = false,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };
        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        Assert.False(string.IsNullOrEmpty(output));
    }
#endif
}