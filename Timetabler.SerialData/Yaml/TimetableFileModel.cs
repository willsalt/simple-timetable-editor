using System.Collections.Generic;

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

        public List<NetworkMapModel> Maps { get; } = new List<NetworkMapModel>();

        public List<NoteModel> NoteDefinitions { get; } = new List<NoteModel>();

        public List<TrainClassModel> TrainClassList { get; } = new List<TrainClassModel>();

        public List<TrainModel> TrainList { get; } = new List<TrainModel>();

        public List<SignalboxHoursSetModel> SignalboxHoursSets { get; } = new List<SignalboxHoursSetModel>();
    }
}
