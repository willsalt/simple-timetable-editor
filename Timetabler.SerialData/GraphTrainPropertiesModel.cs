namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// Properties of how a train line is drawn on the graph.
    /// </summary>
    public class GraphTrainPropertiesModel
    {
        /// <summary>
        /// The line colour (only supported for on-screen view).
        /// </summary>
        public string Colour { get; set; }

        /// <summary>
        /// The line width.
        /// </summary>
        public float? Width { get; set; }

        /// <summary>
        /// The line style.
        /// </summary>
        public string DashStyleName { get; set; }
    }
}
