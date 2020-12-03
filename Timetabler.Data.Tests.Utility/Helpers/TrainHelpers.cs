using System;
using System.Diagnostics.CodeAnalysis;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Utility.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class TrainHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static Train GetTrain(bool? withToWork = null, bool? withLocoToWork = null, int? minutesBeforeMidnight = null, bool withHeadcode = true,
            bool withLocoDiagram = true, bool withTrainClass = true, bool? withFootnotes = null)
        {
            TimeOfDay beforeMidnight;
            if (!minutesBeforeMidnight.HasValue)
            {
                beforeMidnight = new TimeOfDay(86399);
            }
            else
            {
                beforeMidnight = new TimeOfDay(86399 - (minutesBeforeMidnight.Value * 60));
            }
            Train t = new Train
            {
                Headcode = withHeadcode ? _rnd.NextString(_rnd.Next(2, 5)) : null,
                LocoDiagram = withLocoDiagram ? _rnd.NextString(_rnd.Next(2, 5)) : null,
                TrainClass = withTrainClass ? TrainClassHelpers.GetTrainClass() : null,
                IncludeSeparatorAbove = _rnd.NextBoolean(),
                IncludeSeparatorBelow = _rnd.NextBoolean(),
                InlineNote = _rnd.NextString(_rnd.Next(100)),
                GraphProperties = _rnd.NextGraphTrainProperties(),
            };
            t.TrainTimes.AddRange(TrainLocationTimeHelpers.GetTrainLocationTimeList(2, 20, beforeMidnight));
            t.TrainClassId = t.TrainClass?.Id;
            if (withToWork ?? _rnd.NextBoolean())
            {
                t.ToWork = ToWorkHelpers.GetToWork();
            }
            if (withLocoToWork ?? _rnd.NextBoolean())
            {
                t.LocoToWork = ToWorkHelpers.GetToWork();
            }
            if (withFootnotes ?? _rnd.NextBoolean())
            {
                t.Footnotes.AddRange(NoteHelpers.GetNoteList(true));
            }
            return t;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
