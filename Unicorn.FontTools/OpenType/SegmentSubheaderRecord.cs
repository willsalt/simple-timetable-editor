using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.FontTools.OpenType
{
    public class SegmentSubheaderRecord
    {
        public ushort StartCode { get; }

        public ushort EndCode { get; }

        public short IdDelta { get; }

        public int StartOffset { get; }

        public SegmentSubheaderRecord(ushort start, ushort end, short delta, int offset)
        {
            StartCode = start;
            EndCode = end;
            IdDelta = delta;
            StartOffset = offset;
        }
    }
}
