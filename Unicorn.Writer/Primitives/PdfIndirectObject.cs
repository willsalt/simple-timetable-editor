using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfIndirectObject : IPdfPrimitiveObject, IPdfIndirectObject
    {
        private readonly IPdfPrimitiveObject _contents;
        private byte[] _cachedPrologue;
        private byte[] _cachedEpilogue;
        private readonly bool _nonCacheable;
        private byte[] _cachedReference;

        public int ObjectId { get; }

        public int Generation { get; }

        public int ByteLength
        {
            get
            {
                if (_cachedPrologue == null)
                {
                    GeneratePrologueAndEpilogue();
                }
                int val = _cachedPrologue.Length + _cachedEpilogue.Length + _contents.ByteLength;
                if (_nonCacheable)
                {
                    _cachedPrologue = null;
                    _cachedEpilogue = null;
                }
                return val;
            }
        }

        public int ReferenceLength
        {
            get
            {
                if (_cachedReference == null)
                {
                    GenerateReference();
                }
                return _cachedReference.Length;
            }
        }

        public PdfIndirectObject(int objectId, IPdfPrimitiveObject contents, int generation = 0)
        {
            if (contents is IPdfIndirectObject)
            {
                throw new ArgumentException(Resources.Primitives_PdfIndirectObject_Nest_PdfIndirectObject_Error, nameof(contents));
            }
            if (objectId <= 0)
            {
                throw new ArgumentException(Resources.Primitives_PdfIndirectObject_Invalid_ObjectId_Error, nameof(objectId));
            }
            if (generation < 0)
            {
                throw new ArgumentException(Resources.Primitives_PdfIndirectObject_Invalid_Generation_Error, nameof(generation));
            }
            if (contents == null)
            {
                contents = PdfNull.Value;
            }

            ObjectId = objectId;
            Generation = generation;
            _contents = contents;
            _nonCacheable = contents is PdfDictionary;
        }

        public int WriteTo(Stream stream)
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
            int written = _contents.WriteTo(stream);
            stream.Write(_cachedEpilogue, 0, _cachedEpilogue.Length);
            written += _cachedEpilogue.Length + _cachedPrologue.Length;
            if (_nonCacheable)
            {
                _cachedPrologue = null;
            }
            return written;
        }

        public int WriteTo(List<byte> list)
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
            int written = _contents.WriteTo(list);
            list.AddRange(_cachedEpilogue);
            written += _cachedEpilogue.Length + _cachedPrologue.Length;
            if (_nonCacheable)
            {
                _cachedPrologue = null;
            }
            return written;
        }

        public byte[] GetReference()
        {
            if (_cachedReference == null)
            {
                GenerateReference();
            }
            return _cachedReference;
        }

        private void GeneratePrologueAndEpilogue()
        {
            int contentLen = _contents.ByteLength;            
            string prologueString = $"{ObjectId} {Generation} obj ";
            if (contentLen + prologueString.Length > 253)
            {
                prologueString += "\xa";
            }
            if (contentLen + prologueString.Length > 247)
            {
                _cachedEpilogue = new byte[] { 0xa, 0x65, 0x6e, 0x64, 0x6f, 0x62, 0x6a, 0xa };
            }
            else
            {
                _cachedEpilogue = new byte[] { 0x65, 0x6e, 0x64, 0x6f, 0x62, 0x6a, 0xa };
            }
            _cachedPrologue = Encoding.ASCII.GetBytes(prologueString);
        }

        private void GenerateReference()
        {
            string theRef = $"{ObjectId} {Generation} R ";
            _cachedReference = Encoding.ASCII.GetBytes(theRef);
        }
    }
}
