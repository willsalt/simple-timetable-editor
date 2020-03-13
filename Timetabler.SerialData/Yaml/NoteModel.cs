namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// A footnote in serialisable form.
    /// </summary>
    public class NoteModel
    {
        /// <summary>
        /// The unique ID of this note.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The symbol used to represent this note when references are made to it.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// The definition of the meaning of this note.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Whether or not this note can be selected to appear in train column headers.
        /// </summary>
        public bool? AppliesToTrains { get; set; }

        /// <summary>
        /// Whether or not this note can be selected to appear in timing points.
        /// </summary>
        public bool? AppliesToTimings { get; set; }

        /// <summary>
        /// Whether or not the definition of this note should be output on timetable pages where it is used.
        /// </summary>
        public bool? DefinedOnPages { get; set; }

        /// <summary>
        /// Whether or not the definition of this note should be output in a separate glossary.
        /// </summary>
        public bool? DefinedInGlossary { get; set; }
    }
}
