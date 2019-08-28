using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfName : IPdfPrimitiveObject, IEquatable<PdfName>
    {
        private readonly string _val;
        private byte[] cachedBytes = null;

        public string Val => _val;

        public int ByteLength
        {
            get
            {
                if (cachedBytes == null)
                {
                    FormatBytes();
                }
                return cachedBytes.Length;
            }
        }

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
            _val = name;
        }

        private void FormatBytes()
        {
            string formatted = $"/{_val} ";
            cachedBytes = Encoding.UTF8.GetBytes(formatted);
        }

        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (cachedBytes == null)
            {
                FormatBytes();
            }
            stream.Write(cachedBytes, 0, cachedBytes.Length);
            return cachedBytes.Length;
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
            return _val == other._val;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PdfBoolean);
        }

        public override int GetHashCode()
        {
            return _val.GetHashCode();
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
            return a._val == b._val;
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
            return a._val != b._val;
        }
    }
}
