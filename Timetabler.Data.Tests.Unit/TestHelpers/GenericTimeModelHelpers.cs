using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class GenericTimeModelHelpers
    {
        private static readonly Random _random = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static GenericTimeModel GetGenericTimeModel() => new GenericTimeModel
        {
            ActualTime = _random.NextTimeOfDay(),
            DisplayedText = _random.NextString(_random.Next(2, 6)),
            EntryType = TrainLocationTimeEntryType.Time,
        };

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
