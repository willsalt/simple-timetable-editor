using PdfSharp.Pdf;
using System.IO;
using Unicorn.Interfaces;

namespace Unicorn.Impl.PdfSharp
{
    /// <summary>
    /// A class which defines a PDF document.
    /// </summary>
    public class DocumentDescriptor : IDocumentDescriptor
    {
        /// <summary>
        /// The default physical size of a newly-added page.
        /// </summary>
        public PhysicalPageSize DefaultPhysicalPageSize { get; set; }

        /// <summary>
        /// The default orientation of a newly-added page.
        /// </summary>
        public PageOrientation DefaultPageOrientation { get; set; }

        /// <summary>
        /// The default horizontal margin width of a newly-added page, as a proportion of the page width.
        /// </summary>
        public double DefaultHorizontalMarginProportion { get; set; }

        /// <summary>
        /// The default vertical margin height of a newly-added page, as a proportion of the page width.
        /// </summary>
        public double DefaultVerticalMarginProportion { get; set; }

        private PdfDocument Document { get; set; }        

        /// <summary>
        /// Constructor which sets default parameters.
        /// </summary>
        /// <param name="defaultSize">Default page size.</param>
        /// <param name="defaultOrientation">Default page orientation.</param>
        /// <param name="defaultHorizontalMargin">Default page horizontal margin proportion.</param>
        /// <param name="defaultVerticalMargin">Default page vertical margin proportion.</param>
        public DocumentDescriptor(PhysicalPageSize defaultSize, PageOrientation defaultOrientation, double defaultHorizontalMargin, double defaultVerticalMargin)
        {
            DefaultPageOrientation = defaultOrientation;
            DefaultPhysicalPageSize = defaultSize;
            DefaultHorizontalMarginProportion = defaultHorizontalMargin;
            DefaultVerticalMarginProportion = defaultVerticalMargin;
            Document = new PdfDocument();
            Document.Options.CompressContentStreams = false;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DocumentDescriptor() : this(PhysicalPageSize.A4, PageOrientation.Portrait, 0.06, 0.06)
        {
        }

        /// <summary>
        /// Add a new page to the document with default attributes.
        /// </summary>
        /// <returns>An <see cref="IPageDescriptor" /> representing the new page.</returns>
        public IPageDescriptor AppendPage()
        {
            return AppendPage(DefaultPhysicalPageSize, DefaultPageOrientation, DefaultHorizontalMarginProportion, DefaultVerticalMarginProportion);
        }

        /// <summary>
        /// Add a new page to the document of default size but custom orientation.
        /// </summary>
        /// <param name="orientation">The orientation of the new page.</param>
        /// <returns>An <see cref="IPageDescriptor" /> representing the new page.</returns>
        public IPageDescriptor AppendPage(PageOrientation orientation)
        {
            return AppendPage(DefaultPhysicalPageSize, orientation, DefaultHorizontalMarginProportion, DefaultVerticalMarginProportion);
        }

        /// <summary>
        /// Add a new page to the document with custom attributes.
        /// </summary>
        /// <param name="size">The physical size of the new page.</param>
        /// <param name="orientation">The orientation of the new page.</param>
        /// <param name="horizontalMarginProportion">The horizontal margin proportion of the new page.</param>
        /// <param name="verticalMarginProportion">The vertical margin proportion of the new page.</param>
        /// <returns>An <see cref="IPageDescriptor" /> representing the new page.</returns>
        public IPageDescriptor AppendPage(PhysicalPageSize size, PageOrientation orientation, double horizontalMarginProportion, double verticalMarginProportion)
        {
            PdfPage page = Document.AddPage();
            page.Size = size.ToPdfSharpPageSize();
            page.Orientation = orientation.ToPdfSharpPageOrientation();
            return new PageDescriptor(page, horizontalMarginProportion, verticalMarginProportion);
        }

        /// <summary>
        /// Write the document to the given stream.
        /// </summary>
        /// <param name="dest">The <see cref="Stream" /> to write the document content to.</param>
        public void Write(Stream dest)
        {
            Document.Save(dest);
        }
    }
}
