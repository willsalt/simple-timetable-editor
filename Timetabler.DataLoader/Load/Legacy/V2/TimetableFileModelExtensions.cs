using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.XmlData;
using Timetabler.XmlData.Legacy.V2;

namespace Timetabler.DataLoader.Load.Legacy.V2
{
    /// <summary>
    /// Extension methods for loading a <see cref="TimetableDocument"/> instance from serialized form.
    /// </summary>
    public static class TimetableFileModelExtensions
    {
        /// <summary>
        /// Convert a deserialized <see cref="XmlData.Legacy.V2.TimetableFileModel"/> instance to a <see cref="TimetableDocument"/> instance.
        /// </summary>
        /// <param name="file">The deserialized data to convert.</param>
        /// <returns>The data.</returns>
        public static TimetableDocument ToTimetableDocument(this XmlData.Legacy.V2.TimetableFileModel file)
        {
            TimetableDocument document = new TimetableDocument
            {
                Version = file.Version,
                Options = file.Options != null ? file.Options.ToDocumentOptions() : new DocumentOptions(),
                ExportOptions = file.ExportOptions != null ? file.ExportOptions.ToDocumentExportOptions() : new DocumentExportOptions(),
                Title = file.Title != null ? file.Title : string.Empty,
                Subtitle = file.Subtitle != null ? file.Subtitle : string.Empty,
                DateDescription = file.DateDescription != null ? file.DateDescription : string.Empty,
                WrittenBy = file.WrittenBy != null ? file.WrittenBy : string.Empty,
                CheckedBy = file.CheckedBy != null ? file.CheckedBy : string.Empty,
                TimetableVersion = file.TimetableVersion != null ? file.TimetableVersion : string.Empty,
                PublishedDate = file.PublishedDate != null ? file.PublishedDate : string.Empty,
            };

            if (file.LocationList != null)
            {
                foreach (XmlData.Legacy.V2.LocationModel loc in file.LocationList)
                {
                    document.LocationList.Add(loc.ToLocation());
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
                foreach (XmlData.Legacy.V2.TrainModel trn in file.TrainList)
                {
                    document.TrainList.Add(trn.ToTrain(locationMap, classMap, noteMap));
                }
            }

            return document;
        }
    }
}
