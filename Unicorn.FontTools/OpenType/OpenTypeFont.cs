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
        private readonly MemoryMappedViewAccessor _accessor;

        /// <summary>
        /// The header <see cref="OffsetTable" /> - the most important contents being the number of data tables in the font.
        /// </summary>
        public OffsetTable OffsetHeader { get; set; }

        /// <summary>
        /// The "head" table of the font, which must be present for the font to be a valid OpenType file.
        /// </summary>
        public HeaderTable Header
        {
            get
            {
                TableIndexRecord index = TableIndex["head"];
                if (index.Data == null)
                {
                    index.Data = GetTableData(index);
                }
                return (HeaderTable)index.Data;
            }
        }

        /// <summary>
        /// The "hhea" table of the font, which must be present for the font to be a valid OpenType file.
        /// </summary>
        public HorizontalHeaderTable HorizontalHeader
        {
            get
            {
                TableIndexRecord index = TableIndex["hhea"];
                if (index.Data == null)
                {
                    index.Data = GetTableData(index);
                }
                return (HorizontalHeaderTable)index.Data;
            }
        }

        /// <summary>
        /// The "maxp" table of this font, which must be present for the font to be a valid OpenType file.
        /// </summary>
        public MaximumProfileTable MaximumProfile
        {
            get
            {
                TableIndexRecord index = TableIndex["maxp"];
                if (index.Data == null)
                {
                    index.Data = GetTableData(index);
                }
                return (MaximumProfileTable)index.Data;
            }
        }

        /// <summary>
        /// The index of data tables in the font.
        /// </summary>
        public Dictionary<string, TableIndexRecord> TableIndex { get; } = new Dictionary<string, TableIndexRecord>();

        /// <summary>
        /// Confirm that the structure of this font is valid.  Currently checks that it has an OffsetTable and records in the index for all of the compulsary
        /// table types for this type of font.
        /// </summary>
        public void CheckValidity()
        {
            if (OffsetHeader is null)
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
            switch (OffsetHeader.FontKind)
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
        public OpenTypeFont(MemoryMappedFile mmf)
        {
            if (mmf is null)
            {
                throw new ArgumentNullException(nameof(mmf));
            }
            _accessor = mmf.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read);
            OffsetHeader = LoadOffsetTable(_accessor);
            long offset = 12;
            for (int i = 0; i < OffsetHeader.TableCount; ++i)
            {
                TableIndexRecord record = LoadTableRecord(_accessor, offset + i * 16);
                TableIndex.Add(record.TableTag.Value, record);
            }
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

        private TableIndexRecord LoadTableRecord(MemoryMappedViewAccessor accessor, long offset)
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
            return new TableIndexRecord(tableTag, checksum, tableOffset, len, GetLoadingMethod(tableTag));
        }

        private TableLoadingMethod GetLoadingMethod(Tag t)
        {
            switch (t.Value)
            {
                case "head":
                    return HeaderTable.FromBytes;
                case "hhea":
                    return HorizontalHeaderTable.FromBytes;
                case "maxp":
                    return MaximumProfileTable.FromBytes;
                case "hmtx":
                    return LoadHmtxTable;
                case "OS/2":
                    return OS2MetricsTable.FromBytes;
                case "name":
                    return NamingTable.FromBytes;
                case "cmap":
                    return CharacterMappingTable.FromBytes;
                default:
                    return null;
            }
        }

        private HorizontalMetricsTable LoadHmtxTable(byte[] arr, int offset, uint len)
        {
            return HorizontalMetricsTable.FromBytes(arr, offset, MaximumProfile.GlyphCount, HorizontalHeader.HmtxHMetricCount);
        }

        /// <summary>
        /// Return the contents of the table with the given index record, from a cached copy of the data if available.
        /// </summary>
        /// <param name="indexRecord">The index record for the table to load.</param>
        /// <returns>A <see cref="Table" /> implementation, or <c>null</c> if the table cannot be loaded.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is null.</exception>
        public Table GetTableData(TableIndexRecord indexRecord)
        {
            if (indexRecord is null)
            {
                throw new ArgumentNullException(nameof(indexRecord));
            }
            if (indexRecord.Data != null)
            {
                return indexRecord.Data;
            }
            if (indexRecord.LoadingMethod == null)
            {
                return null;
            }

            byte[] rawTable = new byte[indexRecord.Length];
            _accessor.ReadArray(indexRecord.Offset.Value, rawTable, 0, (int)indexRecord.Length);
            return indexRecord.LoadingMethod(rawTable, 0, indexRecord.Length);
        }

        /// <summary>
        /// Get the contents of the table with the given tag, if it exists.
        /// </summary>
        /// <param name="t">The tag of the table to attempt to load.</param>
        /// <returns>A <see cref="Table" /> implementation, or <c>null</c> if a table with the given tag does not exist or cannot be loaded.</returns>
        public Table GetTableData(Tag t)
        {
            if (!TableIndex.ContainsKey(t.Value))
            {
                return null;
            }
            TableIndexRecord indexEntry = TableIndex[t.Value];
            return GetTableData(indexEntry);
        }
    }
}
