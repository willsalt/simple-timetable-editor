using System;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The OS/2 table contains 16 bytes (split into 4 unsigned 32-bit integers) which are defined as a bitfield describing which Unicode blocks the font supports.
    /// This enum contains the second 8 bytes of those bits.  Note that according to the OpenType standard the first integer is defined as the lower 32 bits, so
    /// although OpenType files are bigendian, this value is not stored as a bigendian unsigned long.  Not all Unicode blocks are covered.  The highest 7 bits are 
    /// reserved and should be set to zero, hence this type not being unsigned.
    /// </summary>
    [Flags]
    public enum UpperUnicodeRangeFlags : long
    {
        /// <summary>
        /// Block FE20-FE2F.
        /// </summary>
        CombiningHalfMarks = 0x1L,

        /// <summary>
        /// Block FE10-FE1F.
        /// </summary>
        VerticalForms = 0x2L,

        /// <summary>
        /// Block FE50-FE6F.
        /// </summary>
        SmallFormVariants = 0x4L,

        /// <summary>
        /// Block FE70-FEFF.
        /// </summary>
        ArabicPresentationFormsB = 0x8L,

        /// <summary>
        /// Halfwidth And Fullwidth Forms - block FF00-FFEF.
        /// </summary>
        HalfAndFulLWidthForms = 0x10L,

        /// <summary>
        /// Block FFF0-FFFF.
        /// </summary>
        Specials = 0x20L,

        /// <summary>
        /// Block 0F00-0FFF.
        /// </summary>
        Tibetan = 0x40L,

        /// <summary>
        /// Block 0700-074F.
        /// </summary>
        Syriac = 0x80L,

        /// <summary>
        /// Block 0780-07BF.
        /// </summary>
        Thaana = 0x100L,

        /// <summary>
        /// Block 0D80-0DFF.
        /// </summary>
        Sinhala = 0x200L,

        /// <summary>
        /// Block 1000-109F.
        /// </summary>
        Myanmar = 0x400L,

        /// <summary>
        /// Block 1200-137F.
        /// </summary>
        Ethiopic = 0x800L,

        /// <summary>
        /// Block 13A0-13FF.
        /// </summary>
        Cherokee = 0x1000L,

        /// <summary>
        /// Block 1400-167F.
        /// </summary>
        UnifiedCanadianAboriginalSyllabics = 0x2000L,

        /// <summary>
        /// Block 1680-169F.
        /// </summary>
        Ogham = 0x4000L,

        /// <summary>
        /// Block 16A0-16FF.
        /// </summary>
        Runic = 0x8000L,

        /// <summary>
        /// Block 1780-17FF.  Does not include Khmer Symbols.
        /// </summary>
        Khmer = 0x1_0000L,

        /// <summary>
        /// Block 1800-18AF.
        /// </summary>
        Mongolian = 0x2_0000L,

        /// <summary>
        /// Braille Patterns - block 2800-28FF.
        /// </summary>
        Braille = 0x4_0000L,

        /// <summary>
        /// Block A000-A48F.
        /// </summary>
        YiSyllables = 0x8_0000L,

        /// <summary>
        /// Block 1700-171F.
        /// </summary>
        Tagalog = 0x10_0000L,

        /// <summary>
        /// Block 10300-1032F.
        /// </summary>
        OldItalic = 0x20_0000L,

        /// <summary>
        /// Block 10330-1034F.
        /// </summary>
        Gothic = 0x40_0000L,

        /// <summary>
        /// Block 10400-1044F.
        /// </summary>
        Deseret = 0x80_0000L,

        /// <summary>
        /// Byzantine Musical Symbols - block 1D000-1D0FF.  Don't ask why this block is included but "Musical Symbols" isn't.
        /// </summary>
        ByzantineMusic = 0x100_0000L,

        /// <summary>
        /// Block 1D400-1D7FF.
        /// </summary>
        MathsAlphanumericalSymbols = 0x200_0000L,

        /// <summary>
        /// Plane 15 Private Use - block F0000-FFFFD.
        /// </summary>
        PrivatePlane15 = 0x400_0000L,

        /// <summary>
        /// Block FE00-FE0F.
        /// </summary>
        VariationSelectors = 0x800_0000L,

        /// <summary>
        /// Block E0000-E007F.
        /// </summary>
        Tags = 0x1000_0000L,

        /// <summary>
        /// Block 1900-194F.
        /// </summary>
        Limbu = 0x2000_0000L,

        /// <summary>
        /// Block 1950-197F.
        /// </summary>
        TaiLe = 0x4000_0000L,

        /// <summary>
        /// Block 1980-19DF.
        /// </summary>
        NewTaiLue = 0x8000_0000L,

        /// <summary>
        /// Block 1A00-1A1F.
        /// </summary>
        Buginese = 0x1_0000_0000L,

        /// <summary>
        /// Block 2C00-2C5F.
        /// </summary>
        Glagolitic = 0x2_0000_0000L,

        /// <summary>
        /// Block 2D30-2D7F.
        /// </summary>
        Tifinagh = 0x4_0000_0000L,

        /// <summary>
        /// Block 4DC0-4DFF.
        /// </summary>
        YijingHexagrams = 0x8_0000_0000L,

        /// <summary>
        /// Block A800-A82F.
        /// </summary>
        SylotiNagri = 0x10_0000_0000L,

        /// <summary>
        /// Block 10000-1007F.  Linear B ideograms not included.
        /// </summary>
        LinearBSyllables = 0x20_0000_0000L,

        /// <summary>
        /// Block 10140-1018F.
        /// </summary>
        AncientGreekNumbers = 0x40_0000_0000L,

        /// <summary>
        /// Block 10380-1039F.
        /// </summary>
        Ugaritic = 0x80_0000_0000L,

        /// <summary>
        /// Block 103A0-103DF.
        /// </summary>
        OldPersian = 0x100_0000_0000L,

        /// <summary>
        /// Block 10450-1047F.
        /// </summary>
        Shavian = 0x200_0000_0000L,

        /// <summary>
        /// Block 10480-104AF.
        /// </summary>
        Osmanya = 0x400_0000_0000L,

        /// <summary>
        /// Block 10800-1083F.
        /// </summary>
        CypriotSyllables = 0x800_0000_0000L,

        /// <summary>
        /// Block 10A00-10A5F.
        /// </summary>
        Kharoshthi = 0x1000_0000_0000L,

        /// <summary>
        /// Block 1D300-1D35F.
        /// </summary>
        TaiXuanJingSymbols = 0x2000_0000_0000L,

        /// <summary>
        /// Block 12000-123FF.  Does not include numbers and punctuation.
        /// </summary>
        Cuneiform = 0x4000_0000_0000L,

        /// <summary>
        /// Block 1D360-1D37F.
        /// </summary>
        CountingRodNumbers = 0x8000_0000_0000L,

        /// <summary>
        /// Block 1B80-1BBF.
        /// </summary>
        Sundanese = 0x1_0000_0000_0000L,

        /// <summary>
        /// Block 1C00-1C4F.
        /// </summary>
        Lepcha = 0x2_0000_0000_0000L,

        /// <summary>
        /// Block 1C50-1C7F.
        /// </summary>
        OlChiki = 0x4_0000_0000_0000L,

        /// <summary>
        /// Block A880-A8DF.
        /// </summary>
        Saurashtra = 0x8_0000_0000_0000L,

        /// <summary>
        /// Block A900-A92F.
        /// </summary>
        KayahLi = 0x10_0000_0000_0000L,

        /// <summary>
        /// Block A930-A95F.
        /// </summary>
        Rejang = 0x20_0000_0000_0000L,

        /// <summary>
        /// Block AA00-AA5F.
        /// </summary>
        Cham = 0x40_0000_0000_0000L,

        /// <summary>
        /// Block 10190-101CF.
        /// </summary>
        AncientSymbols = 0x80_0000_0000_0000L,

        /// <summary>
        /// Block 101D0-101FF.
        /// </summary>
        PhaistosDisc = 0x100_0000_0000_0000L,

        /// <summary>
        /// Block 102A0-102DF.
        /// </summary>
        Carian = 0x200_0000_0000_0000L,

        /// <summary>
        /// Domino Tiles - block 1F030-1F09F.
        /// </summary>
        Dominos = 0x400_0000_0000_0000L
    }
}
