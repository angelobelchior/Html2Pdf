using Microsoft.Extensions.Logging;

namespace Html2Pdf.Lib;
public partial class Arguments
{
    private ILogger? _log;


    /// <summary>
    /// Set interface for log provider
    /// </summary>
    /// <param name="value">interface for log provider</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments AddLogger(ILogger value)
    {
        _log = value;
        return this;
    }

    /// <summary>
    /// Return interface for log
    /// </summary>
    /// <returns> interface for log provider. <see cref="ILogger"/> </returns>
    internal ILogger? GetLogger() => _log;
}

