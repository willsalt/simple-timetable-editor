using System;
using System.Linq;
using Timetabler.CoreData.Extensions;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extensions methods for the <see cref="DocumentTemplate" /> class.
    /// </summary>
    public static class DocumentTemplateExtensions
    {
        /// <summary>
        /// Convert a <see cref="DocumentTemplate" /> instance to a <see cref="TimetableDocumentTemplateModel" /> instance.
        /// </summary>
        /// <param name="template">The object to be converted.</param>
        /// <returns>A <see cref="TimetableDocumentTemplateModel" /> instance containing the same data as the original object in serialisable form.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        public static TimetableDocumentTemplateModel ToTimetableDocumentTemplateModel(this DocumentTemplate template)
        {
            if (template is null)
            {
                throw new NullReferenceException();
            }

            TimetableDocumentTemplateModel tdtm = new TimetableDocumentTemplateModel
            {
                DefaultExportOptions = template.ExportOptions.ToExportOptionsModel(),
                DefaultOptions = template.DocumentOptions.ToDocumentOptionsModel(),
            };
            NetworkMapModel nmm = new NetworkMapModel();
            nmm.LocationList.AddRange(template.Locations.Select(c => c.ToLocationModel()));
            nmm.Signalboxes.AddRange(template.Signalboxes.Select(b => b.ToSignalboxModel()));
            tdtm.Maps.Add(nmm);
            tdtm.NoteDefinitions.AddRange(template.NoteDefinitions.Select(n => n.ToNoteModel()));
            tdtm.TrainClasses.AddRange(template.TrainClasses.Select(c => c.ToTrainClassModel()));
            return tdtm;
        }
    }
}
