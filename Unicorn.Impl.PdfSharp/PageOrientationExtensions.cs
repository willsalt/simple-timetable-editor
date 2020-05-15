using PdfSharp;

namespace Unicorn.Impl.PdfSharp
{
    internal static class PageOrientationExtensions
    {
        internal static PageOrientation ToPdfSharpPageOrientation(this CoreTypes.PageOrientation orient)
        {
            switch (orient)
            {
                // PDFSharp does not support arbitrary page orientation.
                case CoreTypes.PageOrientation.Arbitrary:
                case CoreTypes.PageOrientation.Portrait:
                default:
                    return PageOrientation.Portrait;
                case CoreTypes.PageOrientation.Landscape:
                    return PageOrientation.Landscape;
            }
        }
    }
}
