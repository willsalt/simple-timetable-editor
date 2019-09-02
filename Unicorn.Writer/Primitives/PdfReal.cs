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
        private byte[] cachedBytes = null;

        public decimal Value { get; }

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

        private void FormatBytes()
        {
            string formatted = Value.ToString("################0.0################ ", CultureInfo.InvariantCulture);
            cachedBytes = Encoding.ASCII.GetBytes(formatted);
        }

        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, stream);
        }

        public int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            return Write(WriteToList, list);
        }

        private int Write<T>(Action<T, byte[]> writer, T dest)
        {
            if (cachedBytes == null)
            {
                FormatBytes();
            }
            writer(dest, cachedBytes);
            return cachedBytes.Length;
        }

        private static void WriteToStream(Stream str, byte[] bytes)
        {
            str.Write(bytes, 0, bytes.Length);
        }

        private static void WriteToList(List<byte> list, byte[] bytes)
        {
            list.AddRange(bytes);
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
