using System;
using Unicorn.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    public static class PhysicalPageSizeExtensions
    {
        private static Lazy<PdfRectangle> _a1Portrait = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 1683, 2383));
        private static Lazy<PdfRectangle> _a2Portrait = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 1190, 1683));
        private static Lazy<PdfRectangle> _a3Portrait = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 841, 1190));
        private static Lazy<PdfRectangle> _a4Portrait = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 595, 841));
        private static Lazy<PdfRectangle> _a5Portrait = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 419, 595));
        private static Lazy<PdfRectangle> _a6Portrait = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 297, 419));
        private static Lazy<PdfRectangle> _a1Landscape = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 2383, 1683));
        private static Lazy<PdfRectangle> _a2Landscape = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 1683, 1190));
        private static Lazy<PdfRectangle> _a3Landscape = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 1190, 841));
        private static Lazy<PdfRectangle> _a4Landscape = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 841, 595));
        private static Lazy<PdfRectangle> _a5Landscape = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 595, 419));
        private static Lazy<PdfRectangle> _a6Landscape = new Lazy<PdfRectangle>(() => new PdfRectangle(0, 0, 419, 297));

        public static PdfRectangle ToPdfRectangle(this PhysicalPageSize pageSize)
        {
            switch (pageSize)
            {
                case PhysicalPageSize.A1:
                    return _a1Portrait.Value;
                case PhysicalPageSize.A2:
                    return _a2Portrait.Value;
                case PhysicalPageSize.A3:
                    return _a3Portrait.Value;
                case PhysicalPageSize.A4:
                    return _a4Portrait.Value;
                case PhysicalPageSize.A5:
                    return _a5Portrait.Value;
                case PhysicalPageSize.A6:
                    return _a6Portrait.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
        }

        public static PdfRectangle ToPdfRectangle(this PhysicalPageSize pageSize, PageOrientation orientation)
        {
            if (orientation != PageOrientation.Landscape)
            {
                return pageSize.ToPdfRectangle();
            }
            switch (pageSize)
            {
                case PhysicalPageSize.A1:
                    return _a1Landscape.Value;
                case PhysicalPageSize.A2:
                    return _a2Landscape.Value;
                case PhysicalPageSize.A3:
                    return _a3Landscape.Value;
                case PhysicalPageSize.A4:
                    return _a4Landscape.Value;
                case PhysicalPageSize.A5:
                    return _a5Landscape.Value;
                case PhysicalPageSize.A6:
                    return _a6Landscape.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
        }
    }
}
