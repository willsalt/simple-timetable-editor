using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
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
                Maps = new List<NetworkMapModel> { new NetworkMapModel { LocationList = template.Locations.Select(l => l.ToLocationModel()).ToList() } },
                NoteDefinitions = template.NoteDefinitions.Select(n => n.ToNoteModel()).ToList(),
                TrainClasses = template.TrainClasses.Select(c => c.ToTrainClassModel()).ToList(),
                Signalboxes = template.Signalboxes.Select(s => s.ToSignalboxModel()).ToList(),
            };

            return model;
        }
    }
}
