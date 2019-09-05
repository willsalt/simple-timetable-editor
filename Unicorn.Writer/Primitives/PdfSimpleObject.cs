using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public abstract class PdfSimpleObject : IPdfPrimitiveObject
    {
        private byte[] _cachedBytes = null;

        public int ByteLength
        {
            get
            {
                if (_cachedBytes == null)
                {
                    _cachedBytes = FormatBytes();
                }
                return _cachedBytes.Length;
            }
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

        public int WriteTo(PdfStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToPdfStream, stream);
        }

        private int Write<T>(Action<T, byte[]> writer, T dest)
        {
            if (_cachedBytes == null)
            {
                _cachedBytes = FormatBytes();
            }
            writer(dest, _cachedBytes);
            return _cachedBytes.Length;
        }

        private static void WriteToStream(Stream str, byte[] bytes)
        {
            str.Write(bytes, 0, bytes.Length);
        }

        private static void WriteToList(List<byte> list, byte[] bytes)
        {
            list.AddRange(bytes);
        }

        private static void WriteToPdfStream(PdfStream stream, byte[] bytes)
        {
            stream.AddBytes(bytes);
        }

        protected abstract byte[] FormatBytes();
    }
}
