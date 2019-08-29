using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfBoolean : IPdfPrimitiveObject, IEquatable<PdfBoolean>
    {
        private readonly bool _val;

        private static byte[] _true = { 0x74, 0x72, 0x75, 0x65, 0x20 };
        private static byte[] _false = { 0x66, 0x61, 0x6c, 0x73, 0x65, 0x20 };

        public static readonly PdfBoolean True = new PdfBoolean(true);
        public static readonly PdfBoolean False = new PdfBoolean(false);

        public bool Value => _val;

        public int ByteLength => _val ? _true.Length : _false.Length;

        private PdfBoolean(bool val)
        {
            _val = val;
        }

        public static PdfBoolean Get(bool val)
        {
            return val ? True : False;
        }

        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (_val)
            {
                stream.Write(_true, 0, _true.Length);
                return _true.Length;
            }
            stream.Write(_false, 0, _false.Length);
            return _false.Length;
        }

        public int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            list.AddRange(_val ? _true : _false);
            return _val ? _true.Length : _false.Length;
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
            return a._val == b._val;
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
            return a._val != b._val;
        }
    }
}
