using System.Drawing;
using Timetabler.CoreData;

namespace Timetabler.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Color" />.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Convert a <see cref="Color" /> to a <see cref="Colour" />.
        /// </summary>
        /// <param name="c">The color to convert.</param>
        /// <returns>A colour.</returns>
        public static Colour ToColour(this Color c)
        {
            return new Colour((uint)c.ToArgb());
        }
    }
}
