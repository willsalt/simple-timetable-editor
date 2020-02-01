using System.Collections.Generic;

namespace Timetabler.SerialData.Yaml
{
    public class TimetableDocumentTemplateModel
    {
        public int? Version { get; set; }

        public List<NetworkMapModel> Maps { get; } = new List<NetworkMapModel>();

        public DocumentOptionsModel DefaultOptions { get; set; }

        public ExportOptionsModel DefaultExportOptions { get; set; }

        public List<NoteModel> NoteDefinitions { get; } = new List<NoteModel>();

        public List<TrainClassModel> TrainClasses { get; } = new List<TrainClassModel>();

        public List<SignalboxModel> Signalboxes { get; } = new List<SignalboxModel>();

        public TimetableDocumentTemplateModel()
        {
            Version = 3;
        }
    }
}
