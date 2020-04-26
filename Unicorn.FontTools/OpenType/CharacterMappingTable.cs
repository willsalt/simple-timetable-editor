using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The 'cmap' table, containing a set of mappings from character encoding code points to font glyph IDs.
    /// </summary>
    public class CharacterMappingTable : Table
    {
        /// <summary>
        /// The set of mappings which make up the table data.
        /// </summary>
        public CharacterMappingCollection Mappings { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The set of mappings contained in the table.</param>
        public CharacterMappingTable(IEnumerable<CharacterMapping> data) : base("cmap")
        {
            Mappings = new CharacterMappingCollection(data);
        }

        /// <summary>
        /// Dump the content of this table to a <see cref="TextWriter" />.  Returns silently if the parameter is <c>null</c>.
        /// </summary>
        /// <param name="writer">The writer to dump output to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine($"cmap table has {Mappings.Count} character mappings.");
            foreach (CharacterMapping map in Mappings)
            {
                map.Dump(writer);
            }
        }

        private static int SubtableRecordOffset(int baseOffset, int count) => baseOffset + 4 + 8 * count;

        private static Func<PlatformId, ushort, byte[], int, CharacterMapping> GetSubtableBuilderMethod(CharacterMappingFormat version)
        {
            switch (version)
            {
                case CharacterMappingFormat.PlainByteMapping:
                    return PlainByteCharacterMapping.FromBytes;
                case CharacterMappingFormat.HighByteSubheaderMapping:
                    return HighByteSubheaderCharacterMapping.FromBytes;
                case CharacterMappingFormat.SegmentedMapping:
                    return SegmentedCharacterMapping.FromBytes;
                case CharacterMappingFormat.TrimmedTableMapping:
                    return TrimmedTableCharacterMapping.FromBytes;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Construct a <see cref="CharacterMappingTable" /> from an array of bytes.
        /// </summary>
        /// <param name="arr">The array of data to load from.</param>
        /// <param name="offset">The index of the start of the table within the data array.</param>
        /// <param name="len">The length of the table data within the array.</param>
        /// <returns></returns>
        public static CharacterMappingTable FromBytes(byte[] arr, int offset, uint len)
        {
            ushort mappingCount = arr.ToUShort(offset + 2);
            List<CharacterMapping> subtables = new List<CharacterMapping>(mappingCount);
            for (int i = 0; i < mappingCount; ++i)
            {
                PlatformId platform = (PlatformId)arr.ToUShort(SubtableRecordOffset(offset, i));
                ushort encoding = arr.ToUShort(SubtableRecordOffset(offset, i) + 2);
                int mappingOffset = arr.ToInt(SubtableRecordOffset(offset, i) + 4);
                CharacterMappingFormat subtableVersion = (CharacterMappingFormat) arr.ToUShort(offset + mappingOffset);
                Func<PlatformId, ushort, byte[], int, CharacterMapping> builder = GetSubtableBuilderMethod(subtableVersion);
                if (builder is null)
                {
                    Console.WriteLine($"No builder method defined for subtable type {subtableVersion} THIS IS TEMPORARY FIX IT");
                }
                else
                {
                    subtables.Add(builder(platform, encoding, arr, offset + mappingOffset));
                }
            }
            return new CharacterMappingTable(subtables);
        }
    }
}
