using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Timetabler.Data
{
    /// <summary>
    /// A serialisation class which encapsulates the properties of a train relating to its style of display on a train graph.
    /// </summary>
    public class GraphTrainProperties
    {
        /// <summary>
        /// The colour of the train's line on the graph.
        /// </summary>
        public Color Colour { get; set; }
        
        /// <summary>
        /// The width of the train's line on the graph.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// The GDI dash style of the train's line on the graph - custom styles are not as yet supported.
        /// </summary>
        public DashStyle DashStyle { get; set; }
        
        /// <summary>
        /// The default constructor sets some sensible default values: a solid black line of width 2.
        /// </summary>
        public GraphTrainProperties()
        {
            Width = 2f;
            Colour = Color.Black;
            DashStyle = DashStyle.Solid;
        }

        /// <summary>
        /// Create a copy of this instance.  Currently this is a shallow copy, as the class has no deep properties.
        /// </summary>
        /// <returns>A <see cref="GraphTrainProperties"/> instance with properties equal in value to those of this instance.</returns>
        public GraphTrainProperties Copy()
        {
            return new GraphTrainProperties
            {
                Width = Width,
                Colour = Colour,
                DashStyle = DashStyle,
            };
        }

        public void CopyTo(GraphTrainProperties target)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            target.Width = Width;
            target.Colour = Colour;
            target.DashStyle = DashStyle;
        }
    }
}
