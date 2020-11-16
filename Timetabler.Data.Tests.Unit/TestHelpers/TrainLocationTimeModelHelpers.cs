using System;
using System.Collections.Generic;
using Tests.Utility;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData.Helpers;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class TrainLocationTimeModelHelpers
    {
        private static Random _random = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static TrainLocationTimeModel GetTrainLocationTimeModel(IEnumerable<MinimalUniqueItem> existingItems)
        {
            string locId = GeneralHelper.GetNewId(existingItems);
            return new TrainLocationTimeModel
            {
                ActualTime = _random.NextTimeOfDay(),
                DisplayedText = _random.NextString(_random.Next(2, 6)),
                EntryType = TrainLocationTimeEntryType.Time,
                IsPassingTime = _random.NextBoolean(),
                LocationId = locId,
                LocationKey = locId,
            };
        }

        public static IList<ILocationEntry> GetTrainLocationTimeModelList(int min, int max)
        {
            int count = _random.Next(min, max);
            List<ILocationEntry> items = new List<ILocationEntry>(count);
            List<MinimalUniqueItem> ids = new List<MinimalUniqueItem>(count);
            for (int i = 0; i < count; ++i)
            {
                TrainLocationTimeModel item = GetTrainLocationTimeModel(ids);
                items.Add(item);
                ids.Add(new MinimalUniqueItem { Id = item.LocationKey });
            }
            return items;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
