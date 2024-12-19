using System.Linq;
using System.Text;

namespace Html2Pdf.Lib;

/// <summary>
/// Converter Arguments
/// </summary>
public partial class Arguments
{
    private readonly StringBuilder _arguments = new();
    
    private Arguments AppendArgument(string argumentName, params object[] argumentValues)
    {
        var argument = argumentValues.Aggregate(argumentName, (current, value) => current + $" {value}").Trim();
        _arguments.Append($" {argument}");
        return this;
    }

    private string Text(string text)
        => $"\"{text}\"";
    
    public override string ToString()
        => _arguments.ToString();
}