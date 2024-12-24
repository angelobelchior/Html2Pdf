// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

namespace Html2PdfLib
{
    /// <summary>
    /// HTML to PDF converter global configuration with default values
    /// </summary>
    public class Html2PdfGlobalConfig
    {
        #region Documents options

        /// <summary>
        /// When jpeg compressing images use this quality (default 94)
        /// </summary>
        public byte? ImageQualit { get; set; } = 94;

        /// <summary>
        /// Print background (default true)
        /// </summary>
        public bool? PrintBackground { get; set; } = true;

        /// <summary>
        /// Load or print images (default true)
        /// </summary>
        public bool? LoadOrPrintImages { get; set; } = true;

        /// <summary>
        /// Use lossless compression on pdf objects (default false)
        /// </summary>
        public bool? PdfCompression { get; set; } = false;

        /// <summary>
        /// Do not make links to remote web pages (default true)
        /// </summary>
        public bool? DisableExternalLinks { get; set; } = true;

        /// <summary>
        /// Do not make local links (default true)
        /// </summary>
        public bool? DisableInternalLinks { get; set; } = true;

        /// <summary>
        /// Indicates whether the PDF should be generated in lower quality. (default true)
        /// </summary>
        public bool? WithLowQuality { get; set; } = true;

        /// <summary>
        /// Number of copies to print into the PDF file. (default 1)
        /// </summary>
        public byte? Copies { get; set; } = 1;

        /// <summary>
        /// Indicates whether the PDF should be generated in grayscale. (default false)
        /// </summary>
        public bool? GrayScale { get; set; } = false;

        #endregion

        #region Footer options

        /// <summary>
        /// Spacing between footer and content in mm. (default none)
        /// </summary>
        public double? FooterSpacing { get; set; } = null;

        /// <summary>
        /// write line above the footer (false)
        /// </summary>
        public bool? HasFooterLine { get; set; } = false;

        /// <summary>
        /// Footer font name (default Arial)
        /// </summary>
        public string? FooterFontName { get; set; } = "Arial";

        /// <summary>
        /// Footer font size (default 10)
        /// </summary>
        public byte?  FooterFontSize { get; set; } = 10;

        #endregion

        #region Header options

        /// <summary>
        ///  Spacing between header and content in mm (default none)
        /// </summary>
        public double? HeaderSpacing { get; set; } = null;

        /// <summary>
        /// write line above the header (false)
        /// </summary>
        public bool? HasHeaderLine { get; set; } = false;

        /// <summary>
        /// Header font name (default Arial)
        /// </summary>
        public string? HeaderFontName { get; set; } = "Arial";

        /// <summary>
        /// Header font size (default 14)
        /// </summary>
        public byte? HeaderFontSize { get; set; } = 14;


        #endregion

        #region Page options

        /// <summary>
        /// Set the starting page number (default 1)
        /// </summary>
        public byte? PageOffset { get; set; } = 1;

        /// <summary>
        /// Sets the page margins Top (default 0)
        /// </summary>
        public byte? PageMarginsTop { get; set; } = 0;


        /// <summary>
        /// Sets the page margins Bottom (default 0)
        /// </summary>
        public byte? PageMarginsBottom { get; set; } = 0;

        /// <summary>
        /// Sets the page margins Left (default 0)
        /// </summary>
        public byte? PageMarginsLeft { get; set; } = 10;


        /// <summary>
        /// Sets the page margins Right (default 0)
        /// </summary>
        public byte? PageMarginsRight { get; set; } = 10;

        /// <summary>
        /// The default page size of the rendered document (default A4).
        /// </summary>
        public string? PageSize { get; set; } = "A4";

        /// <summary>
        /// Set the page Orientation (default Portrait)
        /// </summary>
        public string? PageOrientation { get; set; } = "Portrait";

        /// <summary>
        /// Disable SmartSets the page size (default true)
        /// </summary>
        public bool? DisableSmartShrinking { get; set; } = true;

        /// <summary> 
        /// Turn HTML form fields into pdf form fields (default false)
        /// </summary>
        public bool? EnableForms { get; set; } = false;

        #endregion

        #region Behavior

        /// <summary>
        /// Set the timeout to perform conversion to PDF (default 30000)
        /// </summary>
        public ushort? Timeout { get; set; } = 30000;

        /// <summary>
        /// Set to Ignore image errors (Default false)
        /// </summary>
        public bool? IgnoreImageErrors { get; set; } = false;

        /// <summary>
        /// Set to write arguments log with Level Information (Default LogLevel.Debug = false)
        /// </summary>
        public bool? LogArgumentsInfoLevel { get; set; } = false;

        #endregion
    }
}
