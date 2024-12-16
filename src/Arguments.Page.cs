namespace Html2Pdf.Lib;

public partial class Arguments
{
    /// <summary>
    /// Set the starting page number (default 0)
    /// </summary>
    /// <param name="offset">Page offset</param>
    /// <returns></returns>
    public Arguments SetOffPageOffset(uint offset)
        => AppendArgument("--page-offset", offset);

    /// <summary>
    /// Sets the page margins
    /// </summary>
    /// <param name="top">Margin Top</param>
    /// <param name="right">Margin Right</param>
    /// <param name="bottom">Margin Bottom</param>
    /// <param name="left">Margins Left</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetPageMargins(int top, int right, int bottom, int left)
    {
        AppendArgument("--margin-bottom", bottom);
        AppendArgument("--margin-left", left);
        AppendArgument("--margin-right", right);
        AppendArgument("--margin-top", top);
        return this;
    }

    /// <summary>
    /// Sets the page margins
    /// </summary>
    /// <param name="all">Margin All</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetPageMargins(int all)
        => SetPageMargins(all, all, all, all);

    /// <summary>
    /// Sets the page margins
    /// </summary>
    /// <param name="topAndBottom">Margin Top and Bottom</param>
    /// <param name="rightAndLeft">Margin Right and Left</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetPageMargins(int topAndBottom, int rightAndLeft)
        => SetPageMargins(topAndBottom, rightAndLeft, topAndBottom, rightAndLeft);

    /// <summary>
    /// Sets the page Width
    /// </summary>
    /// <param name="pageWidth">Page Width in mm</param>
    /// <remarks>Has priority over <see cref="SetPageSize"/> but <see cref="SetPageHeight"/> has to be also specified.</remarks>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetPageWidth(double pageWidth)
        => AppendArgument("--page-width", pageWidth);

    /// <summary>
    /// Sets the page Height
    /// </summary>
    /// <param name="pageHeight">Page Width in mm</param>
    /// <remarks>Has priority over <see cref="SetPageSize"/> but <see cref="SetPageWidth"/> has to be also specified.</remarks>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetPageHeight(double pageHeight)
        => AppendArgument("--page-height", pageHeight);

    /// <summary>
    /// Set the page Orientation
    /// </summary>
    /// <param name="pageOrientation">Page Orientation</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetPageOrientation(PageOrientation pageOrientation)
        => AppendArgument("--orientation", pageOrientation);

    /// <summary>
    /// The default page size of the rendered document is A4.
    /// </summary>
    /// <param name="pageSize"><see cref="PageSize">Page Size</see></param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetPageSize(PageSize pageSize)
        => AppendArgument("--page-size", pageSize);

    /// <summary>
    /// Disable SmartSets the page size.
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments DisableSmartShrinking()
        => AppendArgument("--disable-smart-shrinking");

    /// <summary>
    /// Turn HTML form fields into pdf form fields
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments EnableForms()
        => AppendArgument("--enable-forms");
}