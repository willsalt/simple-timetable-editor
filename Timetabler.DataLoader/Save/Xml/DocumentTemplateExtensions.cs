using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Save.Xml
{
    /// <summary>
    /// Extension methods for saving <see cref="DocumentTemplate"/> instances or converting them into serializable form.
    /// </summary>
    public static class DocumentTemplateExtensions
    {
        /// <summary>
        /// Convert a <see cref="DocumentTemplate"/> instance into a <see cref="TimetableDocumentTemplateModel"/> instance.
        /// </summary>
        /// <param name="template">The <see cref="DocumentTemplate"/> to be converted.</param>
        /// <returns>A <see cref="TimetableDocumentTemplateModel"/> instance representing the parameter.</returns>
        public static TimetableDocumentTemplateModel ToTimetableDocumentTemplateModel(this DocumentTemplate template)
        {
            TimetableDocumentTemplateModel model = new TimetableDocumentTemplateModel
            {
                DefaultExportOptions = template.ExportOptions.ToExportOptionsModel(),
                DefaultOptions = template.DocumentOptions.ToDocumentOptionsModel(),
            };
            NetworkMapModel nmm = new NetworkMapModel();
            nmm.LocationList.AddRange(template.Locations.Select(c => c.ToLocationModel()));
            model.Maps.Add(nmm);
            model.NoteDefinitions.AddRange(template.NoteDefinitions.Select(n => n.ToNoteModel()));
            model.TrainClasses.AddRange(template.TrainClasses.Select(c => c.ToTrainClassModel()));
            model.Signalboxes.AddRange(template.Signalboxes.Select(s => s.ToSignalboxModel()));
            return model;
        }
    }
}
