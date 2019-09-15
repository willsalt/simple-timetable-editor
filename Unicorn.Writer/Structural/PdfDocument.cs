using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Interfaces;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Structural
{
    public class PdfDocument : IPdfWriteable, IDocumentDescriptor
    {
        private readonly PdfCrossRefTable _xrefTable = new PdfCrossRefTable();
        private readonly List<IPdfIndirectObject> _bodyObjects = new List<IPdfIndirectObject>();
        private readonly PdfCatalogue _root;
        private readonly PdfPageTreeNode _pageRoot;

        public PhysicalPageSize DefaultPhysicalPageSize { get; set; }

        public PageOrientation DefaultPageOrientation { get; set; }

        public double DefaultHorizontalMarginProportion { get; set; }

        public double DefaultVerticalMarginProportion { get; set; }

        public PdfDocument() : this(PhysicalPageSize.A4, PageOrientation.Portrait, 0.06, 0.06)
        {

        }

        public PdfDocument(PhysicalPageSize defaultPageSize, PageOrientation defaultOrientation, double defaultHorizontalMarginProportion, double defaultVerticalMarginProportion)
        {
            _pageRoot = new PdfPageTreeNode(null, _xrefTable.ClaimSlot());
            _bodyObjects.Add(_pageRoot);
            _root = new PdfCatalogue(_pageRoot, _xrefTable.ClaimSlot());
            _bodyObjects.Add(_root);

            DefaultPhysicalPageSize = defaultPageSize;
            DefaultPageOrientation = defaultOrientation;
            DefaultHorizontalMarginProportion = defaultHorizontalMarginProportion;
            DefaultVerticalMarginProportion = defaultVerticalMarginProportion;
        }

        public IPageDescriptor AppendPage(PhysicalPageSize size, PageOrientation orientation, double horizontalMarginProportion, double verticalMarginProportion)
        {
            PdfPage page = new PdfPage(_pageRoot, _xrefTable.ClaimSlot(), size, orientation, horizontalMarginProportion, verticalMarginProportion);
            _bodyObjects.Add(page);
            _pageRoot.Add(page);
            return page;
        }

        public IPageDescriptor AppendPage(PageOrientation pageOrientation)
        {
            return AppendPage(DefaultPhysicalPageSize, pageOrientation, DefaultHorizontalMarginProportion, DefaultVerticalMarginProportion);
        }

        public IPageDescriptor AppendPage()
        {
            return AppendPage(DefaultPhysicalPageSize, DefaultPageOrientation, DefaultHorizontalMarginProportion, DefaultVerticalMarginProportion);
        }

        public void Write(Stream stream)
        {
            WriteTo(stream);
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
