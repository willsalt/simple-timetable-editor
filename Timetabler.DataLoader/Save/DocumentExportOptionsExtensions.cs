using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for converting an <see cref="DocumentExportOptions"/> object to serializable form.
    /// </summary>
    public static class DocumentExportOptionsExtensions
    {
        /// <summary>
        /// Convert a <see cref="DocumentExportOptions"/> object into an <see cref="ExportOptionsModel"/> object.
        /// </summary>
        /// <param name="exportOptions">The object to be converted.</param>
        /// <returns>An <see cref="ExportOptionsModel"/> containing the same data as the parameter.</returns>
        public static ExportOptionsModel ToExportOptionsModel(this DocumentExportOptions exportOptions)
        {
            return new ExportOptionsModel
            {
                DisplayLocoDiagramRow = exportOptions?.DisplayLocoDiagramRow ?? false,
                ToWorkRowInOutput = exportOptions?.DisplayToWorkRow ?? false,
                LocoToWorkRowInOutput = exportOptions?.DisplayLocoToWorkRow ?? false,
                BoxHoursInOutput = exportOptions?.DisplayBoxHours ?? false,
                CreditsInOutput = exportOptions?.DisplayCredits ?? false,
                LineWidth = exportOptions?.LineWidth ?? 1.0,
                FillerDashLineWidth = exportOptions?.FillerDashLineWidth ?? 0.5,
                GraphsInOutput = exportOptions.DisplayGraph,
                GlossaryInOutput = exportOptions.DisplayGlossary,
            };
        }
    }
}
