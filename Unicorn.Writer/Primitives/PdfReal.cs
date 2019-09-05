using System;
using System.Globalization;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    public class PdfReal : PdfSimpleObject, IEquatable<PdfReal>
    {
        public decimal Value { get; }

        public PdfReal(decimal val)
        {
            Value = val;
        }

        public PdfReal(int val)
        {
            Value = val;
        }

        public PdfReal(float val)
        {
            Value = (decimal)val;
        }

        public PdfReal(double val)
        {
            Value = (decimal)val;
        }

        protected override byte[] FormatBytes()
        {
            string formatted = Value.ToString("################0.0################ ", CultureInfo.InvariantCulture);
            return Encoding.ASCII.GetBytes(formatted);
        }

        public bool Equals(PdfReal other)
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

        public static bool operator ==(PdfReal a, PdfReal b)
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

        public static bool operator !=(PdfReal a, PdfReal b)
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
