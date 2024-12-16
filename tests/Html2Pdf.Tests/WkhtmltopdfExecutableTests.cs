using System.Diagnostics;
using Html2Pdf.Lib;

namespace Html2Pdf.Tests;

public class WkhtmltopdfExecutableTests
{
    [Fact]
    public void TheBuildProcessMustCopyWkhtmltopdfFileToOutputDirectory()
    {
        var wkhtmltopdfFilePath = WkHtmlToPdfFile.GetFilePath();
        Assert.True(File.Exists(wkhtmltopdfFilePath));
    }
    
#if DEBUG
    /// <summary>
    /// This test is only for debug mode, because it's not possible run the executable into a GitHub Action.
    /// Here we are testing if the ./[Operating System Name]/wkhtmltopdf file is executable for development purposes.
    /// ---
    /// To run on macOS or Linux machines, you need to execute the chmod +x ./[Operating System Name]/wkhtmltopdf command to change the file permissions.
    /// Additionally, because the compilation process copies the executable files to a folder named after the operating system,
    /// it is necessary to run the umask 0022 command to ensure that the copied executable retains the correct permissions.
    /// ---
    /// If you are developing on a Windows machine, you need to run Visual Studio in Administrator mode.
    /// In some cases, it will be necessary to perform the following steps:
    /// - Right-click on the file ./Windows/wkhtmltopdf.exe
    /// - Go to "Properties," click on the "Compatibility" tab
    /// - Then click "Change settings for all users"
    /// - And check the option "Run this program as an administrator.
    /// </summary>
    [Fact]
    public void TheWkhtmltopdfFileMustBeExecutable()
    {
        var wkhtmltopdfFilePath = WkHtmlToPdfFile.GetFilePath();
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