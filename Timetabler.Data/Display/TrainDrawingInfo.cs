using System.Collections.Generic;
using System.Linq;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// Information required to draw a train on a train graph.
    /// </summary>
    public class TrainDrawingInfo
    {
        /// <summary>
        /// The train itself.
        /// </summary>
        public Train Train { get; set; }

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
        public List<LineCoordinates> Lines { get; set; }

        /// <summary>
        /// An enumeration of all of the vertexes associated with the <see cref="Lines" /> property.
        /// </summary>
        public IEnumerable<VertexInformation> LineVertexes
        {
            get
            {
                return Lines.Select(i => i.Vertex1).Union(Lines.Select(i => i.Vertex2)).Distinct();
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainDrawingInfo()
        {
            Lines = new List<LineCoordinates>();
        }
    }
}
