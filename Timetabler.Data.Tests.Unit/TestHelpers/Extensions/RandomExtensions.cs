using System;

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
                PdfExportEngine.Unicorn,
            };
            return allValues[random.Next(allValues.Length)];
        }
    }
}
