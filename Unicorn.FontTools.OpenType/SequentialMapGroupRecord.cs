using System;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// A mapping segment record for an OpenType type 8 character mapping.
    /// </summary>
    [CLSCompliant(false)]
    public struct SequentialMapGroupRecord : IEquatable<SequentialMapGroupRecord>
    {
        /// <summary>
        /// The lowest codepoint mapped by this segment.
        /// </summary>
        public uint StartCode { get; }

        /// <summary>
        /// The highest codepoint mapped by this segment.
        /// </summary>
        public uint EndCode { get; }

        /// <summary>
        /// The glyph ID corresponding to the lowest codepoint mapped by this segment (other codepoints are mapped sequentially onwards).
        /// </summary>
        public ushort StartGlyphId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="start">Value for the <see cref="StartCode" /> property.</param>
        /// <param name="end">Value for the <see cref="EndCode" /> property.</param>
        /// <param name="glyph">Value for the <see cref="StartGlyphId" /> property.</param>
        public SequentialMapGroupRecord(uint start, uint end, ushort glyph)
        {
            StartCode = start;
            EndCode = end;
            StartGlyphId = glyph;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="SequentialMapGroupRecord" /> value.</param>
        /// <returns><c>true</c> if the parameter value is equal to this value, <c>false</c> if not.</returns>
        public bool Equals(SequentialMapGroupRecord other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another value or object.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="SequentialMapGroupRecord" /> value equal to this one, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SequentialMapGroupRecord other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hash code derived from this value.</returns>
        public override int GetHashCode() => StartCode.GetHashCode() ^ EndCode.GetHashCode() ^ StartGlyphId.GetHashCode();

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="SequentialMapGroupRecord" /> value.</param>
        /// <param name="b">A <see cref="SequentialMapGroupRecord" /> value.</param>
        /// <returns><c>true</c> if the operands are equal, <c>false</c> if not.</returns>
        public static bool operator ==(SequentialMapGroupRecord a, SequentialMapGroupRecord b)
            => a.StartGlyphId == b.StartGlyphId && a.StartCode == b.StartCode && a.EndCode == b.EndCode;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="SequentialMapGroupRecord" /> value.</param>
        /// <param name="b">A <see cref="SequentialMapGroupRecord" /> value.</param>
        /// <returns><c>true</c> if the operands are not equal, <c>false</c> if they are.</returns>
        public static bool operator !=(SequentialMapGroupRecord a, SequentialMapGroupRecord b)
            => a.StartGlyphId != b.StartGlyphId || a.StartCode != b.StartCode || a.EndCode != b.EndCode;
    }
}
