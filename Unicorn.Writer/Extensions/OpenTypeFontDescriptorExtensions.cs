using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicorn.FontTools;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    public static class OpenTypeFontDescriptorExtensions
    {
        public static PdfDictionary MakeFontDictionary(this OpenTypeFontDescriptor font)
        {
            if (font is null)
            {
                throw new NullReferenceException();
            }
            PdfDictionary d = new PdfDictionary();
            d.Add(CommonPdfNames.Subtype, new PdfName("TrueType"));
            d.Add(new PdfName("Encoding"), new PdfName("WinAnsiEncoding"));
            d.Add(new PdfName("FirstChar"), new PdfInteger(font.FirstMappedByte()));
            d.Add(new PdfName("LastChar"), new PdfInteger(font.LastMappedByte()));
            d.Add(new PdfName("Widths"), new PdfArray(font.CharWidths().Select(w => new PdfReal(w))));
            return d;
        }
    }
}
