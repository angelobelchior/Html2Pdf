namespace Html2Pdf.Lib;

public partial class Html2PdfConverter
{
    /// <summary>
    /// Set the starting page number (default 0)
    /// </summary>
    /// <param name="offset">Page offset</param>
    /// <returns></returns>
    public Html2PdfConverter SetOffPageOffset(uint offset)
    {
        _arguments.Append($" --page-offset {offset}");
        return this;
    }

    /// <summary>
    /// Sets the page margins
    /// </summary>
    /// <param name="top">Margin Top</param>
    /// <param name="right">Margin Right</param>
    /// <param name="bottom">Margin Bottom</param>
    /// <param name="left">Margins Left</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetPageMargins(int top, int right, int bottom, int left)
    {
        _arguments.Append($" --margin-bottom {bottom}");
        _arguments.Append($" --margin-left {left}");
        _arguments.Append($" --margin-right {right}");
        _arguments.Append($" --margin-top {top}");
        return this;
    }

    /// <summary>
    /// Sets the page margins
    /// </summary>
    /// <param name="all">Margin All</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetPageMargins(int all)
        => SetPageMargins(all, all, all, all);

    /// <summary>
    /// Sets the page margins
    /// </summary>
    /// <param name="topAndBottom">Margin Top and Bottom</param>
    /// <param name="rightAndLeft">Margin Right and Left</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetPageMargins(int topAndBottom, int rightAndLeft)
        => SetPageMargins(topAndBottom, rightAndLeft, topAndBottom, rightAndLeft);

    /// <summary>
    /// Sets the page Width
    /// </summary>
    /// <param name="pageWidth">Page Width in mm</param>
    /// <remarks>Has priority over <see cref="SetPageSize"/> but <see cref="SetPageHeight"/> has to be also specified.</remarks>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetPageWidth(double pageWidth)
    {
        _arguments.Append($" --page-width {pageWidth}");
        return this;
    }

    /// <summary>
    /// Sets the page Height
    /// </summary>
    /// <param name="pageHeight">Page Width in mm</param>
    /// <remarks>Has priority over <see cref="SetPageSize"/> but <see cref="SetPageWidth"/> has to be also specified.</remarks>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetPageHeight(double pageHeight)
    {
        _arguments.Append($" --page-height {pageHeight}");
        return this;
    }

    /// <summary>
    /// Set the page Orientation
    /// </summary>
    /// <param name="pageOrientation">Page Orientation</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetPageOrientation(PageOrientation pageOrientation)
    {
        _arguments.Append($" -O {pageOrientation}");
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageSize"></param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetPageSize(PageSize pageSize)
    {
        _arguments.Append($" -s {pageSize}");
        return this;
    }

    /// <summary>
    /// Disable SmartSets the page size.
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter DisableSmartShrinking()
    {
        _arguments.Append(" --disable-smart-shrinking");
        return this;
    }

    /// <summary>
    /// Turn HTML form fields into pdf form fields
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter EnableForms()
    {
        _arguments.Append(" --enable-forms");
        return this;
    }
}