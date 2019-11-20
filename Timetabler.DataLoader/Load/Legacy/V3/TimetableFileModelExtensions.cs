using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load.Legacy.V3
{
    /// <summary>
    /// Extension methods for loading a <see cref="TimetableDocument"/> instance from serialized form.
    /// </summary>
    public static class TimetableFileModelExtensions
    {
        /// <summary>
        /// Convert a deserialized <see cref="SerialData.Legacy.V3.TimetableFileModel"/> instance to a <see cref="TimetableDocument"/> instance.
        /// </summary>
        /// <param name="file">The deserialized data to convert.</param>
        /// <returns>The data.</returns>
        public static TimetableDocument ToTimetableDocument(this SerialData.Legacy.V3.TimetableFileModel file)
        {
            TimetableDocument document = new TimetableDocument
            {
                Version = file.Version,
                Options = file.Options != null ? file.Options.ToDocumentOptions() : new DocumentOptions(),
                ExportOptions = file.ExportOptions != null ? file.ExportOptions.ToDocumentExportOptions() : new DocumentExportOptions(),
                Title = file.Title ?? string.Empty,
                Subtitle = file.Subtitle ?? string.Empty,
                DateDescription = file.DateDescription ?? string.Empty,
                WrittenBy = file.WrittenBy ?? string.Empty,
                CheckedBy = file.CheckedBy ?? string.Empty,
                TimetableVersion = file.TimetableVersion ?? string.Empty,
                PublishedDate = file.PublishedDate ?? string.Empty,
            };

            if (file.Maps != null && file.Maps.Count > 0 && file.Maps[0] != null)
            {
                if (file.Maps[0].LocationList != null)
                {
                    foreach (LocationModel loc in file.Maps[0].LocationList)
                    {
                        document.LocationList.Add(loc.ToLocation());
                    }
                }
                if (file.Maps[0].Signalboxes != null)
                {
                    foreach (SignalboxModel box in file.Maps[0].Signalboxes)
                    {
                        document.Signalboxes.Add(box.ToSignalbox());
                    }
                }
            }

            if (file.NoteDefinitions != null)
            {
                foreach (NoteModel note in file.NoteDefinitions)
                {
                    document.NoteDefinitions.Add(note.ToNote());
                }
            }

            if (file.TrainClassList != null)
            {
                foreach (TrainClassModel tc in file.TrainClassList)
                {
                    document.TrainClassList.Add(tc.ToTrainClass());
                }
            }

            Dictionary<string, Location> locationMap = document.LocationList.ToDictionary(o => o.Id);
            Dictionary<string, TrainClass> classMap = document.TrainClassList.ToDictionary(c => c.Id);
            Dictionary<string, Note> noteMap = document.NoteDefinitions.ToDictionary(n => n.Id);
            if (file.TrainList != null)
            {
                foreach (TrainModel trn in file.TrainList)
                {
                    document.TrainList.Add(trn.ToTrain(locationMap, classMap, noteMap, document.Options));
                }
            }

            return document;
        }
    }
}
