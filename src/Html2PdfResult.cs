// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

namespace Html2PdfLib
{
    /// <summary>
    /// Result of converting Html to PDF
    /// </summary>
    /// <remarks>
    /// Create instance Result of converting Html to PDF
    /// </remarks>
    public readonly struct Html2PdfResult(TimeSpan elapsedtime, byte[]? value = null, string? filename = null, Exception? error = null)
    {
        /// <summary>
        /// The exception during conversion. <see cref="Exception"/>
        /// </summary>
        public Exception? Error { get; } = error;

        /// <summary>
        /// If the conversion was successful
        /// </summary>
        public bool IsSuccess => (Content ?? []).Length > 0 || (FileName ?? string.Empty).Length > 0;

        /// <summary>
        /// PDF in bytes
        /// </summary>
        public byte[]? Content { get; } = value;


        /// <summary>
        /// File name PDF
        /// </summary>
        public string? FileName { get; } = filename;

        /// <summary>
        /// Time taken to convert to PDF
        /// </summary>
        public TimeSpan Elapsedtime { get; } = elapsedtime;
    }
}
