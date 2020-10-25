using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Timetabler.Data.Tests.Unit.TestHelpers.Extensions
{
    public static class RandomExtensions
    {
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
    }
}
