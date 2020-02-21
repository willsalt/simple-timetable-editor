namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// Class that describes the settings that apply to a document, in serialisable form.
    /// </summary>
    public class DocumentOptionsModel
    {
        /// <summary>
        /// The name of the clock type that this document uses (ie, "TwelveHourClock" or "TwentyFourHourClock").
        /// </summary>
        public string ClockTypeName { get; set; }

        /// <summary>
        /// Whether or not to label train lines on the train graph with the headcode of the train.  Defaults to true if this value is null.
        /// </summary>
        public bool? DisplayTrainLabelsOnGraphs { get; set; }

        /// <summary>
        /// The name of the editing style used by the graph tab, such as "PreserveSectionTimes".
        /// </summary>
        public string GraphEditStyle { get; set; }
    }
}
