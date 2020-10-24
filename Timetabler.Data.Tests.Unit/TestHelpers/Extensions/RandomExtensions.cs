using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Timetabler.Data.Tests.Unit.TestHelpers.Extensions
{
    public static class RandomExtensions
    {
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

        public static PdfExportEngine NextPdfExportEngine(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            PdfExportEngine[] allValues = new PdfExportEngine[]
            {
                PdfExportEngine.External,
                PdfExportEngine.Unicorn,
            };
            return allValues[random.Next(allValues.Length)];
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
    }
}
