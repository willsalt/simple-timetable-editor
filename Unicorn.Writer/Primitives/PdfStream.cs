using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfStream : PdfIndirectObject, IPdfPrimitiveObject
    {
        private List<byte> _contents = new List<byte>();

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
            if (_cachedPrologue == null)
            {
                GeneratePrologueAndEpilogue();
            }
            stream.Write(_cachedPrologue, 0, _cachedPrologue.Length);
            int written = _cachedPrologue.Length;
            PdfDictionary dict = new PdfDictionary();
            dict.Add(new PdfName("Length"), new PdfInteger(_contents.Count));
            written += dict.WriteTo(stream);
            byte[] startStream = new byte[] { 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };
            byte[] endStream = new byte[] { 0xa, 0x65, 0x6e, 0x64, 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };
            stream.Write(startStream, 0, startStream.Length);
            stream.Write(_contents.ToArray(), 0, _contents.Count);
            stream.Write(endStream, 0, endStream.Length);
            written += startStream.Length;
            written += _contents.Count;
            written += endStream.Length;
            stream.Write(_cachedEpilogue, 0, _cachedEpilogue.Length);
            written += _cachedEpilogue.Length + _cachedPrologue.Length;
            return written;
        }

        public override int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (_cachedPrologue == null)
            {
                GeneratePrologueAndEpilogue();
            }
            list.AddRange(_cachedPrologue);
            int written = _cachedPrologue.Length;
            PdfDictionary dict = new PdfDictionary();
            dict.Add(new PdfName("Length"), new PdfInteger(_contents.Count));
            written += dict.WriteTo(list);
            byte[] startStream = new byte[] { 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };
            byte[] endStream = new byte[] { 0xa, 0x65, 0x6e, 0x64, 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };
            list.AddRange(startStream);
            list.AddRange(_contents);
            list.AddRange(endStream);
            written += startStream.Length;
            written += _contents.Count;
            written += endStream.Length;
            list.AddRange(_cachedEpilogue);
            written += _cachedEpilogue.Length + _cachedPrologue.Length;
            return written;
        }
    }
}
