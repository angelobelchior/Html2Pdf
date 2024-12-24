// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

using System.Diagnostics;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Html2PdfLib.core
{
    internal class InstanceConverter(OptionsPdf optionsPdf) : ICommandsBehaviorConvert, ICommandsSourcesHtml2Pdf
    {
        private readonly OptionsPdf _optionsPdf = optionsPdf;
        public ICommandsBehaviorConvert FromHtml(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "HTML Source is required");
            }
            _optionsPdf.Source = value;
            return this;
        }

        public ICommandsBehaviorConvert FromRazorTemplate<T>(string template, T model)
        {
            if (string.IsNullOrEmpty(template))
            {
                throw new ArgumentNullException(nameof(template), "Template is required");
            }
            _optionsPdf.Source = RazorHelpper.CompileTemplate(template, model);
            return this;
        }


        public ICommandsBehaviorConvert IgnoreImageErrors(bool value)
        {
            _optionsPdf.IgnoreImageErrors = value;
            return this;
        }

        public ICommandsBehaviorConvert FromUrl(Uri value)
        {
            _optionsPdf.Source = value.ToString();
            _optionsPdf.IsUrisource = true;
            return this;
        }

        public ICommandsBehaviorConvert Logger(ILogger value)
        {
            _optionsPdf.LogInstance = value;
            return this;
        }

        public ICommandsBehaviorConvert TimeoutConvert(ushort value)
        {
            if (value < 500)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The minimum value must be greater than or equal to 500");
            }
            _optionsPdf.Timeout = value;
            return this;
        }

        public ICommandsBehaviorConvert LogArguentsInfoLevel(bool value)
        {
            _optionsPdf.LogArguentsInfoLevel = value;
            return this;
        }

        public async Task<Html2PdfResult> RunAsync(CancellationToken token = default)
        {
            if (string.IsNullOrEmpty(_optionsPdf.Source))
            {
                throw new InvalidOperationException("The source Html/Url was not defined");
            }
            var tempFile = Guid.NewGuid();
            var tempFileHtml = _optionsPdf.IsUrisource?_optionsPdf.Source:$"{tempFile}.html";
            var filePdf = $"{tempFile}.pdf";

            Html2PdfResult result;
            var sw = Stopwatch.StartNew();
            try
            {
                if (!_optionsPdf.IsUrisource)
                {
                    await File.WriteAllTextAsync(tempFileHtml, _optionsPdf.Source,token);
                }

                (var bytesFile, var error) = await WkHtmlToPdfHelpper.ExecuteAsyc(_optionsPdf, tempFileHtml, filePdf, true, true,token);

                result = new Html2PdfResult(sw.Elapsed, bytesFile, null, string.IsNullOrEmpty(error) ? null : new Exception(error));
            }
            catch (OperationCanceledException e)
            {
                _optionsPdf.LogInstance?.LogError(e, "Html2Pdf.Lib: Operation Canceled ConvertFromHtml");
                result = new Html2PdfResult(sw.Elapsed, null, null, e);
            }
            catch (Exception e)
            {
                _optionsPdf.LogInstance?.LogError(e, "Html2Pdf.Lib: Error ConvertFromHtml");
                result = new Html2PdfResult(sw.Elapsed, null, null, e);
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
                        _optionsPdf.LogInstance?.LogError(e, "Html2Pdf.Lib ConvertFromHtml: cannot remove tmpfile : {tmp}", tempFileHtml);
                        result = new Html2PdfResult(sw.Elapsed, null, null, e);
                    }
                }
                if (File.Exists(filePdf))
                {
                    try
                    {
                        File.Delete(filePdf);
                    }
                    catch (Exception e)
                    {
                        _optionsPdf.LogInstance?.LogError(e, "Html2Pdf.Lib ConvertFromHtml: cannot remove tmpfile : {tmp}", filePdf);
                        result = new Html2PdfResult(sw.Elapsed, null, null, e);
                    }
                }
            }
            return result;
        }

        public async Task<Html2PdfResult> SaveToAsync(string value, bool accessbytes = false, CancellationToken token = default)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(value, "The file name is required");
            }
            if (string.IsNullOrEmpty(_optionsPdf.Source))
            {
                throw new InvalidOperationException("The source Html/rlrequired");
            }
            var tempFile = Guid.NewGuid();
            var tempFileHtml = _optionsPdf.IsUrisource ? _optionsPdf.Source : $"{tempFile}.html";
            var filePdf = value;
            if (!filePdf.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
            {
                filePdf += ".pdf";
            }

            Html2PdfResult result;
            var sw = Stopwatch.StartNew();
            try
            {
                if (!_optionsPdf.IsUrisource)
                {
                    await File.WriteAllTextAsync(tempFileHtml, _optionsPdf.Source, token);
                }

                (var bytesFile, var error) = await WkHtmlToPdfHelpper.ExecuteAsyc(_optionsPdf, tempFileHtml, filePdf, false, accessbytes, token);

                result = new Html2PdfResult(sw.Elapsed, bytesFile, filePdf, string.IsNullOrEmpty(error) ? null : new Exception(error));
            }
            catch (OperationCanceledException e)
            {
                _optionsPdf.LogInstance?.LogError(e, "Html2Pdf.Lib: Operation Canceled SaveToAsync");
                result = new Html2PdfResult(sw.Elapsed, null, null, e);
            }
            catch (Exception e)
            {
                _optionsPdf.LogInstance?.LogError(e, "Html2Pdf.Lib: Error SaveToAsync");
                result = new Html2PdfResult(sw.Elapsed, null, null, e);
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
                        _optionsPdf.LogInstance?.LogError(e, "Html2Pdf.Lib SaveToAsync: cannot remove tmpfile : {tmp}", tempFileHtml);
                        result = new Html2PdfResult(sw.Elapsed, null, null, e);
                    }
                }
            }
            return result;
        }
    }
}
