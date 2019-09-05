using System;

namespace Unicorn.Writer.Primitives
{
    public class PdfBoolean : PdfSimpleObject, IEquatable<PdfBoolean>
    {
        private static byte[] _true = { 0x74, 0x72, 0x75, 0x65, 0x20 };
        private static byte[] _false = { 0x66, 0x61, 0x6c, 0x73, 0x65, 0x20 };

        public static readonly PdfBoolean True = new PdfBoolean(true);
        public static readonly PdfBoolean False = new PdfBoolean(false);

        public bool Value { get; }

        private PdfBoolean(bool val)
        {
            Value = val;
        }

        public static PdfBoolean Get(bool val)
        {
            return val ? True : False;
        }

        protected override byte[] FormatBytes()
        {
            return Value ? _true : _false;
        }

        public bool Equals(PdfBoolean other)
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

        public static bool operator ==(PdfBoolean a, PdfBoolean b)
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

        public static bool operator !=(PdfBoolean a, PdfBoolean b)
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
