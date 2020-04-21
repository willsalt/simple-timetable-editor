using System;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// A table index record.  An OpenType file consists of an <see cref="OffsetTable" />, a sequence of <see cref="TableIndexRecord" /> entries whose length 
    /// corresponds to the number of tables given in the offset table, followed by the data tables themselves.
    /// </summary>
    public class TableIndexRecord
    {
        /// <summary>
        /// The table's tag.
        /// </summary>
        public Tag TableTag { get; private set; }

        /// <summary>
        /// The table checksum.
        /// </summary>
        public uint Checksum { get; private set; }

        /// <summary>
        /// The address of the start of this table, as a byte offset from the start of the file.
        /// </summary>
        public uint? Offset { get; private set; }

        /// <summary>
        /// The length of the table, in bytes.
        /// </summary>
        public uint Length { get; private set; }

        /// <summary>
        /// The content of the table, if it has been loaded into memory.
        /// </summary>
        public Table Data { get; set; }

        /// <summary>
        /// A method that can load the table into memory from an array of bytes.
        /// </summary>
        public TableLoadingMethod LoadingMethod { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tag">The value of the <see cref="TableTag" /> property.</param>
        /// <param name="checksum">The value of the <see cref="Checksum" /> property.</param>
        /// <param name="offset">The value of the <see cref="Offset"/> property.</param>
        /// <param name="len">The value of the <see cref="Length"/> property.</param>
        /// <param name="loader">The loading method, which can convert an array of bytes to a <see cref="Table" /> object.</param>
        public TableIndexRecord(Tag tag, uint checksum, uint? offset, uint len, TableLoadingMethod loader)
        {
            TableTag = tag;
            Checksum = checksum;
            Offset = offset;
            Length = len;
            LoadingMethod = loader;
        }
    }
}
