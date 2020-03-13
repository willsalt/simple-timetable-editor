using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// A class to represent a PDF stream.  These have to be stored as indirect objects, and consist of a dictionary containing stream metadata followed by the stream content itself.
    /// </summary>
    public class PdfStream : PdfIndirectObject, IPdfPrimitiveObject
    {
        private readonly List<byte> _contents = new List<byte>();

        private static readonly byte[] _streamStart = new byte[] { 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };
        private static readonly byte[] _streamEnd = new byte[] { 0xa, 0x65, 0x6e, 0x64, 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };

        /// <summary>
        /// Constructor, with indirect object parameters.
        /// </summary>
        /// <param name="objectId">An indirect object ID obtained from a cross-reference table.</param>
        /// <param name="generation">The generation number of this stream.  Defaults to 0.</param>
        public PdfStream(int objectId, int generation = 0) : base(objectId, generation)
        {
            MetaDictionary = new PdfDictionary();
            MetaDictionary.Add(CommonPdfNames.Length, PdfInteger.Zero);
        }

        /// <summary>
        /// A read-only copy of the stream contents.
        /// </summary>
        public List<byte> Contents => _contents.ToList();

        /// <summary>
        /// The length of this object when converted into a stream of bytes.
        /// </summary>
        public override int ByteLength
        {
            get
            {
                if (CachedPrologue == null)
                {
                    GeneratePrologueAndEpilogue();
                }
                UpdateMetaDictionary();
                return CachedPrologue.Count + CachedEpilogue.Count + MetaDictionary.ByteLength + _contents.Count + _streamStart.Length + _streamEnd.Length;
            }
        }

        private PdfDictionary MetaDictionary { get; set; }

        private void UpdateMetaDictionary()
        {
            if ((MetaDictionary[CommonPdfNames.Length] as PdfInteger).Value != _contents.Count)
            {
                MetaDictionary[CommonPdfNames.Length] = new PdfInteger(_contents.Count);
            }
        }

        /// <summary>
        /// Add data to the stream.
        /// </summary>
        /// <param name="bytes">The data to add to the stream.</param>
        public void AddBytes(IEnumerable<byte> bytes)
        {
            _contents.AddRange(bytes);
        }

        /// <summary>
        /// Write this stream to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public override int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, PdfDictionary.WriteTo, stream);
        }

        /// <summary>
        /// Convert this stream to an array of bytes and append them to a <see cref="List{Byte}" />.
        /// </summary>
        /// <param name="list">The list to append to.</param>
        /// <returns>The number of bytes appended.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list parameter is null.</exception>
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
            writer(dest, _streamStart);
            writer(dest, _contents.ToArray());
            writer(dest, _streamEnd);
            written += _streamStart.Length;
            written += _contents.Count;
            written += _streamEnd.Length;
            writer(dest, CachedEpilogue.ToArray());
            written += CachedPrologue.Count + CachedEpilogue.Count;
            return written;
        }
    }
}
