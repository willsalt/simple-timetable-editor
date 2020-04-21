using System;
using System.IO;
using Unicorn.FontTools.OpenType.Extensions;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The content of the "maxp" table, which describes the size of the resources used by this font.
    /// </summary>
    public class MaximumProfileTable : Table
    {
        /// <summary>
        /// The type of font, derived from the maxp table version (if it doesn't agree with the top-level font type then there is a problem!).  CFF fonts only 
        /// populate one field in this table, named <see cref="GlyphCount" /> here.  TrueType fonts populate all fields, so if this field equals 
        /// <see cref="FontKind.TrueType"/> the consuming code can assume that all of the <see cref="Nullable{T}" /> properties will have values.
        /// </summary>
        public FontKind Kind { get; private set; }

        /// <summary>
        /// The number of glyphs in the font.
        /// </summary>
        public ushort GlyphCount { get; private set; }

        /// <summary>
        /// The maximum number of points in any non-composite glyph.
        /// </summary>
        public ushort? MaxPoints { get; private set; }

        /// <summary>
        /// The maximum number of contours in any non-composite glyph.
        /// </summary>
        public ushort? MaxContours { get; private set; }

        /// <summary>
        /// The maximum number of points in any composite glyph (if there are any).
        /// </summary>
        public ushort? MaxCompositePoints { get; private set; }

        /// <summary>
        /// The maximum number of contours in any composite glyph (if there are any).
        /// </summary>
        public ushort? MaxCompositeContours { get; private set; }

        /// <summary>
        /// The maximum number of zones used - 2 if this font uses the Twilight Zone, 1 otherwise.
        /// </summary>
        public ushort? MaxZones { get; private set; }

        /// <summary>
        /// The maximum number of points in the Twilight Zone of any glyph.  If this is non-zero then <see cref="MaxZones" /> must be 2.
        /// </summary>
        public ushort? MaxTwilightZonePoints { get; private set; }

        /// <summary>
        /// The maximum number of storage area locations used.
        /// </summary>
        public ushort? MaxStorage { get; private set; }

        /// <summary>
        /// The number of function definitions (should be 1 greater than the largest function definition number).
        /// </summary>
        public ushort? MaxFunctionDefs { get; private set; }

        /// <summary>
        /// The number of instruction definitions.
        /// </summary>
        public ushort? MaxInstructionDefs { get; private set; }

        /// <summary>
        /// The maximum stack depth reached by any set of instructions (font program, CVT program or glyph instructions).
        /// </summary>
        public ushort? MaxStackElements { get; private set; }

        /// <summary>
        /// The maximum byte count of the glyph instructions for an individual glyph.
        /// </summary>
        public ushort? MaxSizeOfInstructions { get; private set; }

        /// <summary>
        /// The maximum number of top-level components of any composite glyph.
        /// </summary>
        public ushort? MaxComponentElements { get; private set; }

        /// <summary>
        /// The maximum composite glyph recursion depth (1 if all composite glyphs consist entirely of simple components)/
        /// </summary>
        public ushort? MaxComponentDepth { get; private set; }

        /// <summary>
        /// Constructor for CFF fonts.
        /// </summary>
        /// <param name="glyphCount">The value of the <see cref="GlyphCount" /> property.</param>
        public MaximumProfileTable(ushort glyphCount) : base(new Tag("maxp"))
        {
            Kind = FontKind.Cff;
            GlyphCount = glyphCount;
        }

        /// <summary>
        /// Constructor for TrueType fonts.
        /// </summary>
        /// <param name="glyphCount">The value of the <see cref="GlyphCount" /> property.</param>
        /// <param name="maxPoints">The value of the <see cref="MaxPoints" /> property.</param>
        /// <param name="maxContours">The value of the <see cref="MaxContours" /> property.</param>
        /// <param name="maxCompoPoints">The value of the <see cref="MaxCompositePoints" /> property.</param>
        /// <param name="maxCompoContours">The value of the <see cref="MaxCompositeContours" /> property.</param>
        /// <param name="maxZones">The value of the <see cref="MaxZones" /> property.</param>
        /// <param name="maxTwilightPoints">The value of the <see cref="MaxTwilightZonePoints" /> property.</param>
        /// <param name="maxStorage">The value of the <see cref="MaxStorage" /> property.</param>
        /// <param name="maxFuncDefs">The value of the <see cref="MaxFunctionDefs" /> property.</param>
        /// <param name="maxInstructionDefs">The value of the <see cref="MaxInstructionDefs" /> property.</param>
        /// <param name="maxStack">The value of the <see cref="MaxStackElements" /> property.</param>
        /// <param name="maxInstructionSize">The value of the <see cref="MaxSizeOfInstructions" /> property.</param>
        /// <param name="maxElements">The value of the <see cref="MaxComponentElements" /> property.</param>
        /// <param name="maxDepth">The value of the <see cref="MaxComponentDepth" /> property.</param>
        public MaximumProfileTable(ushort glyphCount, ushort maxPoints, ushort maxContours, ushort maxCompoPoints, ushort maxCompoContours, ushort maxZones,
            ushort maxTwilightPoints, ushort maxStorage, ushort maxFuncDefs, ushort maxInstructionDefs, ushort maxStack, ushort maxInstructionSize, 
            ushort maxElements, ushort maxDepth)
            : this(glyphCount)
        {
            Kind = FontKind.TrueType;
            MaxPoints = maxPoints;
            MaxContours = maxContours;
            MaxCompositePoints = maxCompoPoints;
            MaxCompositeContours = maxCompoContours;
            MaxZones = maxZones;
            MaxTwilightZonePoints = maxTwilightPoints;
            MaxStorage = maxStorage;
            MaxFunctionDefs = maxFuncDefs;
            MaxInstructionDefs = maxInstructionDefs;
            MaxStackElements = maxStack;
            MaxSizeOfInstructions = maxInstructionSize;
            MaxComponentElements = maxElements;
            MaxComponentDepth = maxDepth;
        }

        /// <summary>
        /// Load a <see cref="MaximumProfileTable" /> from an array of bytes.
        /// </summary>
        /// <param name="arr">The table data.</param>
        /// <param name="offset">The location in the array of the first byte of the table data.</param>
        /// <param name="len">Table data length.</param>
        /// <returns>A <see cref="MaximumProfileTable" /> loaded from the array provided.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the array contains insufficient data or has an unrecognised version number.</exception>
        public static MaximumProfileTable FromBytes(byte[] arr, int offset, uint len)
        {
            int version = arr.ToInt(offset);
            if (version == 0x5000)
            {
                if (len < 6)
                {
                    throw new InvalidOperationException(Resources.OpenType_MaximumProfileTable_FromBytes_InsufficientDataError);
                }
                return new MaximumProfileTable(arr.ToUShort(offset + 4));
            }
            if (version == 0x10000)
            {
                if (len < 32)
                {
                    throw new InvalidOperationException(Resources.OpenType_MaximumProfileTable_FromBytes_InsufficientDataError);
                }
                return new MaximumProfileTable(
                    arr.ToUShort(offset + 4),
                    arr.ToUShort(offset + 6),
                    arr.ToUShort(offset + 8),
                    arr.ToUShort(offset + 10),
                    arr.ToUShort(offset + 12),
                    arr.ToUShort(offset + 14),
                    arr.ToUShort(offset + 16),
                    arr.ToUShort(offset + 18),
                    arr.ToUShort(offset + 20),
                    arr.ToUShort(offset + 22),
                    arr.ToUShort(offset + 24),
                    arr.ToUShort(offset + 26),
                    arr.ToUShort(offset + 28),
                    arr.ToUShort(offset + 30));
            }
            throw new InvalidOperationException($"Unknown maxp version number {version}.");
        }

        /// <summary>
        /// Dump the contents of this table to a <see cref="TextWriter" />.
        /// </summary>
        /// <param name="writer">The writer to dump the table data to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine("maxp table contents:");
            if (Kind == FontKind.Cff)
            {
                writer.WriteLine("Field      |  Value");
                writer.WriteLine("-----------|-------");
                writer.WriteLine($"GlyphCount | {GlyphCount,6}");
                return;
            }
            writer.WriteLine("Field                 |  Value");
            writer.WriteLine("----------------------|-------");
            writer.WriteLine($"GlyphCount            | {GlyphCount,6}");
            writer.WriteLine($"MaxPoints             | {MaxPoints,6}");
            writer.WriteLine($"MaxContours           | {MaxContours,6}");
            writer.WriteLine($"MaxCompositePoints    | {MaxCompositePoints,6}");
            writer.WriteLine($"MaxCompositeContours  | {MaxCompositeContours,6}");
            writer.WriteLine($"MaxZones              | {MaxZones,6}");
            writer.WriteLine($"MaxTwilightZonePoints | {MaxTwilightZonePoints,6}");
            writer.WriteLine($"MaxStorage            | {MaxStorage,6}");  
            writer.WriteLine($"MaxFunctionDefs       | {MaxFunctionDefs,6}");
            writer.WriteLine($"MaxInstructionDefs    | {MaxInstructionDefs,6}");
            writer.WriteLine($"MaxStackElements      | {MaxStackElements,6}");
            writer.WriteLine($"MaxSizeOfInstructions | {MaxSizeOfInstructions,6}");
            writer.WriteLine($"MaxComponentElements  | {MaxComponentElements,6}");
            writer.WriteLine($"MaxComponentDepth     | {MaxComponentDepth,6}");
        }
    }
}
