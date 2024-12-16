namespace Html2Pdf.Lib;

public partial class Arguments
{
    /// <summary>
    /// Sets the footer spacing.
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetFooterSpacing(int footerSpacing)
        => AppendArgument("--footer-spacing", footerSpacing);
    
    /// <summary>
    /// Display line above the footer
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments DisplayFooterLine()
        => AppendArgument("--footer-line");
    
    /// <summary>
    /// Set footer text
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="textAlignment"><see cref="TextAlignment">Text Alignment</see></param>
    /// <param name="fontName">Font Name</param>
    /// <param name="fontSize">Font Size</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetFooterText(
        string text, 
        TextAlignment textAlignment = TextAlignment.Left,
        string fontName = "Arial",
        int fontSize = 12)
    {
        if (textAlignment == TextAlignment.Center)
            AppendArgument("--footer-center", Text(text));
        else if (textAlignment == TextAlignment.Right)
            AppendArgument("--footer-right", Text(text));
        else
            AppendArgument("--footer-left", Text(text));
        
        AppendArgument("--footer-font-name",  fontName);
        AppendArgument("--footer-font-size",  fontSize);

        return this;
    }
    
    /// <summary>
    /// Spacing between footer and content in mm (default 0)
    /// </summary>
    /// <param name="footerSpacing">FooterSpacing </param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetFooterSpacing(double footerSpacing)
        => AppendArgument("--footer-spacing", footerSpacing);
}