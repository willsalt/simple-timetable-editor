using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class TimetableDocumentExtensions
    {
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

                Maps = new List<NetworkMapModel> 
                { 
                    new NetworkMapModel
                    {
                        LocationList = doc.LocationList.Select(l => l.ToYamlLocationModel()).ToList(),
                        Signalboxes = doc.Signalboxes.Select(b => b.ToYamlSignalboxModel()).ToList(),
                    }
                },

                NoteDefinitions = doc.NoteDefinitions.Select(n => n.ToYamlNoteModel()).ToList(),
                TrainClassList = doc.TrainClassList.Select(c => c.ToYamlTrainClassModel()).ToList(),
                SignalboxHoursSets = doc.SignalboxHoursSets.Select(s => s.ToYamlSignalboxHoursSetModel()).ToList(),
            };

            fileModel.TrainList.AddRange(doc.TrainList.Select(t => t.ToYamlTrainModel()));

            return fileModel;
        }
    }
}
