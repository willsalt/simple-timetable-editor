using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfReal : IPdfPrimitiveObject, IEquatable<PdfReal>
    {
        private readonly decimal _val;
        private byte[] cachedBytes = null;

        public decimal Value => _val;

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

        public PdfReal(decimal val)
        {
            _val = val;
        }

        public PdfReal(int val)
        {
            _val = val;
        }

        public PdfReal(float val)
        {
            _val = (decimal)val;
        }

        public PdfReal(double val)
        {
            _val = (decimal)val;
        }

        private void FormatBytes()
        {
            string formatted = _val.ToString("################0.0################ ", CultureInfo.InvariantCulture);
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
            return a._val == b._val;
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
            return a._val != b._val;
        }
    }
}
