using System.Collections.Generic;
using System.Linq;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfArray : PdfSimpleObject
    {
        private readonly IPdfPrimitiveObject[] _val;

        public PdfArray(IEnumerable<IPdfPrimitiveObject> contents)
        {
            _val = contents.ToArray();
        }

        protected override byte[] FormatBytes()
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
            return byteList.ToArray();
        }
    }
}
