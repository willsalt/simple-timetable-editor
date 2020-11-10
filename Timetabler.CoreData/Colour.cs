using System;

namespace Timetabler.CoreData
{
    /// <summary>
    /// Structure representing a colour, similar to the <c>System.Drawing.Color</c> type.
    /// </summary>
    public struct Colour : IEquatable<Colour>
    {
        /// <summary>
        /// The full 32-bit ARGB value of this colour.
        /// </summary>
        public uint Argb { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="argb">The 32-bit ARGB value of this colour.</param>
        public Colour(uint argb)
        {
            Argb = argb;
        }

        /// <summary>
        /// The red component of the colour, from 0 to 255.
        /// </summary>
        public int R => (int)(Argb & 0xff0000) >> 16;

        /// <summary>
        /// The green component of the colour, from 0 to 255.
        /// </summary>
        public int G => (int)(Argb & 0xff00) >> 8;

        /// <summary>
        /// The blue component of the colour, from 0 to 255.
        /// </summary>
        public int B => (int)(Argb & 0xff);

        /// <summary>
        /// The colour black, with ARGB value 0xFF000000.
        /// </summary>
        public static Colour Black => new Colour(0xff000000);

        /// <summary>
        /// The colour white, with ARGB value 0xFFFFFFFF.
        /// </summary>
        public static Colour White => new Colour(0xffffffff);

        /// <summary>
        /// The color light grey, with ARGB value 0xFFD3D3D3.
        /// </summary>
        public static Colour LightGrey => new Colour(0xffd3d3d3);

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns>True if the parameter is another <see cref="Colour" /> value with the same ARGB value; false if not.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Colour c))
            {
                return false;
            }
            return Equals(c);
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="other">Another colour value.</param>
        /// <returns>True if the parameter has the same ARGB value, false if not.</returns>
        public bool Equals(Colour other)
        {
            return other.Argb == Argb;
        }

        /// <summary>
        /// Generates a hashcode for a colour value.
        /// </summary>
        /// <returns>A hashcode representing this value.</returns>
        public override int GetHashCode()
        {
            return Argb.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="c1">A <see cref="Colour" /> value.</param>
        /// <param name="c2">A <see cref="Colour" /> value.</param>
        /// <returns>True if the operands have the same ARGB value, false if not.</returns>
        public static bool operator ==(Colour c1, Colour c2)
        {
            return c1.Argb == c2.Argb;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="c1">A <see cref="Colour" /> value.</param>
        /// <param name="c2">A <see cref="Colour" /> value.</param>
        /// <returns>True if the operands have different ARGB values, false if they are equal.</returns>
        public static bool operator !=(Colour c1, Colour c2)
        {
            return c1.Argb != c2.Argb;
        }
    }
}
