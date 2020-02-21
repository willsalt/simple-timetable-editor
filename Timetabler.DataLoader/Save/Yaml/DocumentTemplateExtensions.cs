using System;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
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
        public static TimetableDocumentTemplateModel ToYamlTimetableDocumentTemplateModel(this DocumentTemplate template)
        {
            if (template is null)
            {
                throw new NullReferenceException();
            }

            TimetableDocumentTemplateModel tdtm = new TimetableDocumentTemplateModel
            {
                DefaultExportOptions = template.ExportOptions.ToYamlExportOptionsModel(),
                DefaultOptions = template.DocumentOptions.ToYamlDocumentOptionsModel(),
            };
            NetworkMapModel nmm = new NetworkMapModel();
            nmm.LocationList.AddRange(template.Locations.Select(c => c.ToYamlLocationModel()));
            nmm.Signalboxes.AddRange(template.Signalboxes.Select(b => b.ToYamlSignalboxModel()));
            tdtm.Maps.Add(nmm);
            tdtm.NoteDefinitions.AddRange(template.NoteDefinitions.Select(n => n.ToYamlNoteModel()));
            tdtm.TrainClasses.AddRange(template.TrainClasses.Select(c => c.ToYamlTrainClassModel()));
            return tdtm;
        }
    }
}
