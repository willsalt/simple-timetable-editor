using System.Drawing;
using Timetabler.CoreData;

namespace Timetabler.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="Colour" /> struct.
    /// </summary>
    public static class ColourExtensions
    {
        /// <summary>
        /// Convert a <see cref="Colour" /> to a <see cref="Color" />.
        /// </summary>
        /// <param name="c">The colour to be converted.</param>
        /// <returns>A color.</returns>
        public static Color ToColor(this Colour c)
        {
            return Color.FromArgb((int)c.Argb);
        }
    }
}
