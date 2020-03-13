using System;

namespace Unicorn.Interfaces
{
    /// <summary>
    /// Immutable class which encapsulates the size of a 2D rectangle.
    /// </summary>
    public class UniSize : IEquatable<UniSize>
    {
        /// <summary>
        /// Width
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Constructor, setting <see cref="Width" /> and <see cref="Height" /> properties.  
        /// </summary>
        /// <param name="width">The value of the <see cref="Width" /> property.</param>
        /// <param name="height">The value of the <see cref="Height" /> property.</param>
        public UniSize(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Equality test.
        /// </summary>
        /// <param name="other">Another UniSize instance to compare against.</param>
        /// <returns>True or false according to whether or not the other instance is equal to this.</returns>
        public bool Equals(UniSize other)
        {
            if (other is null)
            {
                return false;
            }
            return Width == other.Width && Height == other.Height;
        }

        /// <summary>
        /// Equality test.
        /// </summary>
        /// <param name="obj">Another object to compare against.</param>
        /// <returns>True if the obj parameter is another UniSize instance that is the same as this; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (!(obj is UniSize other))
            {
                return false;
            }
            return Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32 bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            // The multiplication of the height is to avoid the generate case where all squares return a hashcode of 0.
            return Width.GetHashCode() ^ (Height * 17).GetHashCode();
        }
        
        /// Addition operator.  Returns a <see cref="UniSize" /> whose width is the sum of its operands' widths and whose height is the sum of its operands' heights.
        /// </summary>
        /// <param name="a">A <see cref="UniSize" /> instance.</param>
        /// <param name="b">A <see cref="UniSize" /> instance.</param>
        /// <returns>A <see cref="UniSize" /> instance that equals the sum of the operands.</returns>
        public static UniSize operator +(UniSize a, UniSize b)
        {
            if (a is null)
            {
                return b;
            }
            if (b is null)
            {
                return a;
            }
            return new UniSize(a.Width + b.Width, a.Height + b.Height);
        }

        /// <summary>
        /// Addition method.  Returns a <see cref="UniSize" /> whsoe width is the sum of its operands' widths and whose height is the sum of its operands' heights.
        /// </summary>
        /// <param name="left">A <see cref="UniSize" /> instance.</param>
        /// <param name="right">A <see cref="UniSize" /> instance.</param>
        /// <returns>A new <see cref="UniSize" /> instance that equals the sum of the operands.</returns>
        public static UniSize Add(UniSize left, UniSize right)
        {
            return left + right;
        }
    }
}
