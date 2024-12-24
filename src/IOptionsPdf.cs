// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

namespace Html2PdfLib
{
    /// <summary>
    /// Converter Arguments options to PDF file
    /// </summary>
    public interface IOptionsPdf
    {
        #region Documents options

        /// <summary>
        /// When jpeg compressing images use this quality (default 94)
        /// </summary>
        /// <param name="value">Image quality</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf ImageQuality(byte value);


        /// <summary>
        /// Print background (default true)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PrintBackground(bool value = true);

        /// <summary>
        /// Load or print images (default true)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf LoadOrPrintImages(bool value = true);

        /// <summary>
        /// Use lossless compression on pdf objects (default false)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PdfCompression(bool value = true);

        /// <summary>
        /// Do not make links to remote web pages (default true)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf DisableExternalLinks(bool value = true);

        /// <summary>
        /// Do not make local links (default true)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf DisableInternalLinks(bool value = true);

        /// <summary>
        /// The title of the generated pdf file (The title of the first document is used if not specified)
        /// </summary>
        /// <param name="value">title of document</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf Title(string value);

        /// <summary>
        /// Indicates whether the PDF should be generated in lower quality. (default true)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf WithLowQuality(bool value = true);

        /// <summary>
        /// Number of copies to print into the PDF file. (default 1)
        /// </summary>
        /// <param name="value">Number of copies to print</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf Copies(byte value);

        /// <summary>
        /// Indicates whether the PDF should be generated in grayscale. (default true)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf GrayScale(bool value = true);

        /// <summary>
        /// Replace [name] with value in header and footer (repeatable)
        /// </summary>
        /// <param name="from">text to find</param>
        /// <param name="to">text to replace</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf Replace(string from, string to);

        #endregion

        #region Footer options

        /// <summary>
        /// Spacing between footer and content in mm. (default none)
        /// </summary>
        /// <param name="value">footer spacing value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf FooterSpacing(double value);

        /// <summary>
        /// write line above the footer (false)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf HasFooterLine(bool value = true);

        /// <summary>
        /// Footer text (Default none)
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="alignment"><see cref="TextAlignment">Text Alignment</see></param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf FooterText(string text, TextAlignment alignment);

        /// <summary>
        /// Footer font (default Arial 10)
        /// </summary>
        /// <param name="fontName">Font Name</param>
        /// <param name="fontSize">Font Size</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf FooterFont(string fontName, byte fontSize);

        #endregion

        #region Header options

        /// <summary>
        ///  Spacing between header and content in mm (default none)
        /// </summary>
        /// <param name="value">header spacing value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf HeaderSpacing(double value);

        /// <summary>
        /// write line above the header (false)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf HasHeaderLine(bool value);

        /// <summary>
        /// Header text (Default none)
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="alignment"><see cref="TextAlignment">Text Alignment</see></param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf HeaderText(string text, TextAlignment alignment);

        /// <summary>
        /// Header font (default Arial 14)
        /// </summary>
        /// <param name="fontName">Font Name</param>
        /// <param name="fontSize">Font Size</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf HeaderFont(string fontName, byte fontSize);

        #endregion

        #region Page options

        /// <summary>
        /// Set the starting page number (default 1)
        /// </summary>
        /// <param name="value">Page offset</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PageOffset(byte value);

        /// <summary>
        /// Sets the page margins (default 10 for left/right 0 for top/bottom)
        /// </summary>
        /// <param name="top">Margin Top</param>
        /// <param name="right">Margin Right</param>
        /// <param name="bottom">Margin Bottom</param>
        /// <param name="left">Margins Left</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PageMargins(int top, int right, int bottom, int left);

        /// <summary>
        /// Sets the page margins (default 10 for left/right 0 for top/bottom)
        /// </summary>
        /// <param name="value">All Margin Top,left,right,bottom</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PageMargins(int value);

        /// <summary>
        /// Sets the page margins (default 10 for left/right 0 for top/bottom)
        /// </summary>
        /// <param name="topAndBottom">Margin Top and Bottom</param>
        /// <param name="rightAndLeft">Margin Right and Left</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PageMargins(int topAndBottom, int rightAndLeft);

        /// <summary>
        /// Sets the page Width (default <see cref="PageSize"/>)
        /// </summary>
        /// <param name="value">Page Width in mm</param>
        /// <remarks>Has priority over <see cref="PageSize"/>.</remarks>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PageWidth(double value);

        /// <summary>
        /// Sets the page Height (default <see cref="PageSize"/>)
        /// </summary>
        /// <param name="value">Page Width in mm</param>
        /// <remarks>Has priority over <see cref="PageSize"/>.</remarks>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PageHeight(double value);

        /// <summary>
        /// The default page size of the rendered document (default A4).
        /// </summary>
        /// <param name="value"><see cref="PageSize">Page Size</see></param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PageSize(PageSize value);


        /// <summary>
        /// Set the page Orientation (default Portrait)
        /// </summary>
        /// <param name="value">Page Orientation</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf PageOrientation(PageOrientation value);

        /// <summary>
        /// Disable SmartSets the page size (default true)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf DisableSmartShrinking(bool value);

        /// <summary> 
        /// Turn HTML form fields into pdf form fields (default false)
        /// </summary>
        /// <param name="value">true/false value</param>
        /// <returns><see cref="IOptionsPdf"/> instance</returns>
        IOptionsPdf EnableForms(bool value);

        #endregion

    }
}
