using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfIndirectObject : IPdfPrimitiveObject, IPdfIndirectObject
    {
        private readonly IPdfPrimitiveObject _contents;
        private readonly bool _nonCacheable;
        private PdfReference _reference = null;

        protected List<byte> CachedPrologue { get; private set; }

        protected List<byte> CachedEpilogue { get; private set; }
        

        public int ObjectId { get; }

        public int Generation { get; }

        public int ByteLength
        {
            get
            {
                if (CachedPrologue == null)
                {
                    GeneratePrologueAndEpilogue();
                }
                int val = CachedPrologue.Count + CachedEpilogue.Count + _contents.ByteLength;
                if (_nonCacheable)
                {
                    CachedPrologue = null;
                    CachedEpilogue = null;
                }
                return val;
            }
        }

        protected PdfIndirectObject(int objectId, int generation)
        {
            if (objectId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(objectId), Resources.Primitives_PdfIndirectObject_Invalid_ObjectId_Error);
            }
            if (generation < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(generation), Resources.Primitives_PdfIndirectObject_Invalid_Generation_Error);
            }

            ObjectId = objectId;
            Generation = generation;
        }

        public PdfIndirectObject(int objectId, IPdfPrimitiveObject contents, int generation = 0) : this(objectId, generation)
        {
            if (contents is IPdfIndirectObject)
            {
                throw new ArgumentException(Resources.Primitives_PdfIndirectObject_Nest_PdfIndirectObject_Error, nameof(contents));
            }
            if (contents == null)
            {
                contents = PdfNull.Value;
            }

            _contents = contents;
            _nonCacheable = contents is PdfDictionary;
        }

        public virtual int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, _contents.WriteTo, stream);
        }

        public virtual int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            return Write(WriteToList, _contents.WriteTo, list);
        }

        public virtual int WriteTo(PdfStream stream)
        {
            throw new InvalidOperationException(Resources.Primitives_PdfIndirectObject_Write_To_PdfStream_Error);
        }

        protected int Write<T>(Action<T, byte[]> writer, Func<T, int> contentWriter, T dest)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            if (CachedPrologue == null)
            {
                GeneratePrologueAndEpilogue();
            }
            writer(dest, CachedPrologue.ToArray());
            int written = contentWriter(dest);
            writer(dest, CachedEpilogue.ToArray());
            written += CachedPrologue.Count + CachedEpilogue.Count;
            if (_nonCacheable)
            {
                CachedPrologue = null;
            }
            return written;
        }

        protected static void WriteToStream(Stream str, byte[] bytes)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            str.Write(bytes, 0, bytes.Length);
        }

        protected static void WriteToList(List<byte> list, byte[] bytes)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            list.AddRange(bytes);
        }

        public PdfReference GetReference()
        {
            return _reference ?? (_reference = new PdfReference(this));
        }

        protected void GeneratePrologueAndEpilogue()
        {
            int contentLen = _contents?.ByteLength ?? 2;            
            string prologueString = $"{ObjectId} {Generation} obj ";
            if (contentLen + prologueString.Length > 253)
            {
                prologueString += "\xa";
            }
            if (contentLen + prologueString.Length > 247)
            {
                CachedEpilogue = new List<byte> { 0xa, 0x65, 0x6e, 0x64, 0x6f, 0x62, 0x6a, 0xa };
            }
            else
            {
                CachedEpilogue = new List<byte> { 0x65, 0x6e, 0x64, 0x6f, 0x62, 0x6a, 0xa };
            }
            CachedPrologue = Encoding.ASCII.GetBytes(prologueString).ToList();
        }
    }
}
