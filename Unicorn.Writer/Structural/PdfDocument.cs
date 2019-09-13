using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Structural
{
    public class PdfDocument : IPdfWriteable
    {
        private readonly PdfCrossRefTable _xrefTable = new PdfCrossRefTable();
        private readonly List<IPdfIndirectObject> _bodyObjects = new List<IPdfIndirectObject>();
        private readonly PdfCatalogue _root;

        public PdfDocument()
        {
            _root = new PdfCatalogue(_xrefTable.ClaimSlot());
            _bodyObjects.Add(_root);
        }

        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            int written = PdfHeader.Value.WriteTo(stream);
            foreach (IPdfIndirectObject indirectObject in _bodyObjects)
            {
                _xrefTable.SetSlot(indirectObject, written);
                written += indirectObject.WriteTo(stream);
            }

            PdfTrailer trailer = new PdfTrailer(_root, _xrefTable);
            trailer.SetCrossReferenceTableLocation(written);
            written += _xrefTable.WriteTo(stream);
            written += trailer.WriteTo(stream);
            return written;
        }
    }
}
