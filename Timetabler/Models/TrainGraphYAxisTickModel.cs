using System.Drawing;

namespace Timetabler.Models
{
    /// <summary>
    /// A model class encapsulating data about a location (Y) axis tick label on a train graph.
    /// </summary>
    public class TrainGraphYAxisTickModel
    {
        /// <summary>
        /// The text of the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The Y-coordinate of the midpoint of the label (and the tick).
        /// </summary>
        public float YMidpoint { get; set; }
        
        /// <summary>
        /// The label bounding box size.
        /// </summary>
        public SizeF LabelSize { get; set; }
    }
}
