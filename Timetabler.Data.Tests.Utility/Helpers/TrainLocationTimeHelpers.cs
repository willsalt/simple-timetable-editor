using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;

namespace Timetabler.Data.Tests.Utility.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class TrainLocationTimeHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static IList<TrainLocationTime> GetTrainLocationTimeList(int min, int max, TimeOfDay beforeTime)
        {
            int count = _rnd.Next(min, max);
            List<TrainLocationTime> items = new List<TrainLocationTime>(count);
            for (int i = 0; i < count; ++i)
            {
                TrainLocationTime item = GetTrainLocationTime(beforeTime);
                items.Add(item);
            }
            return items;
        }

        public static TrainLocationTime GetTrainLocationTime(TimeOfDay beforeTime)
        {
            return new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTimeBefore(beforeTime),
                DepartureTime = TrainTimeHelpers.GetTrainTimeBefore(beforeTime),
                FormattingStrings = new TimeDisplayFormattingStrings
                {
                    Complete = "h{0}mmf",
                    Hours = "h",
                    Minutes = "mmf",
                    TimeWithoutFootnotes = "h mmf",
                },
                Line = _rnd.NextString(_rnd.Next(2)),
                Location = new Location(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
            };
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
