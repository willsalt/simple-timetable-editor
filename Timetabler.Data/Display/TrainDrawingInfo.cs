using System.Collections.Generic;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// Information required to draw a train on a train graph.
    /// </summary>
    public class TrainDrawingInfo
    {
        /// <summary>
        /// Drawing properties, such as line width and style.
        /// </summary>
        public GraphTrainProperties Properties { get; set; }

        /// <summary>
        /// Train headcode (for label).
        /// </summary>
        public string Headcode { get; set; }

        /// <summary>
        /// List of lines to draw to display this train.
        /// </summary>
        public List<LineCoordinates> LineVertexes { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainDrawingInfo()
        {
            LineVertexes = new List<LineCoordinates>();
        }
    }
}
