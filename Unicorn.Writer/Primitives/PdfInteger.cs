using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfInteger : IPdfPrimitiveObject
    {
        private readonly int _val;

        public int Value => _val;

        public PdfInteger(int val)
        {
            _val = val;
        }

        public int WriteTo(Stream stream)
        {
            string formatted = _val.ToString("d") + " ";
            byte[] output = Encoding.ASCII.GetBytes(formatted);
            stream.Write(output, 0, output.Length);
            return output.Length;
        }
    }
}
