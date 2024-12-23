namespace Html2Pdf.Lib;

public partial class Arguments
{
    /// <summary>
    /// Display line below the header
    /// </summary>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments DisplayHeaderLine()
        => AppendArgument("--header-line");
    
    /// <summary>
    /// Set header text
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="textAlignment"><see cref="TextAlignment">Text Alignment</see></param>
    /// <param name="fontName">Font Name</param>
    /// <param name="fontSize">Font Size</param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetHeaderText(
        string text, 
        TextAlignment textAlignment = TextAlignment.Left,
        string fontName = "Arial",
        int fontSize = 12)
    {
        if (textAlignment == TextAlignment.Center)
            AppendArgument("--header-center", Text(text));
        else if (textAlignment == TextAlignment.Right)
            AppendArgument("--header-right", Text(text));
        else
            AppendArgument("--header-left", Text(text));
        
        AppendArgument("--header-font-name",  Text(fontName));
        AppendArgument("--header-font-size",  fontSize);

        return this;
    }
    
    /// <summary>
    /// Spacing between header and content in mm (default 0)
    /// </summary>
    /// <param name="headerSpacing">FooterSpacing </param>
    /// <returns>HtmlToPDFBuilder instance</returns>
    public Arguments SetHeaderSpacing(double headerSpacing)
        => AppendArgument("--header-spacing", headerSpacing);
}