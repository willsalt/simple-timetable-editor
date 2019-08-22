using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    internal static class TrainTimeHelpers
    {
        private static Random _rnd = RandomProvider.Default;

        internal static TrainTime GetTrainTime(int? footnoteCount = null)
        {
            TrainTime tt = new TrainTime
            {
                Time = _rnd.NextTimeOfDay(),
            };
            return AddFootnotesToTrainTime(tt, footnoteCount);
        }

        private static TrainTime AddFootnotesToTrainTime(TrainTime tt, int? footnoteCount)
        {
            if (!footnoteCount.HasValue)
            {
                footnoteCount = _rnd.Next(4);
            }
            for (int i = 0; i < footnoteCount.Value; ++i)
            {
                tt.Footnotes.Add(new Note { Symbol = _rnd.NextString(1) });
            }
            return tt;
        }

        internal static TrainTime GetTrainTimeBefore(TimeOfDay time, int? footnoteCount = null)
        {
            TrainTime tt = new TrainTime { Time = _rnd.NextTimeOfDayBefore(time) };
            return AddFootnotesToTrainTime(tt, footnoteCount);
        }

        internal static TrainTime GetTrainTimeAfter(TimeOfDay time, int? footnoteCount = null)
        {
            TrainTime tt = new TrainTime { Time = _rnd.NextTimeOfDayAfter(time) };
            return AddFootnotesToTrainTime(tt, footnoteCount);
        }

        internal static TrainTime GetTrainTimeAt(TimeOfDay time, int? footnoteCount = null)
        {
            TrainTime tt = new TrainTime { Time = time.Copy() };
            return AddFootnotesToTrainTime(tt, footnoteCount);
        }
    }
}
