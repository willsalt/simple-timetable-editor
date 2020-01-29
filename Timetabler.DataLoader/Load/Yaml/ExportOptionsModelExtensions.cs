using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class ExportOptionsModelExtensions
    {
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
