using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType
{
    public class SegmentSubheaderRecordCollection : IReadOnlyCollection<SegmentSubheaderRecord>
    {
        SegmentSubheaderRecord[] _data;

        public SegmentSubheaderRecordCollection(IEnumerable<SegmentSubheaderRecord> data)
        {
            if (data is null)
            {
                _data = Array.Empty<SegmentSubheaderRecord>();
            }
            else
            {
                _data = data.ToArray();
            }
        }

        public SegmentSubheaderRecord this[int index] => _data[index];

        public int Count => _data.Length;

        public IEnumerator<SegmentSubheaderRecord> GetEnumerator() => _data.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
