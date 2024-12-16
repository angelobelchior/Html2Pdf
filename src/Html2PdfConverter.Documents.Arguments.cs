namespace Html2Pdf.Lib;

public partial class Html2PdfConverter
{
    /// <summary>
    /// When jpeg compressing images use this quality (default 94)
    /// </summary>
    /// <param name="quality">Image quality</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetImageQuality(ushort quality)
    {
        if (quality > 100) quality = 100;
        if (quality == 0) quality = 1;
        return AppendArgument("--image-quality", quality);
    }
    
    /// <summary>
    /// Do not print background
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter DoNotPrintBackground()
        => AppendArgument("--no-background");
    
    /// <summary>
    /// Do not load or print images
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter DoNotLoadOrPrintImages()
        => AppendArgument("--no-images");

    /// <summary>
    /// Do not use lossless compression on pdf objects
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter WithNoPdfCompression()
        => AppendArgument("--no-pdf-compression");

    /// <summary>
    /// Do not make links to remote web pages
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter DisableExternalLinks()
        => AppendArgument("--disable-external-links");

    /// <summary>
    /// Do not make local links
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter DisableInternalLinks()
        => AppendArgument($" --disable-internal-links");

    /// <summary>
    /// The title of the generated pdf file (The title of the first document is used if not specified)
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter SetTitle(string title)
        => AppendArgument("--title", Text(title));

    /// <summary>
    /// Indicates whether the PDF should be generated in lower quality.
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter WithLowQuality()
        => AppendArgument("--lowquality");

    // /// <summary>
    // /// Number of copies to print into the PDF file.
    // /// </summary>
    // /// <returns>HtmlToPDFBuilder instance</returns>
    // public Html2PdfConverter SetCopies(int copies)
    // {
    //     _arguments.Append($" --copies {copies}");
    //     return this;
    // }

    /// <summary>
    /// Indicates whether the PDF should be generated in grayscale.
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter WithGrayScale()
        => AppendArgument("--grayscale");
    
    /// <summary>
    /// Sets the variables to replace in the header and footer html
    /// </summary>
    /// <remarks>Replaces [name] with value in header and footer (repeatable).</remarks>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Html2PdfConverter Replace(string from, string to)
        => AppendArgument("--replace", from, to);
}