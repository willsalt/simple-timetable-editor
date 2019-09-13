using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Structural
{
    public class PdfCrossRefTable : IPdfCrossRefTable
    {
        private List<PdfCrossRefTableEntry> _contents = new List<PdfCrossRefTableEntry>() { null };

        public int Count => _contents.Count;

        public int ClaimSlot()
        {
            lock (_contents)
            {
                _contents.Add(null);
                return _contents.Count - 1;
            }
        }

        public void SetSlot(IPdfIndirectObject value, int offset)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            PdfCrossRefTableEntry entry = new PdfCrossRefTableEntry(value, offset);
            _contents[value.ObjectId] = entry;
        }

        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            int written = 0;
            lock (_contents)
            {
                byte[] prologueLineOne = new byte[] { 0x78, 0x72, 0x65, 0x66, 0xa };
                string prologueLineTwoStr = $"0 {_contents.Count - 1}\xa";
                byte[] prologueLineTwo = Encoding.ASCII.GetBytes(prologueLineTwoStr);
                stream.Write(prologueLineOne, 0, prologueLineOne.Length);
                written += prologueLineOne.Length;
                stream.Write(prologueLineTwo, 0, prologueLineTwo.Length);
                written += prologueLineTwo.Length;
                for (int i = 0; i < _contents.Count; ++i)
                {
                    if (_contents[i] == null)
                    {
                        written += WriteNullEntry(i, stream);
                    }
                    else
                    {
                        written += WriteEntry(_contents[i], stream);
                    }
                }
                return written;
            }
        }

        private int WriteEntry(PdfCrossRefTableEntry entry, Stream stream)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(string.Format(CultureInfo.InvariantCulture, "{0:10d} {1:5d} n \xa", entry.Offset, entry.Value.Generation));
            stream.Write(bytes, 0, bytes.Length);
            return bytes.Length;
        }

        private int WriteNullEntry(int i, Stream stream)
        {
            int nextItem = i < _contents.Count - 1 ? _contents.FindIndex(i + 1, e => e == null) : 0;
            if (nextItem < 0)
            {
                nextItem = 0;
            }
            byte[] bytes = Encoding.ASCII.GetBytes(string.Format(CultureInfo.InvariantCulture, "{0:10d} {1:5d} f \xa", nextItem, i == 0 ? 65535 : 0));
            stream.Write(bytes, 0, bytes.Length);
            return bytes.Length;
        }
    }
}
