using System;

namespace Html2Pdf.Lib;

public sealed class ConvertResult(TimeSpan elapsedtime, byte[]? value = null, string? filename = null, Exception? error = null)
{
    public Exception? Error { get; } = error;
    public bool HasValue => (Content ?? []).Length > 0 || (FileName??string.Empty).Length > 0;
    public byte[]? Content { get; } = value;
    public string? FileName { get; } = filename;
    public TimeSpan Elapsedtime { get; } = elapsedtime;  
}
