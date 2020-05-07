using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Interfaces;
using Unicorn.Writer.Dummy;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// This class defines drawing operations, is responsible for writing drawing operators to a page content stream, and also maintains metadata about the
    /// state of the current page.
    /// </summary>
    public class PageGraphics : IGraphicsContext
    {
        /// <summary>
        /// The page that this graphics context belongs to.
        /// </summary>
        private readonly PdfPage _page;

        /// <summary>
        /// The content stream for the current page.
        /// </summary>
        private PdfStream PageStream { get; set; }

        private readonly Func<double, double> _xTransformer;

        private readonly Func<double, double> _yTransformer;

        /// <summary>
        /// Current path stroking width.
        /// </summary>
        private double CurrentLineWidth { get; set; }

        /// <summary>
        /// Current path stroking dash style.
        /// </summary>
        private UniDashStyle CurrentDashStyle { get; set; }

        /// <summary>
        /// Indicates if the line width has been changed more recently than the dash style.
        /// </summary>
        private bool LineWidthChanged { get; set; }

        private IFontDescriptor CurrentFont { get; set; } = null;

        /// <summary>
        /// Constructor.  Requires methods for mapping coordinates from Unicorn-space (with the Y-origin at the top of the page, like most desktop drawing libraries)
        /// to PDF user space (with the Y-origin at the bottom of the page, like a graph).
        /// </summary>
        /// <param name="parentPage">The page that this graphics object belongs to.</param>
        /// <param name="contentStream">The stream to write content for this page to.</param>
        /// <param name="xTransform">A transform function for converting Unicorn-space X coordinates.</param>
        /// <param name="yTransform">A transform function for converting Unicorn-space Y coordinates.</param>
        public PageGraphics(PdfPage parentPage, PdfStream contentStream, Func<double, double> xTransform, Func<double, double> yTransform)
        {
            if (contentStream is null)
            {
                throw new ArgumentNullException(nameof(contentStream));
            }
            if (parentPage is null)
            {
                throw new ArgumentNullException(nameof(parentPage));
            }
            _page = parentPage;
            PageStream = contentStream;
            _xTransformer = xTransform ?? (x => x);
            _yTransformer = yTransform ?? (x => x);
            CurrentLineWidth = -1;
            CurrentDashStyle = UniDashStyle.Solid;
        }

        /// <summary>
        /// Save the current state.
        /// </summary>
        /// <returns></returns>
        public IGraphicsState Save()
        {
            // dummy code
            return new DummyGraphicsState();
        }

        /// <summary>
        /// Restore a previous state.
        /// </summary>
        /// <param name="state">The state to be restored.</param>
        public void Restore(IGraphicsState state)
        {
            
        }

        /// <summary>
        /// Rotate the coordinate system around a point.
        /// </summary>
        /// <param name="angle">The angle to rotate by.</param>
        /// <param name="x">The X coordinate of the centre of rotation.</param>
        /// <param name="y">The Y coordinate of the centre of rotation.</param>
        public void RotateAt(double angle, double x, double y)
        {
            
        }

        /// <summary>
        /// Draw a straight solid line of 1pt width.
        /// </summary>
        /// <param name="x1">X-coordinate of the starting point.</param>
        /// <param name="y1">Y-coordinate of the starting point.</param>
        /// <param name="x2">X-coordinate of the ending point.</param>
        /// <param name="y2">Y-coordinate of the ending point.</param>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            DrawLine(x1, y1, x2, y2, 1d, UniDashStyle.Solid);
        }

        /// <summary>
        /// Draw a straight solid line of specified width. 
        /// </summary>
        /// <param name="x1">X-coordinate of the starting point.</param>
        /// <param name="y1">Y-coordinate of the starting point.</param>
        /// <param name="x2">X-coordinate of the ending point.</param>
        /// <param name="y2">Y-coordinate of the ending point.</param>
        /// <param name="width">Width of the line.</param>
        public void DrawLine(double x1, double y1, double x2, double y2, double width)
        {
            DrawLine(x1, y1, x2, y2, width, UniDashStyle.Solid);
        }

        /// <summary>
        /// Draw a straight line with specified width and dash pattern.
        /// </summary>
        /// <param name="x1">X-coordinate of the starting point.</param>
        /// <param name="y1">Y-coordinate of the starting point.</param>
        /// <param name="x2">X-coordinate of the ending point.</param>
        /// <param name="y2">Y-coordinate of the ending point.</param>
        /// <param name="width">Width of the line.</param>
        /// <param name="style">Dash pattern of the line.</param>
        public void DrawLine(double x1, double y1, double x2, double y2, double width, UniDashStyle style)
        {
            ChangeLineWidth(width);
            ChangeDashStyle(style);
            PdfOperator.StartPath(new PdfReal(_xTransformer(x1)), new PdfReal(_yTransformer(y1))).WriteTo(PageStream);
            PdfOperator.AppendStraightLine(new PdfReal(_xTransformer(x2)), new PdfReal(_yTransformer(y2))).WriteTo(PageStream);
            PdfOperator.StrokePath().WriteTo(PageStream);
        }

        /// <summary>
        /// Draw a filled polygon.
        /// </summary>
        /// <param name="vertexes">List of vertexes of the polygon.</param>
        public void DrawFilledPolygon(IEnumerable<UniPoint> vertexes)
        {
            
        }

        /// <summary>
        /// Draw a non-filled rectangle with line width 1pt.
        /// </summary>
        /// <param name="xTopLeft">X-coordinate of the top left corner of the rectangle.</param>
        /// <param name="yTopLeft">Y-coordinate of the top left corner of the rectangle.</param>
        /// <param name="rectWidth">Width of the rectangle.</param>
        /// <param name="rectHeight">Height of the rectangle.</param>
        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight)
        {
            DrawRectangle(xTopLeft, yTopLeft, rectWidth, rectHeight, 1d);
        }

        /// <summary>
        /// Draw a non-filled rectangle of specified line width.
        /// </summary>
        /// <param name="xTopLeft">X-coordinate of the top left corner of the rectangle.</param>
        /// <param name="yTopLeft">Y-coordinate of the top left corner of the rectangle.</param>
        /// <param name="rectWidth">Width of the rectangle.</param>
        /// <param name="rectHeight">Height of the rectangle.</param>
        /// <param name="lineWidth">Stroke width.</param>
        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight, double lineWidth)
        {
            ChangeLineWidth(lineWidth);
            ChangeDashStyle(UniDashStyle.Solid);
            PdfOperator.AppendRectangle(new PdfReal(_xTransformer(xTopLeft)), new PdfReal(_yTransformer(yTopLeft + rectHeight)), 
                new PdfReal(rectWidth), new PdfReal(rectHeight))
                .WriteTo(PageStream);
            PdfOperator.StrokePath().WriteTo(PageStream);
        }

        /// <summary>
        /// Draw a string.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="font">The font to use</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawString(string text, IFontDescriptor font, double x, double y)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            PdfOperator.StartText().WriteTo(PageStream);
            ChangeFont(font);
            PdfOperator.SetTextLocation(new PdfReal(_xTransformer(x)), new PdfReal(_yTransformer(y))).WriteTo(PageStream);
            PdfOperator.DrawText(new PdfByteString(font.PreferredEncoding.GetBytes(text))).WriteTo(PageStream);
            PdfOperator.EndText().WriteTo(PageStream);
        }

        private void ChangeFont(IFontDescriptor font)
        {
            if (font != CurrentFont)
            {
                PdfFont pageFont = _page.UseFont(font);
                PdfOperator.SetTextFont(pageFont.InternalName, new PdfReal(font.PointSize)).WriteTo(PageStream);
                CurrentFont = font;
            }
        }

        /// <summary>
        /// Draw a string inside a bounding box.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="hAlign"></param>
        /// <param name="vAlign"></param>
        public void DrawString(string text, IFontDescriptor font, UniRectangle rect, HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            var stringBox = MeasureString(text, font);
            double x;
            double y;
            switch (hAlign)
            {
                case HorizontalAlignment.Left:
                    x = rect.Left;
                    break;
                case HorizontalAlignment.Right:
                    x = rect.Left + rect.Width - stringBox.Width;
                    break;
                default:
                    x = rect.Left + (rect.Width - stringBox.Width) / 2;
                    break;
            }
            switch (vAlign)
            {
                case VerticalAlignment.Bottom:
                    y = rect.Top + rect.Height + font.Descent;
                    break;
                case VerticalAlignment.Top:
                    y = rect.Top + stringBox.Height + font.Descent;
                    break;
                default:
                    y = rect.Top + (rect.Height + stringBox.Height) / 2 + font.Descent;
                    break;
            }
            DrawString(text, font, x, y);
        }

        /// <summary>
        /// Measure the dimensions of a string, if it were to be drawn.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public UniSize MeasureString(string text, IFontDescriptor font)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            return font.MeasureString(text);
        }

        private void ChangeLineWidth(double width)
        {
            if (width != CurrentLineWidth)
            {
                PdfOperator.LineWidth(new PdfReal(width)).WriteTo(PageStream);
                CurrentLineWidth = width;
                LineWidthChanged = true;
            }
        }

        private void ChangeDashStyle(UniDashStyle style)
        {
            if (style != CurrentDashStyle || (LineWidthChanged && style != UniDashStyle.Solid))
            {
                IPdfPrimitiveObject[] operands = style.ToPdfObjects(CurrentLineWidth);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(PageStream);
                CurrentDashStyle = style;
                LineWidthChanged = false;
            }
        }
    }
}
