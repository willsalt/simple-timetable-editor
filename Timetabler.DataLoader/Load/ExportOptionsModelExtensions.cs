using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extensions methods for converting <see cref="ExportOptionsModel"/> instances into in-memory form.
    /// </summary>
    public static class ExportOptionsModelExtensions
    {
        /// <summary>
        /// Convert an <see cref="ExportOptionsModel"/> instance into a <see cref="DocumentExportOptions"/> instance.
        /// </summary>
        /// <param name="exportOptionsModel">The object to convert.</param>
        /// <returns>The converted object.</returns>
        public static DocumentExportOptions ToDocumentExportOptions(this ExportOptionsModel exportOptionsModel)
        {
            return new DocumentExportOptions
            {
                DisplayLocoDiagramRow = exportOptionsModel?.DisplayLocoDiagramRow ?? false,
                DisplayToWorkRow = exportOptionsModel?.ToWorkRowInOutput ?? false,
                DisplayLocoToWorkRow = exportOptionsModel?.LocoToWorkRowInOutput ?? false,
                DisplayBoxHours = exportOptionsModel?.BoxHoursInOutput ?? false,
                DisplayCredits = exportOptionsModel?.CreditsInOutput ?? false,
                DisplayGlossary = exportOptionsModel?.GlossaryInOutput ?? false,
                LineWidth = exportOptionsModel.LineWidth ?? 1.0,
                FillerDashLineWidth = exportOptionsModel.FillerDashLineWidth ?? 0.5,
                DisplayGraph = exportOptionsModel.GraphsInOutput,
            };
        }
    }
}
