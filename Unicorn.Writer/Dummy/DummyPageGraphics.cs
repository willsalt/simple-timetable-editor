using System.Collections.Generic;
using Unicorn.Interfaces;

namespace Unicorn.Writer.Dummy
{
    /// <summary>
    /// Dummy class pending implementation.
    /// </summary>
    public class DummyPageGraphics : IGraphicsContext
    {
        /// <summary>
        /// Draw a filled polygon - dummy method.
        /// </summary>
        /// <param name="vertexes"></param>
        public void DrawFilledPolygon(IEnumerable<UniPoint> vertexes)
        {
            
        }

        /// <summary>
        /// Draw a line - dummy method
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            
        }

        /// <summary>
        /// Draw a line - dummy method
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="width"></param>
        public void DrawLine(double x1, double y1, double x2, double y2, double width)
        {
            
        }

        /// <summary>
        /// Draw a line - dummy method
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="width"></param>
        /// <param name="style"></param>
        public void DrawLine(double x1, double y1, double x2, double y2, double width, UniDashStyle style)
        {
            
        }

        /// <summary>
        /// Draw a rectangle - dummy method
        /// </summary>
        /// <param name="xTopLeft"></param>
        /// <param name="yTopLeft"></param>
        /// <param name="rectWidth"></param>
        /// <param name="rectHeight"></param>
        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight)
        {
            
        }

        /// <summary>
        /// Draw a rectangle - dummy method
        /// </summary>
        /// <param name="xTopLeft"></param>
        /// <param name="yTopLeft"></param>
        /// <param name="rectWidth"></param>
        /// <param name="rectHeight"></param>
        /// <param name="lineWidth"></param>
        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight, double lineWidth)
        {
            
        }

        /// <summary>
        /// Draw a string - dummy method
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawString(string text, IFontDescriptor font, double x, double y)
        {
            
        }

        /// <summary>
        /// Draw a string - dummy method
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="hAlign"></param>
        /// <param name="vAlign"></param>
        public void DrawString(string text, IFontDescriptor font, UniRectangle rect, HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            
        }

        /// <summary>
        /// Measure a string - dummy method that returns a very rough approximation.
        /// </summary>
        /// <param name="text">The text to be measured</param>
        /// <param name="font">The font in which the text is to be displayed</param>
        /// <returns></returns>
        public UniSize MeasureString(string text, IFontDescriptor font)
        {
            return new UniSize((text ?? "").Length * 5, 7.2);
        }

        /// <summary>
        /// Restore a saved state - dummy method
        /// </summary>
        /// <param name="state"></param>
        public void Restore(IGraphicsState state)
        {
            
        }

        /// <summary>
        /// Rotate the context - dummy method
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RotateAt(double angle, double x, double y)
        {
            
        }

        /// <summary>
        /// Save the state - dummy method
        /// </summary>
        /// <returns></returns>
        public IGraphicsState Save()
        {
            return new DummyGraphicsState();
        }
    }
}
