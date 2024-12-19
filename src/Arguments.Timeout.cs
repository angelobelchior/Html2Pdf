namespace Html2Pdf.Lib;
public partial class Arguments
{
    internal const int DefaultTimeout = 30000;

    private int _timeoutconvert = DefaultTimeout;

    /// <summary>
    /// Set timeout in milliseconds for PDF conversion. Default Value is 30000.
    /// The minimum value is 500, if the value is less than this value it will be changed to the minimum value.
    /// </summary>
    /// <param name="value">interface for log provider</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments TimeoutConvert(int value)
    {
        if (value < 500)
        { 
            value = 500;
        }
        _timeoutconvert = value;
        return this;
    }


    internal int GetTimeout() => _timeoutconvert;
}

