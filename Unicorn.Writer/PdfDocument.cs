using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.Interfaces;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Structural;

namespace Unicorn.Writer
{
    /// <summary>
    /// The class which represents an entire PDF document.
    /// </summary>
    public class PdfDocument : IPdfWriteable, IDocumentDescriptor
    {
        private readonly PdfCrossRefTable _xrefTable = new PdfCrossRefTable();
        private readonly List<IPdfIndirectObject> _bodyObjects = new List<IPdfIndirectObject>();
        private readonly PdfCatalogue _root;
        private readonly PdfPageTreeNode _pageRoot;
        private readonly Dictionary<string, PdfFont> _fontCache = new Dictionary<string, PdfFont>();

        /// <summary>
        /// The default size of new pages added to the document.
        /// </summary>
        public PhysicalPageSize DefaultPhysicalPageSize { get; set; }

        /// <summary>
        /// The default orientation of new pages added to the document.
        /// </summary>
        public PageOrientation DefaultPageOrientation { get; set; }

        /// <summary>
        /// The default size of each left and right margin, as a proportion of the total page width.
        /// </summary>
        public double DefaultHorizontalMarginProportion { get; set; }

        /// <summary>
        /// The default size of each top and bottom margin, as a proportion of the total page height.
        /// </summary>
        public double DefaultVerticalMarginProportion { get; set; }

        /// <summary>
        /// Default constructor.  Creates a document which defaults to A4 portrait pages with all margins 6% of the page dimensions.
        /// </summary>
        public PdfDocument() : this(PhysicalPageSize.A4, PageOrientation.Portrait, 0.06, 0.06)
        {

        }

        /// <summary>
        /// Constructor which lets the caller specify default page size, orientation and margins.
        /// </summary>
        /// <param name="defaultPageSize">Default page size.</param>
        /// <param name="defaultOrientation">Default page orientation.</param>
        /// <param name="defaultHorizontalMarginProportion">Default left and right margin proportions.</param>
        /// <param name="defaultVerticalMarginProportion">Default top and bottom margin proportions.</param>
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

        /// <summary>
        /// Append a new page to the document, specifying its size, orientation and margins.
        /// </summary>
        /// <param name="size">The page size.</param>
        /// <param name="orientation">The page orientation.</param>
        /// <param name="horizontalMarginProportion">The size of the left and right margins, as a proportion of the page width.</param>
        /// <param name="verticalMarginProportion">The size of the top and bottom margins, as a proportion of the page height.</param>
        /// <returns>An <see cref="IPageDescriptor" /> describing the new page.</returns>
        public IPageDescriptor AppendPage(PhysicalPageSize size, PageOrientation orientation, double horizontalMarginProportion, double verticalMarginProportion)
        {
            PdfStream contentStream = new PdfStream(_xrefTable.ClaimSlot());
            PdfPage page = new PdfPage(_pageRoot, _xrefTable.ClaimSlot(), this, size, orientation, horizontalMarginProportion, verticalMarginProportion, contentStream);
            _bodyObjects.Add(contentStream);
            _bodyObjects.Add(page);
            _pageRoot.Add(page);
            return page;
        }

        /// <summary>
        /// Append a new page to the document with default size and margins, specifying its orientation.
        /// </summary>
        /// <param name="pageOrientation">The orientation of the new page.</param>
        /// <returns>An <see cref="IPageDescriptor" /> describing the new page.</returns>
        public IPageDescriptor AppendPage(PageOrientation pageOrientation)
        {
            return AppendPage(DefaultPhysicalPageSize, pageOrientation, DefaultHorizontalMarginProportion, DefaultVerticalMarginProportion);
        }

        /// <summary>
        /// Append a new page to the document, with default size, orientation and margins.
        /// </summary>
        /// <returns>An <see cref="IPageDescriptor" /> describing the new page.</returns>
        public IPageDescriptor AppendPage()
        {
            return AppendPage(DefaultPhysicalPageSize, DefaultPageOrientation, DefaultHorizontalMarginProportion, DefaultVerticalMarginProportion);
        }

        /// <summary>
        /// Write the document to a stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        public void Write(Stream stream)
        {
            WriteTo(stream);
        }

        /// <summary>
        /// Write the document to a stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            int written = PdfHeader.Value.WriteTo(stream);
            CloseAllPages();
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

        /// <summary>
        /// Register that a font is likely to be used in the document.  If of a type that supports it, it will be embedded.
        /// </summary>
        /// <param name="font">The font that is to be used and/or embedded.</param>
        /// <returns>A <see cref="PdfFont" /> wrapper object which represents the PDF font dictionary that will be written to the document for this font.  If this font
        /// (or a font with the same <see cref="IFontDescriptor.UnderlyingKey" /> has previously been passed to this method, this may be an object returned by
        /// prior calls.</returns>
        public PdfFont UseFont(IFontDescriptor font)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            lock (_fontCache)
            {
                if (_fontCache.ContainsKey(font.UnderlyingKey))
                {
                    return _fontCache[font.UnderlyingKey];
                }
                PdfFont pdfFont = new PdfFont(_xrefTable.ClaimSlot(), font);
                _fontCache.Add(font.UnderlyingKey, pdfFont);
                _bodyObjects.Add(pdfFont);
                return pdfFont;
            }
        }

        private void CloseAllPages()
        {
            foreach (PdfPage page in _bodyObjects.Where(b => b is PdfPage))
            {
                page.ClosePage();
            }
        }
    }
}
