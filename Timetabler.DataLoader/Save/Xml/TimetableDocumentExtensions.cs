using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Save.Xml
{
    /// <summary>
    /// Extension methods for preparing a <see cref="TimetableDocument"/> instance for serialization.
    /// </summary>
    public static class TimetableDocumentExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimetableDocument"/> instance to a <see cref="TimetableFileModel"/> for serialization.
        /// </summary>
        /// <param name="document">The instance to be converted.</param>
        /// <returns>The data prepared for serialization.</returns>
        public static TimetableFileModel ToTimetableFileModel(this TimetableDocument document)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            TimetableFileModel fileModel = new TimetableFileModel
            {
                Version = Versions.CurrentTimetableDocument,

                Options = document.Options.ToDocumentOptionsModel(),
                ExportOptions = document.ExportOptions.ToExportOptionsModel(),
                Title = document.Title,
                Subtitle = document.Subtitle,
                DateDescription = document.DateDescription,
                WrittenBy = document.WrittenBy,
                CheckedBy = document.CheckedBy,
                TimetableVersion = document.TimetableVersion,
                PublishedDate = document.PublishedDate,
            };

            NetworkMapModel nmm = new NetworkMapModel();
            nmm.LocationList.AddRange(document.LocationList.Select(l => l.ToLocationModel()));
            nmm.Signalboxes.AddRange(document.Signalboxes.Select(b => b.ToSignalboxModel()));
            fileModel.Maps.Add(nmm);
            fileModel.NoteDefinitions.AddRange(document.NoteDefinitions.Select(n => n.ToNoteModel()));
            fileModel.TrainClassList.AddRange(document.TrainClassList.Select(tc => tc.ToTrainClassModel()));
            fileModel.TrainList.AddRange(document.TrainList.Select(t => t.ToTrainModel()));
            fileModel.SignalboxHoursSets.AddRange(document.SignalboxHoursSets.Select(h => h.ToSignalboxHoursSetModel()));

            return fileModel;
        }
    }
}
