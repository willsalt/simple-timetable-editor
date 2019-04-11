using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Timetabler.CoreData.Helpers;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class TrainSegmentModelHelpers
    {
        public static Random _random = new Random();

        public static TrainSegmentModel GetTrainSegmentModel()
        {
            TrainSegmentModel tsm = new TrainSegmentModel
            {
                Footnotes = _random.NextString(_random.Next(0, 5)),
                HalfOfDay = _random.NextString(_random.Next(0, 3)),
                Headcode = _random.NextString(_random.Next(0, 4)),
                IncludeSeparatorAbove = _random.NextBoolean(),
                IncludeSeparatorBelow = _random.NextBoolean(),
                InlineNote = _random.NextString(_random.Next(0, 256)),
                LocoDiagram = _random.NextString(_random.Next(0, 4)),
                Timings = TrainLocationTimeModelHelpers.GetTrainLocationTimeModelList(2, _random.Next(2, 24)),
                ToWorkCell = GenericTimeModelHelpers.GetGenericTimeModel(),
                TrainClass = _random.NextString(1),
                TrainId = GeneralHelper.GetNewId(new Train[0])
            };
            tsm.TimingsIndex = tsm.Timings.ToDictionary(t => t.LocationKey, t => t);
            return tsm;
        }

        public static List<TrainSegmentModel> GetTrainSegmentModelList(int min, int max)
        {
            int count = _random.Next(min, max);
            List<TrainSegmentModel> output = new List<TrainSegmentModel>(count);
            for (int i = 0; i < count; ++i)
            {
                output.Add(GetTrainSegmentModel());
            }
            return output;
        }

        public static List<TrainSegmentModel> GetTrainSegmentModelList(int max)
        {
            return GetTrainSegmentModelList(0, max);
        }
    }
}
