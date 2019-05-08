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
        /// The vertex that marks the start of the line.
        /// </summary>
        public VertexInformation Vertex1 { get; set; }

        /// <summary>
        /// The vertex that marks the end of the line.
        /// </summary>
        public VertexInformation Vertex2 { get; set; }

        /// <summary>
        /// Constructor which sets the vertex properties.
        /// </summary>
        /// <param name="v1">The first vertex.</param>
        /// <param name="v2">The second vertex.</param>
        public LineCoordinates(VertexInformation v1, VertexInformation v2)
        {
            Vertex1 = v1;
            Vertex2 = v2;
        }

        /// <summary>
        /// Given an <see cref="IList{LineCoordinates}"/>, return the list of the longest line in the IList.
        /// </summary>
        /// <param name="coordinates">The list of lines to measure.</param>
        /// <returns>The index of the longest line in the list.</returns>
        public static int GetIndexOfLongestLine(IList<LineCoordinates> coordinates)
        {
            if (coordinates == null)
            {
                return -1;
            }

            double max = 0;
            int idx = -1;
            for (int i = 0; i < coordinates.Count; ++i)
            {
                if (coordinates[i] == null || coordinates[i].Vertex1 == null || coordinates[i].Vertex2 == null)
                {
                    continue;
                }
                double len = Math.Sqrt(Math.Pow(coordinates[i].Vertex1.X - coordinates[i].Vertex2.X, 2) + Math.Pow(coordinates[i].Vertex1.Y - coordinates[i].Vertex2.Y, 2));
                if (len >= max)
                {
                    max = len;
                    idx = i;
                }
            }

            return idx;
        }
    }
}
