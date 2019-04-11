namespace Timetabler.Data.Display
{
    /// <summary>
    /// Information needed to draw a tick on a train graph axis.
    /// </summary>
    public class TrainGraphAxisTickInfo
    {
        /// <summary>
        /// Tick label.
        /// </summary>
        public string Label { get; private set; }

        /// <summary>
        /// Proportional position along the axis (between 0 and 1).
        /// </summary>
        public double Coordinate { get; private set; }

        /// <summary>
        /// Width of rendered label (if populated).  Not populated by default.
        /// </summary>
        public double? Width { get; set; }

        /// <summary>
        /// Height of rendered label (if populated).  Not populated by default.
        /// </summary>
        public double? Height { get; set; }

        /// <summary>
        /// Constructor which sets label value and tick position.
        /// </summary>
        /// <param name="label">The label text.</param>
        /// <param name="coord">The position of the tick on the axis (between 0 and 1).</param>
        public TrainGraphAxisTickInfo(string label, double coord)
        {
            Label = label;
            Coordinate = coord;
        }
    }
}
