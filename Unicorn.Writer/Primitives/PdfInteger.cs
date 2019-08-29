using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfInteger : IPdfPrimitiveObject, IEquatable<PdfInteger>
    {
        private readonly int _val;
        private byte[] cachedBytes = null;

        public int Value => _val;

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

        public PdfInteger(int val)
        {
            _val = val;
        }

        private void FormatBytes()
        {
            string formatted = _val.ToString("d", CultureInfo.InvariantCulture) + " ";
            cachedBytes = Encoding.ASCII.GetBytes(formatted);
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

        public int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (cachedBytes == null)
            {
                FormatBytes();
            }
            list.AddRange(cachedBytes);
            return cachedBytes.Length;
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
            return a._val == b._val;
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
            return a._val != b._val;
        }
    }
}
