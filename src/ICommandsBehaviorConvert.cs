// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace Html2PdfLib
{
    /// <summary>
    /// Fluent interface commands to behavior convert of Html2Pdf  
    /// </summary>
    public interface ICommandsBehaviorConvert
    {
        /// <summary>
        /// Set timeout convert (defaut 30000ms and min.value 500ms) 
        /// </summary>
        /// <param name="value">timeout convert in milleseconds value</param>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        ICommandsBehaviorConvert TimeoutConvert(ushort value);

        /// <summary>
        /// Set Logger integration
        /// </summary>
        /// <param name="value"><see cref="ILogger"/> instance</param>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        ICommandsBehaviorConvert Logger(ILogger value);

        /// <summary>
        /// Set to Ignore image errors (Default false)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="ICommandsBehaviorConvert"/> next commands</returns>
        ICommandsBehaviorConvert IgnoreImageErrors(bool value);

        /// <summary>
        /// Execute convert to PDF file
        /// </summary>
        /// <param name="value">file name</param>
        /// <param name="token"><see cref="CancellationToken"/> token</param>
        /// <param name="accessbytes">if true return PDF in bytes</param>
        /// <returns>Result of convet. <see cref="Html2PdfResult"/></returns>
        Task<Html2PdfResult> SaveToAsync(string value, bool accessbytes = false, CancellationToken token = default);

        /// <summary>
        /// Execute convert to bytes PDF
        /// </summary>
        /// <param name="token"><see cref="CancellationToken"/> token</param>
        /// <returns>Result of convet. <see cref="Html2PdfResult"/></returns>
        Task<Html2PdfResult> RunAsync(CancellationToken token = default);
    }
}