using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Unicorn.CoreTypes;

namespace Unicorn.Impl.PdfSharp
{
    /// <summary>
    /// An <see cref="IPageDescriptor"/> implementation for PDFSharp.
    /// </summary>
    public class PageDescriptor : IPageDescriptor
    {
        internal PdfPage Page { get; private set; }

        /// <summary>
        /// The graphics context for drawing onto this page.
        /// </summary>
        public IGraphicsContext PageGraphics { get; private set; }

        private double _horizontalMargin;
        private double _verticalMargin;

        /// <summary>
        /// Constructor which takes page and margin proportions.
        /// </summary>
        /// <param name="page">The underlying page</param>
        /// <param name="horizontalMarginPercent">The percentage of the width of the page that is used by one margin.</param>
        /// <param name="verticalMarginPercent">The percentage of the height of the page that is used by one margin.</param>
        public PageDescriptor(PdfPage page, double horizontalMarginPercent, double verticalMarginPercent)
        {
            Page = page;
            PageGraphics = new GraphicsContext(XGraphics.FromPdfPage(Page));
            HorizontalMarginProportion = horizontalMarginPercent;
            VerticalMarginProportion = verticalMarginPercent;
            CurrentVerticalCursor = TopMarginPosition;
        }

        internal double HorizontalMarginProportion
        {
            get
            {
                return _horizontalMargin;
            }
            set
            {
                _horizontalMargin = value;
                LeftMarginPosition = Page.Width.Point * _horizontalMargin;
                RightMarginPosition = Page.Width.Point - LeftMarginPosition;
                PageAvailableWidth = Page.Width.Point - (LeftMarginPosition * 2);
            }
        }

        internal double VerticalMarginProportion
        {
            get
            {
                return _verticalMargin;
            }
            set
            {
                _verticalMargin = value;
                TopMarginPosition = Page.Height.Point * _verticalMargin;
                BottomMarginPosition = Page.Height.Point - TopMarginPosition;
            }
        }

        /// <summary>
        /// The horizontal coordinate of the right hand edge of the left margin.
        /// </summary>
        public double LeftMarginPosition { get; private set; }

        /// <summary>
        /// The horizontal coordinate of the left-hand edge of the right margin.
        /// </summary>
        public double RightMarginPosition { get; private set; }

        /// <summary>
        /// The vertical coordinate of the bottom edge of the top margin.
        /// </summary>
        public double TopMarginPosition { get; private set; }

        /// <summary>
        /// The vertical coordinate of the top edge of the bottom margin.
        /// </summary>
        public double BottomMarginPosition { get; private set; }

        /// <summary>
        /// The distance between inner edges of the left and right margins.
        /// </summary>
        public double PageAvailableWidth { get; private set; }

        /// <summary>
        /// Counter to keep track of the current position when composing a page.
        /// </summary>
        public double CurrentVerticalCursor { get; set; }
    }
}
