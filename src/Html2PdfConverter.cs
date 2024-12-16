using System;
using System.Linq;
using System.Text;

namespace Html2Pdf.Lib;

public partial class Html2PdfConverter
{
    private readonly StringBuilder _arguments = new();

    /// <summary>
    /// Converts the HTML to PDF
    /// </summary>
    /// <returns>PDF as byte array</returns>
    public byte[] ConvertFromHtml(string html)
    {
        var buffer = WkHtmlToPdf.ConvertFromHtml(html, _arguments.ToString());
        return buffer;
    }

    /// <summary>
    /// Converts the URL to PDF
    /// </summary>
    /// <returns>PDF as byte array</returns>
    public byte[] ConvertFromUrl(Uri url)
    {
        var buffer = WkHtmlToPdf.ConvertFromUrl(url, _arguments.ToString());
        return buffer;
    }

    private Html2PdfConverter AppendArgument(string argumentName, params object[] argumentValues)
    {
        var argument = argumentValues.Aggregate(argumentName, (current, value) => current + $" {value}").Trim();
        _arguments.Append($" {argument}");
        return this;
    }

    private string Text(string text)
        => $"\"{text}\"";
}

/*
https://wkhtmltopdf.org/
https://wkhtmltopdf.org/usage/wkhtmltopdf.txt
*/