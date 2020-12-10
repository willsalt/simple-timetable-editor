using System;
using System.Diagnostics.CodeAnalysis;
using Tests.Utility.Extensions;
using Timetabler.CoreData;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Utility.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class RandomExtensions
    {

#pragma warning disable CA5394 // Do not use insecure randomness

        public static ClockType NextClockType(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            return (random.Next(2) == 0) ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;
        }

        public static GraphEditStyle NextGraphEditStyle(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            GraphEditStyle[] styles = new[] { GraphEditStyle.Free, GraphEditStyle.PreserveSectionTimes };

            return styles[random.Next(styles.Length)];
        }

        public static Note NextNote(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            return new Note
            {
                AppliesToTimings = random.NextBoolean(),
                AppliesToTrains = random.NextBoolean(),
                DefinedInGlossary = random.NextBoolean(),
                DefinedOnPages = random.NextBoolean(),
                Definition = random.NextString(random.Next(50)),
                Id = random.NextHexString(8),
                Symbol = random.NextString(random.Next(1, 2)),
            };
        }

        public static GraphTrainProperties NextGraphTrainProperties(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            return new GraphTrainProperties
            {
                Colour = random.NextColour(),
                DashStyle = random.NextDashStyle(),
                Width = (float)(random.NextDouble() * random.Next(1, 4)),
            };
        }

        public static Colour NextColour(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return new Colour(random.NextUInt());
        }

        public static DashStyle NextDashStyle(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            DashStyle[] allValues = new DashStyle[]
            {
                DashStyle.Dash,
                DashStyle.DashDot,
                DashStyle.DashDotDot,
                DashStyle.Dot,
                DashStyle.Solid,
            };
            return allValues[random.Next(allValues.Length)];
        }

        public static Distance NextDistance(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            int miles = random.Next(200);
            double chains = random.NextDouble() * 80;
            return new Distance(miles, chains);
        }

        public static Distance NextDistance(this Random random, Distance min)
        {
            return min + NextDistance(random);
        }

        public static TrainLocationTimeEntryType NextTrainLocationTimeEntryType(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            TrainLocationTimeEntryType[] values = new[] { TrainLocationTimeEntryType.RoutingCode, TrainLocationTimeEntryType.Time };
            return values[rnd.Next(values.Length)];
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
