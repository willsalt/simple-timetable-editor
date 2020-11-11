namespace Timetabler.SerialData
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

        /// <summary>
        /// Whether or not to display "speed lines" on the on-screen train graph to show the progress of a train at a nominal speed.
        /// </summary>
        public bool? DisplaySpeedLinesOnGraphs { get; set; }

        /// <summary>
        /// If "speed lines" are shown on the on-screen train graph, what speed should they be displayed at.
        /// </summary>
        public int? SpeedLineSpeed { get; set; }

        /// <summary>
        /// If "speed lines" are shown on the on-screen train graph, what spacing should they be displayed at.
        /// </summary>
        public int? SpeedLineSpacingMinutes { get; set; }

        /// <summary>
        /// If "speed lines" are shown on the on-screen train graph, what visual properties (colour, thickness, dash style) should they have.
        /// </summary>
        public GraphTrainPropertiesModel SpeedLineAppearance { get; set; }
    }
}
