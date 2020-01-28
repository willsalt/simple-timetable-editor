using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class DocumentExportOptionsExtensions
    {
        public static ExportOptionsModel ToYamlExportOptionsModel(this DocumentExportOptions options)
        {
            if (options is null)
            {
                throw new NullReferenceException();
            }

            return new ExportOptionsModel
            {
                DisplayLocoDiagramRow = options.DisplayLocoDiagramRow,
                ToWorkRowInOutput = options.DisplayToWorkRow,
                LocoToWorkRowInOutput = options.DisplayLocoToWorkRow,
                BoxHoursInOutput = options.DisplayBoxHours,
                CreditsInOutput = options.DisplayCredits,
                LineWidth = options.LineWidth,
                FillerDashLineWidth = options.FillerDashLineWidth,
                GraphsInOutput = options.DisplayGraph,
                GlossaryInOutput = options.DisplayGlossary,
            };
        }
    }
}
