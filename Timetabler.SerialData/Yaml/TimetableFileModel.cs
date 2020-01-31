using System;
using System.Collections.Generic;
using System.Text;

namespace Timetabler.SerialData.Yaml
{
    public class TimetableFileModel
    {
        public int Version { get; set; }

        public DocumentOptionsModel FileOptions { get; set; }

        public ExportOptionsModel ExportOptions { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string DateDescription { get; set; }

        public string WrittenBy { get; set; }

        public string CheckedBy { get; set; }

        public string TimetableVersion { get; set; }

        public string PublishedDate { get; set; }

        public List<NetworkMapModel> Maps { get; set; }

        public List<NoteModel> NoteDefinitions { get; set; }

        public List<TrainClassModel> TrainClassList { get; set; }

        public List<TrainModel> TrainList { get; } = new List<TrainModel>();

        public List<SignalboxHoursSetModel> SignalboxHoursSets { get; set; }
    }
}
