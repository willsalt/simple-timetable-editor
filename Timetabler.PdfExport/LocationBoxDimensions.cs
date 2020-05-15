using System.Collections.Generic;
using System.Linq;
using Unicorn.CoreTypes;

namespace Timetabler.PdfExport
{
    internal class LocationBoxDimensions
    {
        internal UniSize TotalSize { get; set; }

        internal Dictionary<string, TextVerticalLocation> LocationOffsets { get; set; }

        internal List<TextVerticalLocation> LocationOffsetList
        {
            get
            {
               return LocationOffsets.Values.Cast<TextVerticalLocation>().OrderBy(t => t.Top).ToList();
            }
        }

        internal Dictionary<string, bool> LocationParity { get; set; }

        internal Dictionary<string, int> LocationFillerDotCounts { get; set; }

        internal List<double> LocationSeparatorOffsets { get; set; }

        internal LocationBoxDimensions()
        {
            LocationOffsets = new Dictionary<string, TextVerticalLocation>();
            LocationParity = new Dictionary<string, bool>();
            LocationFillerDotCounts = new Dictionary<string, int>();
            LocationSeparatorOffsets = new List<double>();
        }
    }
}
