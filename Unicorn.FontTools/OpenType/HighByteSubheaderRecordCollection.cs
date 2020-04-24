using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicorn.FontTools.OpenType
{
    public class HighByteSubheaderRecordCollection : IReadOnlyCollection<HighByteSubheaderRecord>
    {
        private HighByteSubheaderRecord[] _data;

        public HighByteSubheaderRecordCollection(IEnumerable<HighByteSubheaderRecord> data)
        {
            if (data is null)
            {
                _data = Array.Empty<HighByteSubheaderRecord>();
            }
            else
            {
                _data = data.ToArray();
            }
        }

        public HighByteSubheaderRecord this[int index] => _data[index];

        public int Count => _data.Length;

        public IEnumerator<HighByteSubheaderRecord> GetEnumerator() => _data.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
