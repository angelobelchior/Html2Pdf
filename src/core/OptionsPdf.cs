// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the Html2Pdf.Lib
// https://github.com/angelobelchior/Html2Pdf
// ***************************************************************************************

using System.Globalization;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Html2PdfLib.core
{
    internal class OptionsPdf : IOptionsPdf
    {
        private static readonly PropertyInfo[] _properties = typeof(OptionsPdf).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        private static readonly CultureInfo _cultureArg = new("en-US");

        #region IOptionsPdf

        public string ArgCopies { get; private set; } = "";

        public IOptionsPdf Copies(byte value)
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Copies must be greater than one");
            }
            if (value > 1)
            {
                ArgCopies = $" --copies {value}";
            }
            else
            {
                ArgCopies = string.Empty;
            }
            return this;
        }

        public string ArgDisableExternalLinks { get; private set; } = $" --disable-external-links";
        public IOptionsPdf DisableExternalLinks(bool value)
        {
            ArgDisableExternalLinks = value ? " --disable-external-links" : "";
            return this;
        }

        public string ArgDisableInternalLinks { get; private set; } = " --disable-internal-links";

        public IOptionsPdf DisableInternalLinks(bool value)
        {
            ArgDisableInternalLinks = value ? " --disable-internal-links" : " --enable-internal-links";
            return this;
        }

        public string ArgDisableSmartShrinking { get; private set; } = " --disable-smart-shrinking";
        public IOptionsPdf DisableSmartShrinking(bool value)
        {
            ArgDisableSmartShrinking = value ? " --disable-smart-shrinking" : " --enable-smart-shrinking";
            return this;
        }

        public string ArgEnableForms { get; private set; } = "";
        public IOptionsPdf EnableForms(bool value)
        {
            ArgEnableForms = value ? " --enable-forms" : "";
            return this;
        }

        public string ArgFooterFontName { get; private set; } = " --footer-font-name Arial";
        public string ArgFooterFontSize { get; private set; } = " --footer-font-size 10";
        public IOptionsPdf FooterFont(string fontName, byte fontSize)
        {
            if (string.IsNullOrEmpty(fontName))
            {
                throw new ArgumentNullException(nameof(fontName), "Font name is required");
            }
            if (fontSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(fontSize), "Font size must be greater than zero");
            }
            ArgFooterFontName = $" --footer-font-name {fontName}";
            ArgFooterFontSize = $" --footer-font-size {fontSize}";
            return this;
        }

        public string ArgFooterSpacing { get; private set; } = "";
        public IOptionsPdf FooterSpacing(double value)
        {
            if (value.Equals(0))
            {
                ArgFooterSpacing = "";
            }
            else
            {
                ArgFooterSpacing =$" --footer-spacing {value.ToString("N2", _cultureArg)}";
            }
            return this;
        }

        public string ArgFooterText { get; private set; } = "";
        public IOptionsPdf FooterText(string text, TextAlignment alignment)
        {
            if (string.IsNullOrEmpty(text))
            {
                ArgFooterText = "";
            }
            else
            {
                if (alignment == TextAlignment.Center)
                    ArgFooterText = $" --footer-center {Text(text)}";
                else if (alignment == TextAlignment.Right)
                    ArgFooterText = $" --footer-right {Text(text)}";
                else
                    ArgFooterText = $" --footer-left {Text(text)}";
            }
            return this;
        }

        public string ArgGrayScale { get; private set; } = "";
        public IOptionsPdf GrayScale(bool value)
        {
            ArgGrayScale = value ? " --grayscale" : "";
            return this;
        }

        public string ArgHasFooterLine { get; private set; } = "";
        public IOptionsPdf HasFooterLine(bool value)
        {
            ArgHasFooterLine = value ? " --footer-line" : "";
            return this;
        }

        public string ArgHasHeaderLine { get; private set; } = "";
        public IOptionsPdf HasHeaderLine(bool value)
        {
            ArgHasHeaderLine = value ? " --header-line" : "";
            return this;
        }

        public string ArgHeaderFontName { get; private set; } = " --header-font-name Arial";
        public string ArgHeaderFontSize { get; private set; } = " --header-font-size 14";
        public IOptionsPdf HeaderFont(string fontName, byte fontSize)
        {
            if (string.IsNullOrEmpty(fontName))
            {
                throw new ArgumentNullException(nameof(fontName), "Font name is required");
            }
            if (fontSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(fontSize), "Font size must be greater than zero");
            }
            ArgHeaderFontName = $" --footer-font-name {fontName}";
            ArgHeaderFontSize = $" --footer-font-size {fontSize}";
            return this;
        }

        public string ArgHeaderSpacing { get; private set; } = "";
        public IOptionsPdf HeaderSpacing(double value)
        {
            if (value.Equals(0))
            {
                ArgHeaderSpacing = "";
            }
            else
            {
                ArgHeaderSpacing = $" --header-spacing {value.ToString("N2", _cultureArg)}";
            }
            return this;
        }

        public string ArgHeaderText { get; private set; } = "";
        public IOptionsPdf HeaderText(string text, TextAlignment alignment)
        {
            if (string.IsNullOrEmpty(text))
            {
                ArgHeaderText = "";
            }
            else
            {
                if (alignment == TextAlignment.Center)
                    ArgHeaderText = $" --header-center {Text(text)}";
                else if (alignment == TextAlignment.Right)
                    ArgHeaderText = $" --header-right {Text(text)}";
                else
                    ArgHeaderText = $" --header-left {Text(text)}";
            }
            return this;
        }

        public string ArgImageQuality { get; private set; } = " --image-quality 94";
        public IOptionsPdf ImageQuality(byte value)
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "ImageQuality must be between 1 and 100");
            }
            ArgImageQuality = $" --image-quality {value}";
            return this;
        }

        public string ArgLoadOrPrintImages { get; private set; } = "";
        public IOptionsPdf LoadOrPrintImages(bool value)
        {
            ArgLoadOrPrintImages = value ? "" : " --no-images";
            return this;
        }

        public string ArgPageHeight { get; private set; } = "";
        public IOptionsPdf PageHeight(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "PageHeight must be greater than zero");
            }
            if (value.Equals(0))
            {
                ArgPageHeight = "";
            }
            else
            {
                ArgPageHeight = $" --page-height {value.ToString("N2", _cultureArg)}";
            }
            return this;
        }

        public string ArgPageMarginsTop { get; private set; } = " --margin-top 0";
        public string ArgPageMarginsBottom { get; private set; } = " --margin-bottom 0";
        public string ArgPPageMarginsLeft { get; private set; } = " --margin-left 10";
        public string ArgPageMarginsRight { get; private set; } = " --margin-right 10";

        public IOptionsPdf PageMargins(int top, int right, int bottom, int left)
        {
            ArgPageMarginsTop = $" --margin-top {top}";
            ArgPageMarginsBottom = $" --margin-bottom {bottom}";
            ArgPPageMarginsLeft = $" --margin-left {left}";
            ArgPageMarginsRight = $" --margin-right {right}"; 
            return this;
        }

        public IOptionsPdf PageMargins(int value)
        {
            ArgPageMarginsTop = $" --margin-top {value}";
            ArgPageMarginsBottom = $" --margin-bottom {value}";
            ArgPPageMarginsLeft = $" --margin-left {value}";
            ArgPageMarginsRight = $" --margin-right {value}";
            return this;
        }

        public IOptionsPdf PageMargins(int topAndBottom, int rightAndLeft)
        {
            ArgPageMarginsTop = $" --margin-top {topAndBottom}";
            ArgPageMarginsBottom = $" --margin-bottom {topAndBottom}";
            ArgPPageMarginsLeft = $" --margin-left {rightAndLeft}";
            ArgPageMarginsRight = $" --margin-right {rightAndLeft}";
            return this;
        }

        public string ArgPageOffset { get; private set; } = "";
        public IOptionsPdf PageOffset(byte value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "PageOffset must be greater than zero");
            }
            if (value == 0)
            {
                ArgPageOffset = "";
            }
            else
            {
                ArgPageOffset = $" --page-offset {value}";
            }
            return this;
        }

        public string ArgPageOrientation { get; private set; } = " --orientation Portrait";
        public IOptionsPdf PageOrientation(PageOrientation value)
        {
            ArgPageOrientation = $" --orientation {value}";
            return this; 
        }

        public string ArgPageSize { get; private set; } = " --page-size A4";

        public IOptionsPdf PageSize(PageSize value)
        {
            ArgPageOrientation = $" --page-size {value}";
            return this;
        }

        public string ArgPageWidth { get; private set; } = "";
        public IOptionsPdf PageWidth(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "PageWidth must be greater than zero");
            }
            if (value.Equals(0))
            {
                ArgPageWidth = "";
            }
            else
            {
                ArgPageWidth = $" --page-width {value.ToString("N2", _cultureArg)}";
            }
            return this;
        }

        public string ArgPdfCompression { get; private set; } = "";
        public IOptionsPdf PdfCompression(bool value)
        {
            ArgPdfCompression = value ? "" : " --no-pdf-compression";
            return this;
        }

        public string ArgPrintBackground { get; private set; } = " --background";
        public IOptionsPdf PrintBackground(bool value)
        {
            ArgPrintBackground = value ? " --background" : " --no-background";
            return this;
        }

        public List<string> ArgReplace { get; private set; } = [];

        public IOptionsPdf Replace(string from, string to)
        {
            ArgReplace.Add($" --replace {Text(from)} {Text(to)}");
            return this;
        }

        public string ArgTitle { get; private set; } = "";
        public IOptionsPdf Title(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                ArgTitle = "";
            }
            else
            {
                ArgTitle = $" --title {Text(value)}";
            }
            return this;
        }

        public string ArgWithLowQuality { get; private set; } = " --lowquality";
        public IOptionsPdf WithLowQuality(bool value)
        {
            ArgWithLowQuality = value ? " --lowquality" : "";
            return this;
        }

        #endregion

        internal string? Source { get; set; }

        internal bool IsUrisource { get; set; }

        internal ILogger? LogInstance { get; set; }

        internal bool LogArgumentsInfoLevel {get; set; }

        internal ushort Timeout { get; set; } = 30000;

        internal bool  IgnoreImageErrors { get; set; } = false;

        private static string Text(string text) => $"\"{text}\"";

        public override string ToString()
        {
            var args = new StringBuilder();
            foreach (PropertyInfo property in _properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    args.Append(property.GetValue(this));
                }
                else if (typeof(System.Collections.IList).IsAssignableFrom(property.PropertyType))
                { 
                    var lst = property.GetValue(this) as IList<string>;
                    foreach (var item in lst!)
                    {
                        args.Append(item);
                    }
                }
            }
            return args.ToString().Trim();
        }
    }
}
