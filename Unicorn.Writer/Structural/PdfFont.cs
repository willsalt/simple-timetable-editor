using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Unicorn.CoreTypes;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// A PDF indirect object representing a font resource.
    /// </summary>
    public class PdfFont : PdfIndirectObject
    {
        private readonly IFontDescriptor _font;

        private readonly int _fontNumber;
        private static int _fontCounter = 1;

        private static readonly Lazy<PdfName> _fontDescriptorName = new Lazy<PdfName>(() => new PdfName("FontDescriptor"));

        private readonly PdfFontDescriptor _fontDescriptor;

        /// <summary>
        /// The name used to refer to the font by text operators, such as "/F4".  Strictly speaking, this value _could_ be page-specific, so that a given font is
        /// referred to as "/F7" on one page and "/Font2" on another, but there would be no benefit to not keeping the internal name of a font consistent throughout
        /// a document.  The internal name is keyed to the font object itself in the resources dictionary of every page that uses it.
        /// </summary>
        public PdfName InternalName { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="objectId">The indirect object ID of this font resource.</param>
        /// <param name="font">The underlying font information.</param>
        /// <param name="generation">The object generation number.  Defaults to zero.  As we currently do not support rewriting existing documents, this
        /// should not be set.</param>
        internal PdfFont(int objectId, IFontDescriptor font, PdfFontDescriptor fd, int generation = 0) : base(objectId, generation)
        {
            _fontDescriptor = fd;
            _fontNumber = _fontCounter++;
            InternalName = new PdfName(string.Format(CultureInfo.InvariantCulture, "F{0}", _fontNumber));
            _font = font;
        }

        /// <summary>
        /// Write this font resource to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        public override int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, MakeDictionary().WriteTo, stream);
        }

        /// <summary>
        /// Convert this font resource into an array of bytes and append them to a list.
        /// </summary>
        /// <param name="list">The list to append the data to.</param>
        /// <returns></returns>
        public override int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            return Write(WriteToList, MakeDictionary().WriteTo, list);
        }

        private PdfDictionary MakeDictionary()
        {
            PdfDictionary d = new PdfDictionary { { CommonPdfNames.Type, CommonPdfNames.Font } };
            if (_fontDescriptor != null)
            {
                d.Add(_fontDescriptorName.Value, _fontDescriptor.GetReference());
            }
            d.AddRange(_font.MakeFontDictionary());
            return d;
        }
    }
}
