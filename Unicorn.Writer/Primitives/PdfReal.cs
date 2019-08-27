using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfReal : IPdfPrimitiveObject
    {
        private readonly decimal _val;

        public decimal Value => _val;

        public PdfReal(decimal val)
        {
            _val = val;
        }

        public PdfReal(int val)
        {
            _val = val;
        }

        public PdfReal(float val)
        {
            _val = (decimal)val;
        }

        public PdfReal(double val)
        {
            _val = (decimal)val;
        }

        public int WriteTo(Stream stream)
        {
            string formatted = _val.ToString("################0.0################ ", CultureInfo.InvariantCulture);
            byte[] output = Encoding.ASCII.GetBytes(formatted);
            stream.Write(output, 0, output.Length);
            return output.Length;
        }
    }
}
