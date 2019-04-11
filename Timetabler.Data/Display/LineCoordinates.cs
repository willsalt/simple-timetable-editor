using System;
using System.Collections.Generic;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// The coordinates of the two ends of a line.
    /// </summary>
    public class LineCoordinates
    {
        /// <summary>
        /// The X-coordinate of the first vertex.
        /// </summary>
        public double X1 { get; set; }

        /// <summary>
        /// The Y-coordinate of the first vertex.
        /// </summary>
        public double Y1 { get; set; }

        /// <summary>
        /// The X-coordinate of the second vertex.
        /// </summary>
        public double X2 { get; set; }

        /// <summary>
        /// The Y-coordinate of the second vertex.
        /// </summary>
        public double Y2 { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LineCoordinates()
        {

        }

        /// <summary>
        /// Constructor which sets the vertex coordinate properties.
        /// </summary>
        /// <param name="x1">The X-coordinate of the first vertex.</param>
        /// <param name="y1">The Y-coordinate of the first vertex.</param>
        /// <param name="x2">The X-coordinate of the second vertex.</param>
        /// <param name="y2">The Y-coordinate of the second vertex.</param>
        public LineCoordinates(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        /// <summary>
        /// Given an <see cref="IList{LineCoordinates}"/>, return the list of the longest line in the IList.
        /// </summary>
        /// <param name="coordinates">The list of lines to measure.</param>
        /// <returns>The index of the longest line in the list.</returns>
        public static int GetIndexOfLongestLine(IList<LineCoordinates> coordinates)
        {
            double max = 0;
            int idx = 0;
            for (int i = 0; i < coordinates.Count; ++i)
            {
                double len = Math.Sqrt(Math.Pow(coordinates[i].X1 - coordinates[i].X2, 2) + Math.Pow(coordinates[i].Y1 - coordinates[i].Y2, 2));
                if (len > max)
                {
                    max = len;
                    idx = i;
                }
            }

            return idx;
        }
    }
}
