using Unicorn.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    public static class PhysicalPageSizeExtensions
    {
        public static PdfRectangle ToPdfRectangle(this PhysicalPageSize pageSize)
        {
            return pageSize.ToUniSize().ToPdfRectangle();
        }

        public static PdfRectangle ToPdfRectangle(this PhysicalPageSize pageSize, PageOrientation orientation)
        {
            return pageSize.ToUniSize(orientation).ToPdfRectangle();
        }
    }
}
