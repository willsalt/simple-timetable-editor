using System;
using System.Collections.Generic;
using System.Text;

namespace Timetabler.SerialData.Yaml
{
    public class TimetableDocumentTemplateModel
    {
        public int? Version { get; set; }

        public List<NetworkMapModel> Maps { get; set; }

        public DocumentOptionsModel DefaultOptions { get; set; }

        public ExportOptionsModel DefaultExportOptions { get; set; }

        public List<NoteModel> NoteDefinitions { get; set; }

        public List<TrainClassModel> TrainClasses { get; set; }

        public List<SignalboxModel> Signalboxes { get; set; }

        public TimetableDocumentTemplateModel()
        {
            Version = 3;
        }
    }
}
