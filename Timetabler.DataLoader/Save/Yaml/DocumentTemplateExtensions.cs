using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class DocumentTemplateExtensions
    {
        public static TimetableDocumentTemplateModel ToYamlTimetableDocumentTemplateModel(this DocumentTemplate template)
        {
            if (template is null)
            {
                throw new NullReferenceException();
            }

            return new TimetableDocumentTemplateModel
            {
                DefaultExportOptions = template.ExportOptions.ToYamlExportOptionsModel(),
                DefaultOptions = template.DocumentOptions.ToYamlDocumentOptionsModel(),
                Maps = new List<NetworkMapModel>()
                {
                    new NetworkMapModel
                    {
                        LocationList = template.Locations.Select(c => c.ToYamlLocationModel()).ToList(),
                    }
                },
                NoteDefinitions = template.NoteDefinitions.Select(n => n.ToYamlNoteModel()).ToList(),
                TrainClasses = template.TrainClasses.Select(c => c.ToYamlTrainClassModel()).ToList(),
                Signalboxes = template.Signalboxes.Select(b => b.ToYamlSignalboxModel()).ToList(),
            };
        }
    }
}
