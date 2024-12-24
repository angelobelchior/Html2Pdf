using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace Html2PdfLib.core
{
    internal static class WkHtmlToPdfHelpper
    {
        public static string GetFilePath()
        {
            const string wkhtmltopdf = "wkhtmltopdf";

            //must be instaled wkhtmltopdf in S.O when not OSPlatform.Windows
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return wkhtmltopdf;

            var folderPath = AppContext.BaseDirectory;
            folderPath = Path.Combine(folderPath, wkhtmltopdf);

            var wkhtmltopdfFilePath = Path.Combine(folderPath, "Windows", $"{wkhtmltopdf}.exe");
            if (!File.Exists(wkhtmltopdfFilePath))
                throw new FileNotFoundException($"{wkhtmltopdfFilePath} not found");

            return wkhtmltopdfFilePath;
        }

        public static async Task<(byte[] pdfFile, string error)> ExecuteAsyc(
            OptionsPdf optionsPdf,
            string filehml,
            string filePdf, 
            bool istmpfile,
            bool accessbytes,
            CancellationToken token)
        {
            var arguments = $"-q {optionsPdf.ToString().Trim()} \"{filehml}\" \"{filePdf}\"";

            if (optionsPdf.LogArgumentsInfoLevel)
            {
                optionsPdf.LogInstance?.LogInformation("{exe} {arg}",GetFilePath(),arguments);
            }
            else
            {
                optionsPdf.LogInstance?.LogDebug("{exe} {arg}", GetFilePath(), arguments);
            }

            int exitCode = -1;
            var stdErrBuffer = new StringBuilder();

            using (var cts = new CancellationTokenSource())
            {
                cts.CancelAfter(optionsPdf.Timeout);
                using var linkcts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);
                try
                {
                    CommandResult? cmd = await Cli.Wrap(GetFilePath())
                        .WithArguments(arguments)
                        .WithValidation(CommandResultValidation.None)
                        .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
                        .ExecuteAsync(linkcts.Token);
                    exitCode = cmd.ExitCode;
                }
                catch
                {
                }
            }
            var stdErr = stdErrBuffer.ToString();
            //error render image
            if (exitCode != 0 && optionsPdf.IgnoreImageErrors)
            {
                var cnt = 0;
                var lines = stdErr.Split(Environment.NewLine,StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    cnt++;
                    if (line.Equals("libpng warning: IDAT: ADLER32 checksum mismatch"))
                    {
                        cnt--;
                    }
                    else if (line.Equals("libpng error: IDAT: CRC error"))
                    {
                        cnt--;
                    }
                    else if (line.Equals("Exit with code 1 due to network error: ProtocolUnknownError"))
                    {
                        cnt--;
                    }
                }
                if (cnt == 0)
                {
                    exitCode = 0;
                    stdErr = string.Empty;
                }
            }

            if (exitCode != 0)
            {
                optionsPdf.LogInstance?.LogError(new Exception(stdErr), "Html2Pdf.Lib Execute exitcode({exitcode}) for file {filePdf}", exitCode, filePdf);
            }
            if (!File.Exists(filePdf) || exitCode != 0 || !istmpfile)
            {
                if (!accessbytes)
                {
                    return (Array.Empty<byte>(), stdErr);
                }
            }
            //only for tmp PDF file or accessbytes
            using var ms = new MemoryStream();
            using var fileStream = new FileStream(filePdf, FileMode.Open, FileAccess.Read);
            fileStream.CopyTo(ms);
            return (ms.ToArray(), string.Empty);
        }
    }
}
