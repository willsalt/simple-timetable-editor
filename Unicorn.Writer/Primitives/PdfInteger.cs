using System;
using System.Globalization;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    public class PdfInteger : PdfSimpleObject, IEquatable<PdfInteger>
    {
        public int Value { get; }

        public PdfInteger(int val)
        {
            Value = val;
        }

        protected override byte[] FormatBytes()
        {
            string formatted = Value.ToString("d", CultureInfo.InvariantCulture) + " ";
            return Encoding.ASCII.GetBytes(formatted);
        }

        public bool Equals(PdfInteger other)
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

        public override bool Equals(object obj)
        {
            return Equals(obj as PdfBoolean);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(PdfInteger a, PdfInteger b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a == null || b == null)
            {
                return false;
            }
            return a.Value == b.Value;
        }

        public static bool operator !=(PdfInteger a, PdfInteger b)
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
