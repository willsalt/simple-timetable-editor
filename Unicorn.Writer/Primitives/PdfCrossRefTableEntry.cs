using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfCrossRefTableEntry
    {
        public IPdfIndirectObject Value { get; }

        public int Offset { get; }

        public PdfCrossRefTableEntry(IPdfIndirectObject value, int offset)
        {
            Value = value;
            Offset = offset;
        }
    }
}
