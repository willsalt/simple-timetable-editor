namespace Timetabler.Data.Display
{
    /// <summary>
    /// Represents a vertex on a train graph.
    /// </summary>
    public class VertexInformation
    {
        /// <summary>
        /// The train to which this applies.
        /// </summary>
        public Train Train { get; set; }

        /// <summary>
        /// The time of the vertex.
        /// </summary>
        public TimeOfDay Time { get; set; }

        /// <summary>
        /// The X-position
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// When dragging, the X offset by which the vertex has been dragged
        /// </summary>
        public double DragOffset { get; set; }

        /// <summary>
        /// The Y-position.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Constructor which sets properties.
        /// </summary>
        /// <param name="t">The train to which this vertex belongs.</param>
        /// <param name="time">The time of day that the vertex represents.</param>
        /// <param name="x">The X-coordinate of the vertex.</param>
        /// <param name="y">The Y-coordinate of the vertex.</param>
        public VertexInformation(Train t, TimeOfDay time, double x, double y)
        {
            Train = t;
            Time = time;
            X = x;
            Y = y;
        }
    }
}
