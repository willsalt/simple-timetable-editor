using System;
using Unicorn.CoreTypes;
using Unicorn.FontTools;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    public static class IFontDescriptorExtensions
    {
        private static readonly Lazy<PdfName> _type1Name = new Lazy<PdfName>(() => new PdfName("Type1"));

        public static PdfDictionary MakeFontDictionary(this IFontDescriptor descriptor)
        {
            if (descriptor is null)
            {
                throw new NullReferenceException();
            }
            PdfDictionary d = new PdfDictionary { { CommonPdfNames.BaseFont, new PdfName(descriptor.BaseFontName) } };
            if (descriptor is PdfStandardFontDescriptor)
            {
                d.Add(CommonPdfNames.Subtype, _type1Name.Value);
            }
            else if (descriptor is OpenTypeFontDescriptor otfd)
            {
                d.AddRange(otfd.MakeFontDictionary());
            }
            return d;
        }
    }
}
