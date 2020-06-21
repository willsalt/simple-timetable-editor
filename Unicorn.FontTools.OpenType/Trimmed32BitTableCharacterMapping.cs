using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// OpenType character mapping type 10.  "This format is not widely used and is not supported by Microsoft" according to the OpenType spec.
    /// </summary>
    public class Trimmed32BitTableCharacterMapping : CharacterMapping
    {
        private readonly uint _startCode;

        private readonly ushort[] _data;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">Platform that this mapping is for.</param>
        /// <param name="encoding">Encoding that this mapping applies to.</param>
        /// <param name="lang">Language that this mapping applies to (if appropriate).</param>
        /// <param name="start">Lowest codepoint mapped by this mapping.</param>
        /// <param name="data">Table of glyphs that this mapping maps to.</param>
        public Trimmed32BitTableCharacterMapping(PlatformId platform, ushort encoding, ushort lang, uint start, IEnumerable<ushort> data) 
            : base(platform, encoding, lang)
        {
            _startCode = start;
            if (data is null)
            {
                _data = Array.Empty<ushort>();
            }
            else
            {
                _data = data.ToArray();
            }
        }

        /// <summary>
        /// Construct a <see cref="Trimmed32BitTableCharacterMapping" /> instance from an array of bytes.
        /// </summary>
        /// <param name="platform">The platform that this mapping is for.</param>
        /// <param name="encoding">The encoding this mapping applies to.</param>
        /// <param name="arr">Source data for the mapping.</param>
        /// <param name="offset">The location in the source data at which data for this mapping starts.</param>
        /// <returns></returns>
        public static Trimmed32BitTableCharacterMapping FromBytes(PlatformId platform, ushort encoding, byte[] arr, int offset)
        {
            ushort lang = (ushort)arr.ToUInt(offset + 8);
            uint startCode = arr.ToUInt(offset + 12);
            uint count = arr.ToUInt(offset + 16);
            ushort[] data = new ushort[count];
            for (int i = 0; i < count; ++i)
            {
                data[i] = arr.ToUShort(offset + 20 + 2 * i);
            }
            return new Trimmed32BitTableCharacterMapping(platform, encoding, lang, startCode, data);
        }

        /// <summary>
        /// Dump the content of this subtable to a <see cref="TextWriter" />.  Returns silently if the parameter is null.  At present this only dumps the segment table,
        /// not the glyph mapping table.
        /// </summary>
        /// <param name="writer">The writer to dump output to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine($"Character mapping for {Platform} encoding {Encoding} language {Language} (type 10)");
            writer.WriteLine($"Mapping is for character codes {_startCode} to {_startCode + _data.Length - 1} inclusive.");
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override ushort MapCodePoint(byte codePoint)
        {
            return MapCodePoint((uint)codePoint);
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override ushort MapCodePoint(ushort codePoint)
        {
            return MapCodePoint((uint)codePoint);
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public override ushort MapCodePoint(uint codePoint)
        {
            if (codePoint < _startCode)
            {
                return 0;
            }
            if (codePoint >= _startCode + _data.Length)
            {
                return 0;
            }
            return _data[codePoint - _startCode];
        }
    }
}
