using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    internal static class TrainTimeHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

        internal static TrainTime GetTrainTime(int? footnoteCount = null)
        {
            TrainTime tt = new TrainTime
            {
                Time = _rnd.NextTimeOfDay(),
            };
            return AddFootnotesToTrainTime(tt, footnoteCount);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

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

#pragma warning restore CA5394 // Do not use insecure randomness

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

        internal static TrainTime GetTrainTimeNotAt(TimeOfDay time, int? footnoteCount = null)
        {
            TrainTime tt = new TrainTime { Time = _rnd.NextBoolean() ? _rnd.NextTimeOfDayAfter(time) : _rnd.NextTimeOfDayBefore(time) };
            return AddFootnotesToTrainTime(tt, footnoteCount);
        }
    }
}
