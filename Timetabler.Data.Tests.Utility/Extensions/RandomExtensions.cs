using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Utility.Extensions
{
    public static class RandomExtensions
    {
        public static ClockType NextClockType(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }

            return (random.Next(2) == 0) ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock; 
        }

        public static GraphEditStyle NextGraphEditStyle(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }

            GraphEditStyle[] styles = new[] { GraphEditStyle.Free, GraphEditStyle.PreserveSectionTimes };

            return styles[random.Next(styles.Length)];
        }

        public static Note NextNote(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
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
                throw new NullReferenceException();
            }

            return new GraphTrainProperties
            {
                Colour = random.NextColor(),
                DashStyle = random.NextDashStyle(),
                Width = (float)(random.NextDouble() * random.Next(1, 4)),
            };
        }

        public static Color NextColor(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return Color.FromArgb(random.Next());
        }

        public static DashStyle NextDashStyle(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            DashStyle[] allValues = new DashStyle[]
            {
                DashStyle.Custom,
                DashStyle.Dash,
                DashStyle.DashDot,
                DashStyle.DashDotDot,
                DashStyle.Dot,
                DashStyle.Solid,
            };
            return allValues[random.Next(allValues.Length)];
        }
    }
}
