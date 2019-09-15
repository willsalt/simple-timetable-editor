using System.Collections.Generic;
using Unicorn.Interfaces;

namespace Unicorn.Writer.Dummy
{
    public class DummyPageGraphics : IGraphicsContext
    {
        public void DrawFilledPolygon(IEnumerable<UniPoint> vertexes)
        {
            
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            
        }

        public void DrawLine(double x1, double y1, double x2, double y2, double width)
        {
            
        }

        public void DrawLine(double x1, double y1, double x2, double y2, double width, UniDashStyle style)
        {
            
        }

        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight)
        {
            
        }

        public void DrawRectangle(double xTopLeft, double yTopLeft, double rectWidth, double rectHeight, double lineWidth)
        {
            
        }

        public void DrawString(string text, IFontDescriptor font, double x, double y)
        {
            
        }

        public void DrawString(string text, IFontDescriptor font, UniRectangle rect, HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            
        }

        public UniSize MeasureString(string text, IFontDescriptor font)
        {
            return new UniSize((text ?? "").Length * 5, 7.2);
        }

        public void Restore(IGraphicsState state)
        {
            
        }

        public void RotateAt(double angle, double x, double y)
        {
            
        }

        public IGraphicsState Save()
        {
            return new DummyGraphicsState();
        }
    }
}
