using System;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    public class PdfName : PdfSimpleObject, IEquatable<PdfName>
    {
        public string Value { get; }

        public PdfName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ContainsWhitespace(name) || ContainsDelimiter(name))
            {
                throw new Exception($"Name {name} contains illegal characters");
            }
            Value = name;
        }

        protected override byte[] FormatBytes()
        {
            return Encoding.UTF8.GetBytes($"/{Value} ");
        }

        private bool ContainsWhitespace(string name)
        {
            return name.Contains(" ") || name.Contains("\x0") || name.Contains("\t") || name.Contains("\r") || name.Contains("\n") || name.Contains("\f");
        }

        private bool ContainsDelimiter(string name)
        {
            return name.Contains("(") || name.Contains(")") || name.Contains("<") || name.Contains(">") || name.Contains("[") || name.Contains("]") || name.Contains("{") ||
                name.Contains("}") || name.Contains("/") || name.Contains("%");
        }

        public bool Equals(PdfName other)
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

        public static bool operator ==(PdfName a, PdfName b)
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

        public static bool operator !=(PdfName a, PdfName b)
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
