// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

namespace Html2PdfLib
{
    /// <summary>
    /// Fluent interface commands to create instance of Html2Pdf  
    /// </summary>
    public interface ICommandsSourcesHtml2Pdf
    {
        /// <summary>
        /// Set the html to convert to PDF
        /// </summary>
        /// <param name="value">html source</param>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        ICommandsBehaviorConvert FromHtml(string value);

        /// <summary>
        /// Set the url to convert to PDF
        /// </summary>
        /// <param name="value">url source</param>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        ICommandsBehaviorConvert FromUrl(Uri value);

        /// <summary>
        /// Set razor template to convert to PDF
        /// </summary>
        /// <param name="template">Razor Template source</param>
        /// <param name="model">Data to apply to the template</param>
        /// <typeparam name="T">Typeof data</typeparam>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        ICommandsBehaviorConvert FromRazorTemplate<T>(string template, T model);
    }
}
