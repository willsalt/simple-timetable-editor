using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfNull : IPdfPrimitiveObject, IEquatable<PdfNull>
    {
        public static readonly PdfNull Value = new PdfNull();

        private static readonly byte[] bytes = { 0x6e, 0x75, 0x6c, 0x6c, 0x20 };

        public int ByteLength => 5;

        private PdfNull() { }

        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            stream.Write(bytes, 0, bytes.Length);
            return bytes.Length;
        }

        public int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            list.AddRange(bytes);
            return bytes.Length;
        }

        public bool Equals(PdfNull other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is PdfNull;
        }

        public override int GetHashCode()
        {
            return 4472;
        }

        public static bool operator ==(PdfNull a, PdfNull b)
        {
            return ReferenceEquals(a, b) || (a != null && b != null);
        }

        public static bool operator !=(PdfNull a, PdfNull b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            if (a == null || b == null)
            {
                return true;
            }
            return false;
        }
    }
}
