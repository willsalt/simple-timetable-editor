using System;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="TimetableDocument" /> class.
    /// </summary>
    public static class TimetableDocumentExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimetableDocument" /> instance to a <see cref="TimetableFileModel" /> instance.
        /// </summary>
        /// <param name="doc">The object to convert.</param>
        /// <returns>A <see cref="TimetableFileModel" /> instance containing the same data as the parameter, in serialisable form.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static TimetableFileModel ToYamlTimetableFileModel(this TimetableDocument doc)
        {
            if (doc is null)
            {
                throw new NullReferenceException();
            }

            TimetableFileModel fileModel = new TimetableFileModel
            {
                Version = Versions.CurrentTimetableDocument,

                FileOptions = doc.Options.ToYamlDocumentOptionsModel(),
                ExportOptions = doc.ExportOptions.ToYamlExportOptionsModel(),

                Title = doc.Title,
                Subtitle = doc.Subtitle,
                DateDescription = doc.DateDescription,
                WrittenBy = doc.WrittenBy,
                CheckedBy = doc.CheckedBy,
                TimetableVersion = doc.TimetableVersion,
                PublishedDate = doc.PublishedDate,
            };

            fileModel.Maps.Add(BuildNetworkMapModel(doc));
            fileModel.TrainList.AddRange(doc.TrainList.Select(t => t.ToYamlTrainModel()));
            fileModel.NoteDefinitions.AddRange(doc.NoteDefinitions.Select(n => n.ToYamlNoteModel()));
            fileModel.TrainClassList.AddRange(doc.TrainClassList.Select(c => c.ToYamlTrainClassModel()));
            fileModel.SignalboxHoursSets.AddRange(doc.SignalboxHoursSets.Select(s => s.ToYamlSignalboxHoursSetModel()));
            return fileModel;
        }

        private static NetworkMapModel BuildNetworkMapModel(TimetableDocument doc)
        {
            NetworkMapModel model = new NetworkMapModel();
            model.LocationList.AddRange(doc.LocationList.Select(c => c.ToYamlLocationModel()));
            model.Signalboxes.AddRange(doc.Signalboxes.Select(b => b.ToYamlSignalboxModel()));
            return model;
        }
    }
}
