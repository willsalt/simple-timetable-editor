namespace Unicorn.Interfaces
{
    /// <summary>
    /// Immutable class which encapsulates the size of a 2D rectangle.
    /// </summary>
    public class UniSize
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
