using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.CoreTypes;
using Unicorn.FontTools;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    public class PdfFontDescriptor : PdfIndirectObject
    {
        public string Name { get; private set; }

        public FontDescriptorFlags Flags { get; private set; }

        public PdfRectangle BoundingBox { get; private set; }

        public decimal ItalicAngle { get; private set; }

        public decimal Ascent { get; private set; }

        public decimal Descent { get; private set; }

        public decimal CapHeight { get; private set; }

        public decimal StemV { get; private set; }

        private string _embeddingKey;

        public PdfStream EmbeddedData { get; private set; }

        private static readonly Lazy<PdfName> _fontNameName = new Lazy<PdfName>(() => new PdfName("FontName"));
        private static readonly Lazy<PdfName> _flagsName = new Lazy<PdfName>(() => new PdfName("Flags"));
        private static readonly Lazy<PdfName> _fontBBoxName = new Lazy<PdfName>(() => new PdfName("FontBBox"));
        private static readonly Lazy<PdfName> _italicAngleName = new Lazy<PdfName>(() => new PdfName("ItalicAngle"));
        private static readonly Lazy<PdfName> _ascentName = new Lazy<PdfName>(() => new PdfName("Ascent"));
        private static readonly Lazy<PdfName> _descentName = new Lazy<PdfName>(() => new PdfName("Descent"));
        private static readonly Lazy<PdfName> _capHeightName = new Lazy<PdfName>(() => new PdfName("CapHeight"));
        private static readonly Lazy<PdfName> _stemVName = new Lazy<PdfName>(() => new PdfName("StemV"));

        public PdfFontDescriptor(int objectId, IFontDescriptor font, string embeddingKey, PdfStream embeddingData, int generation = 0) : base(objectId, generation)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            Name = font.BaseFontName;
            Flags = font.Flags;
            BoundingBox = new PdfRectangle(font.BoundingBox.Left, font.BoundingBox.Top, font.BoundingBox.Left + font.BoundingBox.Width,
                font.BoundingBox.Top + font.BoundingBox.Height);
            ItalicAngle = font.ItalicAngle;
            Ascent = (decimal)font.Ascent;
            Descent = (decimal)font.Descent;
            CapHeight = font.CapHeight;
            StemV = font.VerticalStemThickness;
            _embeddingKey = embeddingKey;
            EmbeddedData = embeddingData;
        }

        private PdfDictionary MakeDictionary()
        {
            PdfDictionary d = new PdfDictionary();
            d.Add(CommonPdfNames.Type, new PdfName("FontDescriptor"));
            d.Add(_fontNameName.Value, new PdfName(Name));
            d.Add(_flagsName.Value, new PdfInteger((int)Flags));
            d.Add(_fontBBoxName.Value, BoundingBox);
            d.Add(_italicAngleName.Value, new PdfReal(ItalicAngle));
            d.Add(_ascentName.Value, new PdfReal(Ascent));
            d.Add(_descentName.Value, new PdfReal(Descent));
            d.Add(_capHeightName.Value, new PdfReal(CapHeight));
            d.Add(_stemVName.Value, new PdfReal(StemV));
            if (_embeddingKey.Length != 0 && EmbeddedData != null)
            {
                d.Add(new PdfName(_embeddingKey), EmbeddedData.GetReference());
            }
            return d;
        }

        /// <summary>
        /// Write this font descriptor resource to a <see cref="Stream" />.
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
        /// Convert this font descriptor resource into an array of bytes and append them to a list.
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
    }
}
