using System;
using Tests.Utility.Extensions;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class GenericTimeModelHelpers
    {
        private static Random _random = new Random();

        public static GenericTimeModel GetGenericTimeModel()
        {
            return new GenericTimeModel
            {
                ActualTime = _random.NextTimeOfDay(),
                DisplayedText = _random.NextString(_random.Next(2, 6)),
                EntryType = TrainLocationTimeEntryType.Time,
            };
        }
    }
}
