using System;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// Defines a two-element vector as used in font metrics defnitions.
    /// </summary>
    public struct Vector : IEquatable<Vector>
    {
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        public decimal X { get; private set; }

        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        public decimal Y { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        public Vector(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="Vector" /> value.</param>
        /// <returns><c>true</c> if the values are equal, <c>false</c> if not.</returns>
        public bool Equals(Vector other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="Vector" /> value equal to this one, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector vector))
            {
                return false;
            }
            return Equals(vector);
        }

        /// <summary>
        /// Returns a hash code value.
        /// </summary>
        /// <returns>An integer representing a hash of this value.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (2 * Y).GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="Vector" /> value.</param>
        /// <param name="b">A <see cref="Vector" /> value.</param>
        /// <returns><c>true</c> if the two values are equal, false if not.</returns>
        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="Vector" /> value.</param>
        /// <param name="b">A <see cref="Vector" /> value.</param>
        /// <returns><c>true</c> if the two values are not equal, <c>false</c> if they are.</returns>
        public static bool operator !=(Vector a, Vector b)
        {
            return a.X != b.X || a.Y != b.Y;
        }
    }
}
