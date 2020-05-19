using Timetabler.CoreData;
using Unicorn.CoreTypes;

namespace Timetabler.PdfExport.Extensions
{
    internal static class OrientationExtensions
    {
        internal static PageOrientation ToPageOrientation(this Orientation val)
        {
            switch (val)
            {
                case Orientation.Landscape:
                default:
                    return PageOrientation.Landscape;
                case Orientation.Portrait:
                    return PageOrientation.Portrait;
            }
        }
    }
}
