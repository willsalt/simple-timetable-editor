namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The offset table, or main header table for an OpenType font.
    /// </summary>
    public class OffsetTable
    {
        /// <summary>
        /// The kind of font.
        /// </summary>
        public FontKind FontKind { get; private set; }

        /// <summary>
        /// The number of tables that the font consists of.
        /// </summary>
        public ushort TableCount { get; private set; }

        /// <summary>
        /// The SearchRange field (derived from the number of tables).
        /// </summary>
        public ushort SearchRange { get; private set; }

        /// <summary>
        /// The EntrySelector field: the minimum number of bits needed to store the number of tables.
        /// </summary>
        public ushort EntrySelector { get; private set; }

        /// <summary>
        /// The RangeShift field (derived from the number of tables).
        /// </summary>
        public ushort RangeShift { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kind">Value of the <see cref="FontKind" /> property.</param>
        /// <param name="count">Value of the <see cref="TableCount" /> property.</param>
        /// <param name="searchRange">Value of the <see cref="SearchRange"/> property.</param>
        /// <param name="entrySelector">Value of the <see cref="EntrySelector" /> property.</param>
        /// <param name="rangeShift">Value of the <see cref="RangeShift" /> property.</param>
        public OffsetTable(FontKind kind, ushort count, ushort searchRange, ushort entrySelector, ushort rangeShift)
        {
            FontKind = kind;
            TableCount = count;
            SearchRange = searchRange;
            EntrySelector = entrySelector;
            RangeShift = rangeShift;
        }
    }
}
