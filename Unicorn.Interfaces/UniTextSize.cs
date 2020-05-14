using System;

namespace Unicorn.Interfaces
{
    /// <summary>
    /// The measurements of a line of text.
    /// </summary>
    public struct UniTextSize : IEquatable<UniTextSize>
    {
        /// <summary>
        /// Width of the line of text.
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Total height of the line of text including vertical white space defined by the font.
        /// </summary>
        public double TotalHeight { get; private set; }

        /// <summary>
        /// Distance from the baseline of the text to the top of the line, including vertical white space defined by the font.
        /// </summary>
        public double HeightAboveBaseline { get; private set; }

        /// <summary>
        /// Distance from the baseline of the text to the bottom of the line, including vertical white space defined by the font.  This property is always an
        /// absolute amount, rather than an offset, so should always be positive other than in the rare case that the top of the line below this one should be above
        /// this line's baseline.
        /// </summary>
        public double HeightBelowBaseline => TotalHeight - HeightAboveBaseline;

        /// <summary>
        /// Distance from the baseline of the text to the top of the font's ascenders.
        /// </summary>
        public double AscenderHeight { get; private set; }

        /// <summary>
        /// Distance from the baseline of the text to the bottom of the font's descenders.  As per <see cref="HeightBelowBaseline" /> this property will normally be
        /// a positive amount.
        /// </summary>
        public double DescenderHeight { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="width">Value for the <see cref="Width" /> property.</param>
        /// <param name="totalHeight">Value for the <see cref="TotalHeight" /> property.</param>
        /// <param name="aboveBaseline">Value for the <see cref="HeightAboveBaseline" /> property.</param>
        /// <param name="ascender">Value for the <see cref="AscenderHeight" /> property.</param>
        /// <param name="descender">Value for the <see cref="DescenderHeight" /> property.</param>
        public UniTextSize(double width, double totalHeight, double aboveBaseline, double ascender, double descender)
        {
            Width = width;
            TotalHeight = totalHeight;
            HeightAboveBaseline = aboveBaseline;
            AscenderHeight = ascender;
            DescenderHeight = descender;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="UniTextSize" /> value to compare against.</param>
        /// <returns><c>true</c> if the parameter is equal to this value, <c>false</c> if not.</returns>
        public bool Equals(UniTextSize other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another value or object.</param>
        /// <returns><c>true</c> if the paramter is a <see cref="UniTextSize" /> value that is equal to this one; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UniTextSize other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hash code derived from this value.</returns>
        public override int GetHashCode()
            => Width.GetHashCode() ^ TotalHeight.GetHashCode() ^ HeightAboveBaseline.GetHashCode() ^ AscenderHeight.GetHashCode() ^ DescenderHeight.GetHashCode();

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniTextSize" /> value.</param>
        /// <param name="b">A <see cref="UniTextSize" /> value.</param>
        /// <returns><c>true</c> if the operands are equal across every property, <c>false</c> otherwise.</returns>
        public static bool operator ==(UniTextSize a, UniTextSize b)
            => a.Width == b.Width && a.TotalHeight == b.TotalHeight && a.HeightAboveBaseline == b.HeightAboveBaseline && a.AscenderHeight == b.AscenderHeight && 
                a.DescenderHeight == b.DescenderHeight;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniTextSize" /> value.</param>
        /// <param name="b">A <see cref="UniTextSize" /> value.</param>
        /// <returns><c>true</c> if the operands differ in any property, <c>false</c> if the operands are equal.</returns>
        public static bool operator !=(UniTextSize a, UniTextSize b)
            => a.Width != b.Width || a.TotalHeight != b.TotalHeight || a.HeightAboveBaseline != b.HeightAboveBaseline || a.AscenderHeight != b.AscenderHeight ||
                a.DescenderHeight != b.DescenderHeight;
    }
}
