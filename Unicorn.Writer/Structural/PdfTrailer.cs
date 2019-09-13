using System;
using System.Globalization;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    public class PdfTrailer : IPdfWriteable
    {
        private readonly PdfCatalogue _root;
        private readonly PdfCrossRefTable _xrefs;
        private int? _xrefLocation = null;

        public PdfTrailer(PdfCatalogue root, PdfCrossRefTable xrefs)
        {
            _root = root ?? throw new ArgumentNullException(nameof(root));
            _xrefs = xrefs ?? throw new ArgumentNullException(nameof(xrefs));
        }

        public void SetCrossReferenceTableLocation(int location)
        {
            _xrefLocation = location;
        }

        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (!_xrefLocation.HasValue)
            {
                throw new InvalidOperationException(Resources.Structural_PdfTrailer_WriteTo_CrossRef_Location_Not_Known_Error);
            }
            PdfDictionary dict = GetDictionary();
            int written = StreamWrite(stream, new byte[] { 0x74, 0x72, 0x61, 0x69, 0x6c, 0x65, 0x72, 0xa });                      // "trailer\n"
            written += dict.WriteTo(stream);
            written += StreamWrite(stream, new byte[] { 0x73, 0x74, 0x61, 0x72, 0x74, 0x78, 0x72, 0x65, 0x66, 0xa });             // "startxref\n"
            written += StreamWrite(stream, Encoding.ASCII.GetBytes(_xrefLocation.Value.ToString(CultureInfo.InvariantCulture)));
            written += StreamWrite(stream, new byte[] { 0xa, 0x25, 0x25, 0x45, 0x4f, 0x46 });                                     // "\n%%EOF"
            return written;
        }

        private PdfDictionary GetDictionary()
        {
            PdfDictionary dict = new PdfDictionary();
            dict.Add(CommonPdfNames.Size, new PdfInteger(_xrefs.Count));
            dict.Add(CommonPdfNames.Root, _root.GetReference());
            return dict;
        }

        private static int StreamWrite(Stream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
            return bytes.Length;
        }
    }
}
