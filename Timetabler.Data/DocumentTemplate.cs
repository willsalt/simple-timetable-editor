using Timetabler.Data.Collections;

namespace Timetabler.Data
{
    /// <summary>
    /// Document template class.
    /// </summary>
    public class DocumentTemplate
    {
        /// <summary>
        /// The document location map.
        /// </summary>
        public LocationCollection Locations { get; set; }

        /// <summary>
        /// Default document options.
        /// </summary>
        public DocumentOptions DocumentOptions { get; set; }

        /// <summary>
        /// Default document export options.
        /// </summary>
        public DocumentExportOptions ExportOptions { get; set; }

        /// <summary>
        /// Footnote definitions.
        /// </summary>
        public NoteCollection NoteDefinitions { get; set; }

        /// <summary>
        /// Train classes.
        /// </summary>
        public TrainClassCollection TrainClasses { get; set; }

        /// <summary>
        /// Signalboxes.
        /// </summary>
        public SignalboxCollection Signalboxes { get; set; }
    }
}
