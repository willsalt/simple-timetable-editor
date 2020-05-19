using System;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
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
        /// <exception cref="NullReferenceException">Thrown if the <c>this</c> parameter is <c>null</c>.</exception>
        public static ExportOptionsModel ToYamlExportOptionsModel(this DocumentExportOptions options)
        {
            if (options is null)
            {
                throw new NullReferenceException();
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
            };
        }
    }
}
