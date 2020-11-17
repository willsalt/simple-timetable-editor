using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData.Helpers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class TrainSegmentModelHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static TrainSegmentModel GetTrainSegmentModel()
        {
            TrainSegmentModel tsm = new TrainSegmentModel(TrainLocationTimeModelHelpers.GetTrainLocationTimeModelList(2, _rnd.Next(2, 24)))
            {
                Footnotes = _rnd.NextString(_rnd.Next(0, 5)),
                Headcode = _rnd.NextString(_rnd.Next(0, 4)),
                IncludeSeparatorAbove = _rnd.NextBoolean(),
                IncludeSeparatorBelow = _rnd.NextBoolean(),
                InlineNote = _rnd.NextString(_rnd.Next(0, 256)),
                LocoDiagram = _rnd.NextString(_rnd.Next(0, 4)),
                ToWorkCell = GenericTimeModelHelpers.GetGenericTimeModel(),
                TrainClass = _rnd.NextString(1),
                TrainId = GeneralHelper.GetNewId(Array.Empty<Train>()),
            };
            return tsm;
        }

        public static IList<TrainSegmentModel> GetTrainSegmentModelList(int min, int max)
        {
            int count = _rnd.Next(min, max);
            List<TrainSegmentModel> output = new List<TrainSegmentModel>(count);
            for (int i = 0; i < count; ++i)
            {
                output.Add(GetTrainSegmentModel());
            }
            return output;
        }

        public static IList<TrainSegmentModel> GetTrainSegmentModelList(int max)
        {
            return GetTrainSegmentModelList(0, max);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
