using PdfSharp;

namespace Unicorn.Impl.PdfSharp
{
    internal static class PageOrientationExtensions
    {
        internal static PageOrientation ToPdfSharpPageOrientation(this Interfaces.PageOrientation orient)
        {
            switch (orient)
            {
                // PDFSharp does not support arbitrary page orientation.
                case Interfaces.PageOrientation.Arbitrary:
                case Interfaces.PageOrientation.Portrait:
                default:
                    return PageOrientation.Portrait;
                case Interfaces.PageOrientation.Landscape:
                    return PageOrientation.Landscape;
            }
        }
    }
}
