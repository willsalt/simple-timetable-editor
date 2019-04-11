using System.Linq;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Class for loading <see cref="DocumentTemplate"/> classes from serialized form into memory.
    /// </summary>
    public static class TimetableDocumentTemplateModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimetableDocumentTemplateModel"/> object into a <see cref="DocumentTemplate"/> object.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A converted <see cref="DocumentTemplate"/> object.</returns>
        public static DocumentTemplate ToDocumentTemplate(this TimetableDocumentTemplateModel model)
        {
            DocumentTemplate template = new DocumentTemplate
            {
                DocumentOptions = model.DefaultOptions.ToDocumentOptions(),
                ExportOptions = model.DefaultExportOptions.ToDocumentExportOptions(),
                NoteDefinitions = new NoteCollection(model.NoteDefinitions.Select(n => n.ToNote())),
                TrainClasses = new TrainClassCollection(model.TrainClasses.Select(c => c.ToTrainClass())),
                Signalboxes = new SignalboxCollection(model.Signalboxes.Select(s => s.ToSignalbox())),
            };

            if (model.Maps != null && model.Maps.Count > 0 && model.Maps[0] != null)
            {
                template.Locations = new LocationCollection(model.Maps[0].LocationList.Select(l => l.ToLocation()));
            }
            else
            {
                template.Locations = new LocationCollection();
            }

            return template;
        }
    }
}
