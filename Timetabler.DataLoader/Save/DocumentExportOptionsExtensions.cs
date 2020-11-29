using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="DocumentExportOptions" /> class.
    /// </summary>
    public static class DocumentExportOptionsExtensions
    {
        /// <summary>
        /// Convert a <see cref="DocumentExportOptions" /> instance into an <see cref="ExportOptionsModel" /> instance.
        /// </summary>
        /// <param name="options">The instance to convert.</param>
        /// <returns>An <see cref="ExportOptionsModel" /> instance containing the same data in serialisable form.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>this</c> parameter is <c>null</c>.</exception>
        public static ExportOptionsModel ToExportOptionsModel(this DocumentExportOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return new ExportOptionsModel
            {
                DisplayLocoDiagramRow = options.DisplayLocoDiagramRow,
                SetToWorkRowInOutput = options.DisplayToWorkRow,
                LocoToWorkRowInOutput = options.DisplayLocoToWorkRow,
                BoxHoursInOutput = options.DisplayBoxHours,
                CreditsInOutput = options.DisplayCredits,
                LineWidth = options.LineWidth,
                GraphAxisLineWidth = options.GraphAxisLineWidth,
                FillerDashLineWidth = options.FillerDashLineWidth,
                GraphsInOutput = options.DisplayGraph,
                GlossaryInOutput = options.DisplayGlossary,
                TablePageOrientation = options.TablePageOrientation,
                GraphPageOrientation = options.GraphPageOrientation,
                UpSectionLabel = options.UpSectionLabel,
                DownSectionLabel = options.DownSectionLabel,
                MorningLabel = options.MorningLabel,
                MiddayLabel = options.MiddayLabel,
                AfternoonLabel = options.AfternoonLabel,
                DistancesInOutput = options.DistancesInOutput,
            };
        }
    }
}
