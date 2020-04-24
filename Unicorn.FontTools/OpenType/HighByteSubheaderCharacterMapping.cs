using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    public class HighByteSubheaderCharacterMapping : CharacterMapping
    {
        private readonly int[] _highByteIndex;

        private readonly int[] _lowByteMap;

        HighByteSubheaderRecordCollection Subheaders { get; }

        public HighByteSubheaderCharacterMapping(PlatformId platform, ushort encoding, ushort lang, IEnumerable<int> highBytePointers, 
            IEnumerable<HighByteSubheaderRecord> subHeaders, IEnumerable<int> lowByteMap) 
            : base(platform, encoding, lang)
        {
            if (highBytePointers is null)
            {
                throw new ArgumentNullException(nameof(highBytePointers));
            }
            if (subHeaders is null)
            {
                throw new ArgumentNullException(nameof(subHeaders));
            }
            _highByteIndex = highBytePointers.ToArray();
            if (_highByteIndex.Length != 256)
            {
                throw new ArgumentException("High byte array of incorrect length", nameof(highBytePointers));
            }
            Subheaders = new HighByteSubheaderRecordCollection(subHeaders);
            _lowByteMap = lowByteMap?.ToArray() ?? Array.Empty<int>();
        }

        public static CharacterMapping FromBytes(PlatformId platform, ushort encoding, byte[] arr, int offset)
        {
            ushort len = arr.ToUShort(offset + 2);
            ushort lang = arr.ToUShort(offset + 4);
            int[] highByteTable = new int[256];
            for (int i = 0; i < 256; ++i)
            {
                highByteTable[i] = arr[offset + 6 + i];
            }
            int subheaderCount = highByteTable.Max() + 1;
            List<HighByteSubheaderRecord> subheaderRecords = new List<HighByteSubheaderRecord>(subheaderCount);
            for (int i = 0; i < subheaderCount; ++i)
            {
                subheaderRecords.Add(HighByteSubheaderRecord.FromBytes(arr, offset + 262 + i * 8, (subheaderCount - (i + 1)) * 8 + 2));
            }
            int lowByteTableStart = 262 + subheaderCount * 8;
            int[] lowByteTable = new int[len - lowByteTableStart];
            for (int i = lowByteTableStart; i < len; ++i)
            {
                lowByteTable[i - lowByteTableStart] = arr[i];
            }
            return new HighByteSubheaderCharacterMapping(platform, encoding, lang, highByteTable, subheaderRecords, lowByteTable);
        }

        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine($"Character mapping for {Platform} encoding {Encoding} language {Language} is a Type 2.");
        }

        public override ushort MapCodePoint(byte codePoint)
        {
            if (_highByteIndex[codePoint] != 0)
            {
                return 0;
            }
            return MapCodePoint(Subheaders[0], codePoint);
        }

        public override ushort MapCodePoint(ushort codePoint)
        {
            int highByte = (codePoint & 0xff00) >> 8;
            HighByteSubheaderRecord subheader = Subheaders[highByte];
            return MapCodePoint(subheader, (byte)(codePoint & 0xff));
        }
        
        private ushort MapCodePoint(HighByteSubheaderRecord subheader, byte lowByte)
        {
            if (lowByte < subheader.FirstByte || lowByte > subheader.LastByte)
            {
                return 0;
            }
            int mappedVal = _lowByteMap[subheader.StartIndex + (lowByte - subheader.FirstByte)];
            if (mappedVal == 0)
            {
                return 0;
            }
            return (ushort)((mappedVal + subheader.IdDelta) % 65536);
        }

        public override ushort MapCodePoint(uint codePoint)
        {
            if (codePoint > ushort.MaxValue)
            {
                return 0;
            }
            return MapCodePoint((ushort)codePoint);
        }
    }
}
