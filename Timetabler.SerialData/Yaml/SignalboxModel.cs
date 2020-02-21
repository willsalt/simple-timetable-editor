namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// A class describing a signalbox in serialisable form.
    /// </summary>
    public class SignalboxModel
    {
        /// <summary>
        /// The unique ID of this signalbox.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A code used to refere to this signalbox.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name used to refer to this signalbox in the editor.
        /// </summary>
        public string EditorDisplayName { get; set; }

        /// <summary>
        /// Name used to refer to this signalbox in PDF files.
        /// </summary>
        public string TimetableDisplayName { get; set; }
    }
}
