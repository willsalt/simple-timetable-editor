using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class TimetableDocumentTemplateModelExtensions
    {
        public static DocumentTemplate ToDocumentTemplate(this TimetableDocumentTemplateModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            IEnumerable<Location> locationSource;
            if (model.Maps != null && model.Maps.Count > 0 && model.Maps[0] != null)
            {
                locationSource = model.Maps[0].LocationList.Select(l => l.ToLocation());
            }
            else
            {
                locationSource = Array.Empty<Location>();
            }

            DocumentTemplate template = new DocumentTemplate(
                locationSource,
                model.NoteDefinitions.Select(n => n.ToNote()),
                model.TrainClasses.Select(c => c.ToTrainClass()),
                model.Signalboxes.Select(s => s.ToSignalbox()))
            {
                DocumentOptions = model.DefaultOptions.ToDocumentOptions(),
                ExportOptions = model.DefaultExportOptions.ToDocumentExportOptions(),
            };

            return template;
        }
    }
}
