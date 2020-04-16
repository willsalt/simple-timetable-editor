using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.MemoryMappedFiles;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// OpenType font data and metadata.
    /// </summary>
    public class OpenTypeFont
    {
        /// <summary>
        /// The header <see cref="OffsetTable" /> - the most important contents being the number of data tables in the font.
        /// </summary>
        public OffsetTable Header { get; set; }

        /// <summary>
        /// The index of data tables in the font.
        /// </summary>
        public Dictionary<string, TableIndexRecord> TableIndex { get; } = new Dictionary<string, TableIndexRecord>();

        private OpenTypeFont()
        {

        }

        /// <summary>
        /// Confirm that the structure of this font is valid.  Currently checks that it has an OffsetTable and records in the index for all of the compulsary
        /// table types for this type of font.
        /// </summary>
        public void CheckValidity()
        {
            if (Header is null)
            {
                throw new OpenTypeFormatException(Resources.OpenType_OpenTypeFont_CheckValidity_MissingHeaderError);
            }
            CheckTablesPresent();
        }

        private void CheckTablesPresent()
        {
            string[] requiredTables = new[] { "cmap", "head", "hhea", "hmtx", "maxp", "name", "OS/2", "post" };
            string[] requiredTrueTypeTables = new[] { "glyf", "loca" };
            string[] requiredCffTables = new[] { "CFF ", "CFF2" };
            CheckTablesPresent(requiredTables);
            switch (Header.FontKind)
            {
                case FontKind.TrueType:
                    CheckTablesPresent(requiredTrueTypeTables);
                    break;
                case FontKind.Cff:
                    CheckTablesPresent(requiredCffTables);
                    break;
            }
        }

        private void CheckTablesPresent(IEnumerable<string> tableNames)
        {
            string[] missingTables = tableNames.Where(t => !TableIndex.ContainsKey(t)).ToArray();
            if (missingTables.Length > 0)
            {
                throw new OpenTypeFormatException(string.Format(CultureInfo.CurrentCulture,
                    Resources.OpenType_OpenTypeFont_CheckTablesPresent_MissingTablesError, string.Join(", ", missingTables)));
            }
        }

        /// <summary>
        /// Load an OpenType font from a memory-mapped file.
        /// </summary>
        /// <param name="mmf">The memory-mapped file to load data from.</param>
        /// <returns>A font object.</returns>
        public static OpenTypeFont LoadFrom(MemoryMappedFile mmf)
        {
            if (mmf is null)
            {
                throw new ArgumentNullException(nameof(mmf));
            }
            OpenTypeFont font = new OpenTypeFont();
            MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read);
            font.Header = LoadOffsetTable(accessor);
            long offset = 12;
            for (int i = 0; i < font.Header.TableCount; ++i)
            {
                TableIndexRecord record = LoadTableRecord(accessor, offset + i * 16);
                font.TableIndex.Add(record.TableTag.Value, record);
            }
            return font;
        }

        private static OffsetTable LoadOffsetTable(MemoryMappedViewAccessor accessor)
        {
            FontKind fontKind;
            ushort tableCount, searchRange, entrySelector, rangeShift;
            byte[] buffer = new byte[4];
            accessor.ReadArray(0, buffer, 0, 4);
            uint magicNumber = buffer.ToUInt();
            switch (magicNumber)
            {
                case 0x10000:
                    fontKind = FontKind.TrueType;
                    break;
                case 0x4f54544f:
                    fontKind = FontKind.Cff;
                    break;
                default:
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.OpenType_OpenTypeFont_LoadOffsetTable_UnknownMagicError,
                        magicNumber));
            }
            accessor.ReadArray(4, buffer, 0, 2);
            tableCount = buffer.ToUShort();
            accessor.ReadArray(6, buffer, 0, 2);
            searchRange = buffer.ToUShort();
            accessor.ReadArray(8, buffer, 0, 2);
            entrySelector = buffer.ToUShort();
            accessor.ReadArray(10, buffer, 0, 2);
            rangeShift = buffer.ToUShort();

            return new OffsetTable(fontKind, tableCount, searchRange, entrySelector, rangeShift);
        }

        private static TableIndexRecord LoadTableRecord(MemoryMappedViewAccessor accessor, long offset)
        {
            byte[] buffer = new byte[4];
            Tag tableTag;
            uint checksum, tableOffset, len;
            accessor.ReadArray(offset, buffer, 0, 4);
            tableTag = new Tag(buffer);
            accessor.ReadArray(offset + 4, buffer, 0, 4);
            checksum = buffer.ToUInt();
            accessor.ReadArray(offset + 8, buffer, 0, 4);
            tableOffset = buffer.ToUInt();
            accessor.ReadArray(offset + 12, buffer, 0, 4);
            len = buffer.ToUInt();
            return new TableIndexRecord(tableTag, checksum, tableOffset, len);
        }
    }
}
