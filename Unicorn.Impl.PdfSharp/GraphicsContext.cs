using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Impl.PdfSharp.Extensions;
using Unicorn.Interfaces;

namespace Unicorn.Impl.PdfSharp
{
    /// <summary>
    /// PDFSharp implementation of <see cref="IGraphicsContext" />, for low-level drawing operations.
    /// </summary>
    public class GraphicsContext : IGraphicsContext
    {
        private readonly XGraphics _core;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="graphics">The PDFSharp <see cref="XGraphics" /> object which this context wraps.</param>
        public GraphicsContext(XGraphics graphics)
        {
            _core = graphics ?? throw new ArgumentNullException(nameof(graphics));
        }

        /// <summary>
        /// Draw a line between two points.
        /// </summary>
        /// <param name="x1">First X coordinate.</param>
        /// <param name="y1">First Y coordinate.</param>
        /// <param name="x2">Second X coordinate.</param>
        /// <param name="y2">Second Y coordinate.</param>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _core.DrawLine(XPens.Black, x1, y1, x2, y2);
        }

        /// <summary>
        /// Draw a line between two points.
        /// </summary>
        /// <param name="x1">First X coordinate.</param>
        /// <param name="y1">First Y coordinate.</param>
        /// <param name="x2">Second X coordinate.</param>
        /// <param name="y2">Second Y coordinate.</param>
        /// <param name="w">Line width.</param>
        public void DrawLine(double x1, double y1, double x2, double y2, double w)
        {
            DrawLine(x1, y1, x2, y2, w, UniDashStyle.Solid);
        }

        /// <summary>
        /// Draw a line between two points.
        /// </summary>
        /// <param name="x1">First X coordinate.</param>
        /// <param name="y1">First Y coordinate.</param>
        /// <param name="x2">Second X coordinate.</param>
        /// <param name="y2">Second Y coordinate.</param>
        /// <param name="w">Line width.</param>
        /// <param name="style">Drawing style of the line.</param>
        public void DrawLine(double x1, double y1, double x2, double y2, double w, UniDashStyle style)
        {
            XPen pen = new XPen(XColors.Black, w)
            {
                DashStyle = style.ToXDashStyle()
            };
            _core.DrawLine(pen, x1, y1, x2, y2);
        }

        /// <summary>
        /// Draw a filled polygon consisting of straight lines connecting an ordered set of vertexes in sequence.
        /// </summary>
        /// <param name="vertexes">The vertexes of the polygon to draw.</param>
        public void DrawFilledPolygon(IEnumerable<UniPoint> vertexes)
        {
            XBrush brush = XBrushes.Black;
            _core.DrawPolygon(brush, vertexes.Select(v => new XPoint(v.X, v.Y)).ToArray(), XFillMode.Alternate);
        }

        /// <summary>
        /// Draw a string with the given font at the given location.
        /// </summary>
        /// <param name="text">The string to write.</param>
        /// <param name="font">The font to use to draw.  This must be a <see cref="FontDescriptor"/> object.</param>
        /// <param name="x">X coordinate of the top-left corner of the drawn string.</param>
        /// <param name="y">Y coordinate of the top-left corner of the drawn string.</param>
        /// <exception cref="ArgumentException" />Thrown if the <see cref="IFontDescriptor" /> parameter is not a <see cref="FontDescriptor" /> object.  
        public void DrawString(string text, IFontDescriptor font, double x, double y)
        {
            if (!(font is FontDescriptor ourFont))
            {
                throw new ArgumentException(Resources.Error_FontDescriptorOfWrongSpecificType, nameof(font));
            }

            _core.DrawString(text, ourFont.Font, XBrushes.Black, x, y);
        }

        /// <summary>
        /// Draw a string with the given font, inside a fixed rectangle with the given horizontal and vertical alignment inside that rectangle.
        /// </summary>
        /// <param name="text">The string to write.</param>
        /// <param name="font">The font to use to draw.  This must be y <see cref="FontDescriptor"/> object.</param>
        /// <param name="rect">The bounding rectangle to draw the string in.</param>
        /// <param name="hAlign">The horizontal alignment of the string within the bounding rectangle.</param>
        /// <param name="vAlign">The vertical alignment of the string within the bounding rectangle.</param>
        /// <exception cref="ArgumentException" />Thrown if the <see cref="IFontDescriptor" /> paramter is not a <see cref="FontDescriptor" /> object.  
        public void DrawString(string text, IFontDescriptor font, UniRectangle rect, HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            if (!(font is FontDescriptor ourFont))
            {
                throw new ArgumentException(Resources.Error_FontDescriptorOfWrongSpecificType, nameof(font));
            }

            _core.DrawString(text, ourFont.Font, XBrushes.Black, new XRect(rect.Left, rect.Top, rect.Width, rect.Height), GetStringFormat(hAlign, vAlign));
        }

        private XStringFormat GetStringFormat(HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            switch (hAlign)
            {
                case HorizontalAlignment.Centred:
                    switch (vAlign)
                    {
                        default:
                        case VerticalAlignment.Bottom:
                            return XStringFormats.BottomCenter;
                        case VerticalAlignment.Centred:
                            return XStringFormats.Center;
                        case VerticalAlignment.Top:
                            return XStringFormats.TopCenter;
                        case VerticalAlignment.Baseline:
                            return XStringFormats.BaseLineCenter;
                    }
                default:
                case HorizontalAlignment.Justified:
                case HorizontalAlignment.Left:
                    switch (vAlign)
                    {
                        default:
                        case VerticalAlignment.Bottom:
                            return XStringFormats.BottomLeft;
                        case VerticalAlignment.Centred:
                            return XStringFormats.CenterLeft;
                        case VerticalAlignment.Top:
                            return XStringFormats.TopLeft;
                        case VerticalAlignment.Baseline:
                            return XStringFormats.BaseLineLeft;
                    }
                case HorizontalAlignment.Right:
                    switch(vAlign)
                    {
                        default:
                        case VerticalAlignment.Bottom:
                            return XStringFormats.BottomRight;
                        case VerticalAlignment.Centred:
                            return XStringFormats.CenterRight;
                        case VerticalAlignment.Top:
                            return XStringFormats.TopRight;
                        case VerticalAlignment.Baseline:
                            return XStringFormats.BaseLineRight;
                    }
            }
        }

        /// <summary>
        /// Measures the dimensions of a string drawn using this graphics context in a given font.
        /// </summary>
        /// <param name="text">The text to measure.</param>
        /// <param name="font">The font to use to render the string.  Must be a <see cref="FontDescriptor"/> object.</param>
        /// <returns>The dimensions of the string when rendered.</returns>
        /// <exception cref="ArgumentException" />Thrown if the <see cref="IFontDescriptor" /> paramter is not a <see cref="FontDescriptor" /> instance.  
        public UniTextSize MeasureString(string text, IFontDescriptor font)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            if (!(font is FontDescriptor ourFont))
            {
                throw new ArgumentException(Resources.Error_FontDescriptorOfWrongSpecificType, nameof(font));
            }

            var size = _core.MeasureString(text, ourFont.Font);
            return new UniTextSize(size.Width, font.PointSize, font.Ascent + font.InterlineSpacing / 2, font.Ascent, font.Descent);
        }

        /// <summary>
        /// Restore the saved state of the context.
        /// </summary>
        /// <param name="state">The state to restore.  Must be a <see cref="GraphicsState" /> object.</param>
        /// <exception cref="ArgumentException" />Thrown if the <see cref="IGraphicsState" /> parameter is not a <see cref="GraphicsState" /> instance.  
        public void Restore(IGraphicsState state)
        {
            if (!(state is GraphicsState ourState))
            {
                throw new ArgumentException(Resources.Error_FontDescriptorOfWrongSpecificType, nameof(state));
            }

            _core.Restore(ourState.InnerState);
        }

        /// <summary>
        /// Rotate the context.
        /// </summary>
        /// <param name="angle">The angle to rotate by, in degrees.</param>
        /// <param name="x">The X-coordinate of the centre of rotation.</param>
        /// <param name="y">The Y-coordinate of the centre of rotation.</param>
        public void RotateAt(double angle, double x, double y)
        {
            _core.RotateAtTransform(angle, new XPoint(x, y));
        }

        /// <summary>
        /// Save the state of this context in a form that can be restored later.
        /// </summary>
        /// <returns>A <see cref="GraphicsState" /> object representing the current state of this context.</returns>
        public IGraphicsState Save()
        {
            return new GraphicsState(_core.Save());
        }

        /// <summary>
        /// Draw a rectangle.
        /// </summary>
        /// <param name="xTopLeft">The X-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="yTopLeft">The Y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="width">The rectangle width.</param>
        /// <param name="height">The rectangle height.</param>
        public void DrawRectangle(double xTopLeft, double yTopLeft, double width, double height)
        {
            _core.DrawRectangle(XPens.Black, xTopLeft, yTopLeft, width, height);
        }

        /// <summary>
        /// Draw a rectangle.
        /// </summary>
        /// <param name="xTopLeft">The X-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="yTopLeft">The Y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="rectWidth">The rectangle width.</param>
        /// <param name="rectHeight">The rectangle height.</param>
        /// <param name="lineWidth">The width of the line used to draw the rectangle.</param>
        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight, double lineWidth)
        {
            XPen pen = new XPen(XColors.Black, lineWidth);
            _core.DrawRectangle(pen, xTopLeft, yTopLeft, rectWidth, rectHeight);
        }
    }
}
