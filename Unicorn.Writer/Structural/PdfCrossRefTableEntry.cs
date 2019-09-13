using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Structural
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
