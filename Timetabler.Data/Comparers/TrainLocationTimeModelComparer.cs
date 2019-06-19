using System.Collections.Generic;
using Timetabler.Data.Display;

namespace Timetabler.Data.Comparers
{
    public class TrainLocationTimeModelComparer : IComparer<TrainLocationTimeModel>
    {
        public static TrainLocationTimeModelComparer Default = new TrainLocationTimeModelComparer();

        public int Compare(TrainLocationTimeModel x, TrainLocationTimeModel y)
        {
            if (x?.ActualTime == null)
            {
                return (y?.ActualTime == null) ? 0 : -1;
            }
            if (y?.ActualTime == null)
            {
                return 1;
            }
            return x.ActualTime.CompareTo(y.ActualTime);
        }
    }
}
