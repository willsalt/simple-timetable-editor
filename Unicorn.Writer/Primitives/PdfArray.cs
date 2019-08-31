using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfArray : IPdfPrimitiveObject
    {
        private readonly IPdfPrimitiveObject[] _val;
        private byte[] cachedBytes = null;

        public int ByteLength
        {
            get
            {
                if (cachedBytes == null)
                {
                    GenerateBytes();
                }
                return cachedBytes.Length;
            }
        }

        public PdfArray(IEnumerable<IPdfPrimitiveObject> contents)
        {
            _val = contents.ToArray();
        }

        public int WriteTo(Stream str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (cachedBytes == null)
            {
                GenerateBytes();
            }
            str.Write(cachedBytes, 0, cachedBytes.Length);
            return cachedBytes.Length;
        }

        public int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (cachedBytes == null)
            {
                GenerateBytes();
            }
            list.AddRange(cachedBytes);
            return cachedBytes.Length;
        }

        private void GenerateBytes()
        {
            List<byte> byteList = new List<byte>() { 0x5b };
            int runningCount = 1;
            foreach (IPdfPrimitiveObject obj in _val)
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
            byteList.Add(0x5d);
            byteList.Add(0xa);
            cachedBytes = byteList.ToArray();
        }
    }
}
