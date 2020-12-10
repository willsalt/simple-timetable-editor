using Timetabler.CoreData;

namespace Timetabler.PdfExport.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="Direction" /> enumeration type.
    /// </summary>
    public static class DirectionExtensions
    {
        /// <summary>
        /// Given a <see cref="Direction" />, return the opposite direction.
        /// </summary>
        /// <param name="d">A <see cref="Direction" /> value.</param>
        /// <returns>The opposite direction to the parameter.</returns>
        public static Direction Opposite(this Direction d)
        {
            switch (d)
            {
                case Direction.Down:
                    return Direction.Up;
                case Direction.Up:
                    return Direction.Down;
                default:
                    return d;
            }
        }
    }
}
