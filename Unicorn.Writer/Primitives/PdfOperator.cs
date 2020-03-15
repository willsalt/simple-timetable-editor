using System;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Immutable class representing a PDF operator.  Operators are similar to names, but are not preceded by a slash when output.
    /// </summary>
    public class PdfOperator : PdfName, IEquatable<PdfOperator>
    {
        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="op">The value of the new object.</param>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the parameter contains whitespace characters, or characters classed as "delimiters" by the PDF standard.</exception>
        public PdfOperator(string op) : base(op)
        {
        }

        /// <summary>
        /// Convert this object to an array of bytes.
        /// </summary>
        /// <returns>An array of bytes representing this object.</returns>
        protected override byte[] FormatBytes()
        {
            return Encoding.UTF8.GetBytes($"{Value} ");
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="other">The object to test against.</param>
        /// <returns>True if the other object has the same value as this; false otherwise.</returns>
        public bool Equals(PdfOperator other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Value == other.Value;
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="obj">The object to test against.</param>
        /// <returns>True if the other object is a <see cref="PdfName" /> instance with the same value as this; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PdfOperator);
        }

        /// <summary>
        /// Generate a hashcode for this object.
        /// </summary>
        /// <returns>The hashcode of the value of this object.</returns>
        public override int GetHashCode()
        {
            return $"{Value} ".GetHashCode();
        } 

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfOperator" /> instance.</param>
        /// <param name="b">Another <see cref="PdfOperator" /> instance.</param>
        /// <returns>True if the parameters are equal; false otherwise.</returns>
        public static bool operator ==(PdfOperator a, PdfOperator b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            return a.Value == b.Value;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfOperator" /> instance.</param>
        /// <param name="b">Another <see cref="PdfOperator" /> instance.</param>
        /// <returns>True if the parameters are unequal; false otherwise.</returns>
        public static bool operator !=(PdfOperator a, PdfOperator b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            if (a == null || b == null)
            {
                return true;
            }
            return a.Value != b.Value;
        }
    }
}
