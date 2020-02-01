using System;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    /// <summary>
    /// Extension methods for the <see cref="ExportOptionsModel" /> class.
    /// </summary>
    public static class ExportOptionsModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="ExportOptionsModel" /> instance to a <see cref="DocumentExportOptions" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A <see cref="DocumentExportOptions" /> instance representing the original data.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static DocumentExportOptions ToDocumentExportOptions(this ExportOptionsModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            return new DocumentExportOptions
            {
                DisplayLocoDiagramRow = model.DisplayLocoDiagramRow ?? false,
                DisplayToWorkRow = model.ToWorkRowInOutput ?? false,
                DisplayLocoToWorkRow = model.LocoToWorkRowInOutput ?? false,
                DisplayBoxHours = model.BoxHoursInOutput ?? false,
                DisplayCredits = model.CreditsInOutput ?? false,
                DisplayGlossary = model.GlossaryInOutput ?? false,
                LineWidth = model.LineWidth ?? 1.0,
                FillerDashLineWidth = model.FillerDashLineWidth ?? 0.5,
                DisplayGraph = model.GraphsInOutput ?? true,
            };
        }
    }
}
