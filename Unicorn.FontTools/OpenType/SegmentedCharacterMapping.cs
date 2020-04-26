using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    public class SegmentedCharacterMapping : CharacterMapping
    {
        private SegmentSubheaderRecordCollection Segments { get; }

        private readonly ushort[] _glyphData; 

        public SegmentedCharacterMapping(PlatformId platform, ushort encoding, ushort lang, IEnumerable<SegmentSubheaderRecord> segments, IEnumerable<ushort> glyphData) 
            : base(platform, encoding, lang)
        {
            Segments = new SegmentSubheaderRecordCollection(segments);
            if (glyphData is null)
            {
                _glyphData = Array.Empty<ushort>();
            }
            else
            {
                _glyphData = glyphData.ToArray();
            }
        }

        public static SegmentedCharacterMapping FromBytes(PlatformId platform, ushort encoding, byte[] arr, int offset)
        {
            ushort len = arr.ToUShort(offset + 2);
            ushort lang = arr.ToUShort(offset + 4);
            int segCount = arr.ToUShort(offset + 6) / 2;
            List<SegmentSubheaderRecord> segments = new List<SegmentSubheaderRecord>(segCount);
            for (int i = 0; i < segCount; ++i)
            {
                int glyphIdxOffset = arr.ToUShort(offset + 16 + 6 * segCount + 2 * i);
                if (glyphIdxOffset != 0)
                {
                    glyphIdxOffset = (glyphIdxOffset / 2) - (segCount - i);
                }
                else
                {
                    glyphIdxOffset = -1;
                }
                segments.Add(new SegmentSubheaderRecord(arr.ToUShort(offset + 16 + 2 * segCount + 2 * i), arr.ToUShort(offset + 14 + 2 * i),
                    arr.ToShort(offset + 16 + 4 * segCount + 2 * i), glyphIdxOffset));
            }
            int glyphCount = (len - (16 + 8 * segCount)) / 2;
            List<ushort> glyphData = new List<ushort>(glyphCount);
            for (int i = 0; i < glyphCount; ++i)
            {
                glyphData.Add(arr.ToUShort(offset + 16 + 8 * segCount + 2 * i));
            }
            return new SegmentedCharacterMapping(platform, encoding, lang, segments, glyphData);
        }

        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine($"Character mapping for {Platform} encoding {Encoding} language {Language} (type 4)");
            writer.WriteLine($"There are {Segments.Count} segments.");
            writer.WriteLine($"Segment | Start |   End |  Delta | Offset");
            writer.WriteLine($"--------|-------|-------|--------|-------");
            for (int i = 0; i < Segments.Count; ++i)
            {
                writer.WriteLine($"  {i,5} | {Segments[i].StartCode,5} | {Segments[i].EndCode,5} | {Segments[i].IdDelta,6} | {Segments[i].StartOffset,6}");
            }
        }

        public override ushort MapCodePoint(byte codePoint)
        {
            return MapCodePoint((ushort)codePoint);
        }

        public override ushort MapCodePoint(ushort codePoint)
        {
            SegmentSubheaderRecord segment = Segments.FirstOrDefault(s => s.EndCode >= codePoint && s.StartCode <= codePoint);
            if (segment is null)
            {
                return 0;
            }
            ushort glyphVal;
            if (segment.StartOffset == -1)
            {
                glyphVal = codePoint;
            }
            else
            {
                glyphVal = _glyphData[segment.StartOffset + (codePoint - segment.StartCode)];
                if (glyphVal == 0)
                {
                    return 0;
                }
            }
            return (ushort)((glyphVal + segment.IdDelta) % 65536);
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
