// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using Html2PdfLib.core;
using RazorEngineCore;

namespace Html2PdfLib
{
    /// <summary>
    /// Html to PDF converter
    /// </summary>
    public static class Html2Pdf
    {
        /// <summary>
        /// Content Type
        /// </summary>
        public static string ContentType => "application/pdf"; 

        private static readonly OptionsPdf _globaloptions;
        /// <summary>
        /// Init Html2Pdf
        /// </summary>
        static Html2Pdf()
        {
            //try Load User (or default values) Setting from file Html2PdfGlobalConfig.json
            _globaloptions = TryLoadUserSetting();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  static ICommandsSourcesHtml2Pdf Config(Action<IOptionsPdf>? value = null)
        {
            var aux = DeepCopy<OptionsPdf>(_globaloptions);
            value?.Invoke(aux);
            return new InstanceConverter(aux);
        }

        /// <summary>
        /// Set the html to convert to PDF
        /// </summary>
        /// <param name="value">html source</param>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        public static ICommandsBehaviorConvert FromHtml(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            _globaloptions.Source = value;
            return new InstanceConverter(_globaloptions);
        }

        /// <summary>
        /// Set the url to convert to PDF
        /// </summary>
        /// <param name="value">url source</param>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        public static ICommandsBehaviorConvert FromUrl(Uri value)
        {
            _globaloptions.Source = value.ToString();
            _globaloptions.IsUrisource = true;  
            return new InstanceConverter(_globaloptions);
        }

        /// <summary>
        /// Set razor template to convert to PDF
        /// </summary>
        /// <param name="template">Razor Template source</param>
        /// <param name="model">Data to apply to the template</param>
        /// <typeparam name="T">Typeof data</typeparam>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        public static ICommandsBehaviorConvert FromRazorTemplate<T>(string template, T model)
        {
            if (string.IsNullOrEmpty(template))
            {
                throw new ArgumentNullException(nameof(template), "Template is required");
            }
            _globaloptions.Source = RazorHelpper.CompileTemplate(template, model);
            return new InstanceConverter(_globaloptions);
        }

        private static OptionsPdf TryLoadUserSetting()
        {
            var result = new OptionsPdf();
            const string UserSettingFileConfig = "Html2PdfGlobalConfig.json";
            var folderPath = Path.Combine(AppContext.BaseDirectory, UserSettingFileConfig);
            Html2PdfGlobalConfig userseeting;
            if (File.Exists(folderPath))
            {
                userseeting = JsonSerializer.Deserialize<Html2PdfGlobalConfig>(File.ReadAllText(folderPath))!;
            }
            else
            {
                userseeting = new Html2PdfGlobalConfig();

            }
            var defaultusersvalues = new Html2PdfGlobalConfig();

            result.Copies(userseeting.Copies ?? defaultusersvalues.Copies!.Value);
            result.DisableExternalLinks(userseeting.DisableExternalLinks ?? defaultusersvalues.DisableExternalLinks!.Value);
            result.DisableInternalLinks(userseeting.DisableInternalLinks ?? defaultusersvalues.DisableInternalLinks!.Value);
            result.DisableSmartShrinking(userseeting.DisableSmartShrinking ?? defaultusersvalues.DisableSmartShrinking!.Value);
            result.EnableForms(userseeting.EnableForms ?? defaultusersvalues.EnableForms!.Value);
            var spacing = userseeting.FooterSpacing ?? defaultusersvalues.FooterSpacing;
            if (spacing.HasValue)
            {
                result.FooterSpacing(spacing.Value);
            }
            spacing = userseeting.HeaderSpacing ?? defaultusersvalues.HeaderSpacing;
            if (spacing.HasValue)
            {
                result.HeaderSpacing(spacing.Value);
            }
            result.FooterFont(
                userseeting.FooterFontName ?? defaultusersvalues.FooterFontName!,
                userseeting.FooterFontSize ?? defaultusersvalues.FooterFontSize!.Value);
            result.HasFooterLine(userseeting.HasFooterLine ?? defaultusersvalues.HasFooterLine!.Value);
            result.HasHeaderLine(userseeting.HasHeaderLine ?? defaultusersvalues.HasHeaderLine!.Value);
            result.HeaderFont(
                    userseeting.HeaderFontName ?? defaultusersvalues.HeaderFontName!,
                    userseeting.HeaderFontSize ?? defaultusersvalues.HeaderFontSize!.Value);
            result.ImageQuality(userseeting.ImageQualit ?? defaultusersvalues.ImageQualit!.Value);
            result.LoadOrPrintImages(userseeting.LoadOrPrintImages ?? defaultusersvalues.LoadOrPrintImages!.Value);
            result.PageMargins(
                userseeting.PageMarginsTop ?? defaultusersvalues.PageMarginsTop!.Value,
                userseeting.PageMarginsRight ?? defaultusersvalues.PageMarginsRight!.Value,
                userseeting.PageMarginsBottom ?? defaultusersvalues.PageMarginsBottom!.Value,
                userseeting.PageMarginsLeft ?? defaultusersvalues.PageMarginsLeft!.Value);
            result.PageOffset(userseeting.PageOffset ?? defaultusersvalues.PageOffset!.Value);
            result.PageOrientation(
                userseeting.PageOrientation != null
                    ? Enum.Parse<PageOrientation>(userseeting.PageOrientation)
                    : Enum.Parse<PageOrientation>(defaultusersvalues.PageOrientation!));
            result.PageSize(
                userseeting.PageSize != null
                    ? Enum.Parse<PageSize>(userseeting.PageSize)
                    : Enum.Parse<PageSize>(defaultusersvalues.PageSize!));
            result.PdfCompression(userseeting.PdfCompression ?? defaultusersvalues.PdfCompression!.Value);
            result.PrintBackground(userseeting.PrintBackground ?? defaultusersvalues.PrintBackground!.Value);
            result.LoadOrPrintImages(userseeting.LoadOrPrintImages ?? defaultusersvalues.LoadOrPrintImages!.Value);
            result.WithLowQuality(userseeting.WithLowQuality ?? defaultusersvalues.WithLowQuality!.Value);
            result.Timeout = userseeting.Timeout ?? defaultusersvalues.Timeout!.Value;
            result.IgnoreImageErrors = userseeting.IgnoreImageErrors ?? defaultusersvalues.IgnoreImageErrors!.Value;
            result.LogArguentsInfoLevel = userseeting.LogArguentsInfoLevel ?? defaultusersvalues.LogArguentsInfoLevel!.Value;
            return result;
        }
        private static T DeepCopy<T>(T other) => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(other))!;

    }
}
