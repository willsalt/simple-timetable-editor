using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfStream : PdfIndirectObject, IPdfPrimitiveObject
    {
        private readonly List<byte> _contents = new List<byte>();

        public PdfStream(int objectId, int generation = 0) : base(objectId, generation)
        {

        }

        public void AddBytes(IEnumerable<byte> bytes)
        {
            _contents.AddRange(bytes);
        }

        public override int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, PdfDictionary.WriteTo, stream);
        }

        public override int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            return Write(WriteToList, PdfDictionary.WriteTo, list);
        }

        private int Write<T>(Action<T, byte[]> writer, Func<PdfDictionary, T, int> dictWriter, T dest)
        {
            if (CachedPrologue == null)
            {
                GeneratePrologueAndEpilogue();
            }
            writer(dest, CachedPrologue.ToArray());
            int written = CachedPrologue.Count;
            PdfDictionary dict = new PdfDictionary();
            dict.Add(CommonPdfNames.Length, new PdfInteger(_contents.Count));
            written += dictWriter(dict, dest);
            byte[] startStream = new byte[] { 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };
            byte[] endStream = new byte[] { 0xa, 0x65, 0x6e, 0x64, 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };
            writer(dest, startStream);
            writer(dest, _contents.ToArray());
            writer(dest, endStream);
            written += startStream.Length;
            written += _contents.Count;
            written += endStream.Length;
            writer(dest, CachedEpilogue.ToArray());
            written += CachedPrologue.Count + CachedEpilogue.Count;
            return written;
        }
    }
}
