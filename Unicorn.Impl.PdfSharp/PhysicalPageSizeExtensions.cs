using PdfSharp;
using Unicorn.Interfaces;

namespace Unicorn.Impl.PdfSharp
{
    internal static class PhysicalPageSizeExtensions
    {
        internal static PageSize ToPdfSharpPageSize(this PhysicalPageSize size)
        {
            switch (size)
            {
                case PhysicalPageSize.A1:
                    return PageSize.A1;
                case PhysicalPageSize.A2:
                    return PageSize.A2;
                case PhysicalPageSize.A3:
                    return PageSize.A3;
                case PhysicalPageSize.A4:
                default:
                    return PageSize.A4;
                case PhysicalPageSize.A5:
                    return PageSize.A5;
                case PhysicalPageSize.A6:
                    return PageSize.Undefined;
            }
        }
    }
}
