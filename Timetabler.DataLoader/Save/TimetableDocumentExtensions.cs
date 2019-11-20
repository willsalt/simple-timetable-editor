using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
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
                Maps = new List<NetworkMapModel>
                {
                    new NetworkMapModel { LocationList = new List<LocationModel>(), BlockSections = new List<BlockSectionModel>(), Signalboxes = new List<SignalboxModel>() }
                },
                NoteDefinitions = new List<NoteModel>(),
                TrainClassList = new List<TrainClassModel>(),
                TrainList = new List<TrainModel>(),
                SignalboxHoursSets = document.SignalboxHoursSets.Select(h => h.ToSignalboxHoursSetModel()).ToList(),
            };

            fileModel.Maps[0].LocationList.AddRange(document.LocationList.Select(l => l.ToLocationModel()));
            fileModel.Maps[0].Signalboxes.AddRange(document.Signalboxes.Select(b => b.ToSignalboxModel()));
            fileModel.NoteDefinitions.AddRange(document.NoteDefinitions.Select(n => n.ToNoteModel()));
            fileModel.TrainClassList.AddRange(document.TrainClassList.Select(tc => tc.ToTrainClassModel()));
            fileModel.TrainList.AddRange(document.TrainList.Select(t => t.ToTrainModel()));

            return fileModel;
        }
    }
}
