using System.IO;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfBoolean : IPdfPrimitiveObject
    {
        private readonly bool _val;

        private static byte[] _true = { 0x74, 0x72, 0x75, 0x65, 0x20 };
        private static byte[] _false = { 0x66, 0x61, 0x6c, 0x73, 0x65, 0x20 };

        public bool Value => _val;

        public PdfBoolean(bool val)
        {
            _val = val;
        }

        public int WriteTo(Stream stream)
        {
            if (_val)
            {
                stream.Write(_true, 0, _true.Length);
                return _true.Length;
            }
            stream.Write(_false, 0, _false.Length);
            return _false.Length;
        }
    }
}
