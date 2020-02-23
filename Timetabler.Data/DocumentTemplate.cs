using System;
using System.Collections.Generic;
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
        public LocationCollection Locations { get; private set; }

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
        public NoteCollection NoteDefinitions { get; private set; }

        /// <summary>
        /// Train classes.
        /// </summary>
        public TrainClassCollection TrainClasses { get; private set; }

        /// <summary>
        /// Signalboxes.
        /// </summary>
        public SignalboxCollection Signalboxes { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="locations">Locations to include in this template.</param>
        /// <param name="notes">Footnote definitions to include in this template.</param>
        /// <param name="classes">Train classes to include in this template.</param>
        /// <param name="boxes">Signalboxes to include in this template.</param>
        public DocumentTemplate(IEnumerable<Location> locations, IEnumerable<Note> notes, IEnumerable<TrainClass> classes, IEnumerable<Signalbox> boxes)
        {
            Locations = new LocationCollection(locations ?? Array.Empty<Location>());
            NoteDefinitions = new NoteCollection(notes ?? Array.Empty<Note>());
            TrainClasses = new TrainClassCollection(classes ?? Array.Empty<TrainClass>());
            Signalboxes = new SignalboxCollection(boxes ?? Array.Empty<Signalbox>());
        }
    }
}
