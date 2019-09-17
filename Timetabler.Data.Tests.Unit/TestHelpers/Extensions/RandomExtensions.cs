using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Timetabler.Data.Tests.Unit.TestHelpers.Extensions
{
    public static class RandomExtensions
    {
        public static Color NextColor(this Random random)
        {
            return Color.FromArgb(random.Next());
        }

        public static DashStyle NextDashStyle(this Random random)
        {
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
