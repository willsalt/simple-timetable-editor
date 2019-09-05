using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfDictionary : IPdfPrimitiveObject
    {
        private Dictionary<PdfName, IPdfPrimitiveObject> _contents = new Dictionary<PdfName, IPdfPrimitiveObject>();
        private byte[] cachedBytes = null;

        public int ByteLength
        {
            get
            {
                lock (_contents)
                {
                    if (cachedBytes == null)
                    {
                        GenerateBytes();
                    }
                    return cachedBytes.Length;
                }
            }
        }

        public void Add(PdfName key, IPdfPrimitiveObject value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                value = PdfNull.Value;
            }
            lock(_contents)
            {
                if (_contents.ContainsKey(key))
                {
                    throw new ArgumentException(Resources.Primitives_PdfDictionary_Add_Duplicate_Key_Error, nameof(key));
                }
                _contents.Add(key, value);
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

        internal static int WriteTo(PdfDictionary dict, Stream stream)
        {
            return dict.WriteTo(stream);
        }

        public int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            return Write(WriteToList, list);
        }

        internal static int WriteTo(PdfDictionary dict, List<byte> list)
        {
            return dict.WriteTo(list);
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
            byte[] currentBytes;
            lock (_contents)
            {
                if (cachedBytes == null)
                {
                    GenerateBytes();
                }
                currentBytes = cachedBytes;
            }
            writer(dest, currentBytes);
            return currentBytes.Length;
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

        private void GenerateBytes()
        {
            List<byte> byteList = new List<byte>() { 0x3c, 0x3c };
            int runningCount = 2;
            foreach (KeyValuePair<PdfName, IPdfPrimitiveObject> pair in _contents)
            {
                WriteObj(ref runningCount, byteList, pair.Key);
                WriteObj(ref runningCount, byteList, pair.Value);
            }
            if (runningCount > 253)
            {
                byteList.Add(0xa);
            }
            byteList.AddRange(new byte[] { 0x3e, 0x3e, 0xa });
            cachedBytes = byteList.ToArray();
        }

        private static void WriteObj(ref int runningCount, List<byte> byteList, IPdfPrimitiveObject obj)
        {
            int objLength = obj.ByteLength;
            if (runningCount + objLength > 254)
            {
                byteList.Add(0xa);
                runningCount = 0;
            }
            obj.WriteTo(byteList);
            if (objLength > 254)
            {
                byteList.Add(0xa);
                runningCount = 0;
            }
            else
            {
                runningCount += objLength;
            }
        }
    }
}
