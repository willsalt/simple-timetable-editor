using System;

namespace Unicorn.FontTools.OpenType
{

#pragma warning disable CA1028 // Enum Storage should be Int32 - we are using all 64 bits here!

    /// <summary>
    /// The OS/2 table contains 16 bytes (split into 4 unsigned 32-bit integers) which are defined as a bitfield describing which Unicode blocks the font supports.
    /// This enum contains the first 8 bytes of those bits.  Note that according to the OpenType standard the first integer is defined as the lower 32 bits, so
    /// although OpenType files are bigendian, this value is not stored as a bigendian unsigned long.  Not all Unicode blocks are covered.
    /// </summary>
    [Flags]
    public enum LowerUnicodeRangeFlags : ulong
    {
        /// <summary>
        /// Block 0000-007F.
        /// </summary>
        BasicLatin = 0x1UL,

        /// <summary>
        /// Block 0080-00FF.
        /// </summary>
        Latin1Supplement = 0x2UL,

        /// <summary>
        /// Block 0100-017F.
        /// </summary>
        LatinExtendedA = 0x4UL,

        /// <summary>
        /// Block 0180-024F.
        /// </summary>
        LatinExtendedB = 0x8UL,

        /// <summary>
        /// Block 0250-02AF.
        /// </summary>
        IPAExtensions = 0x10UL,

        /// <summary>
        /// Spacing Modifier Letters - block 02B0-02FF.
        /// </summary>
        SpacingModifiers = 0x20UL,

        /// <summary>
        /// Block 0300-036F.
        /// </summary>
        CombiningDiacriticalMarks = 0x40UL,

        /// <summary>
        /// Block 0370-03FF.
        /// </summary>
        GreekAndCoptic = 0x80UL,

        /// <summary>
        /// Block 2C80-2CFF (note out of order comoared with other flags).
        /// </summary>
        Coptic = 0x100UL,

        /// <summary>
        /// Block 0400-04FF
        /// </summary>
        Cyrillic = 0x200UL,

        /// <summary>
        /// Block 0530-058F.
        /// </summary>
        Armenian = 0x400UL,

        /// <summary>
        /// Block 0590-05FF.
        /// </summary>
        Hebrew = 0x800UL,

        /// <summary>
        /// Block A500-A63F (note out of order compared with other flags).
        /// </summary>
        Vai = 0x1000UL,

        /// <summary>
        /// Block 0600-06FF.
        /// </summary>
        Arabic = 0x2000UL,

        /// <summary>
        /// Block 07C0-07FF.
        /// </summary>
        NKo = 0x4000UL,

        /// <summary>
        /// Block 0900-097F.
        /// </summary>
        Devanagari = 0x8000UL,

        /// <summary>
        /// Block 0980-09FF.
        /// </summary>
        Bengali = 0x1_0000UL,

        /// <summary>
        /// Block 0A00-0A7F.
        /// </summary>
        Gurmukhi = 0x2_0000UL,

        /// <summary>
        /// Block 0A80-0AFF.
        /// </summary>
        Gujurati = 0x4_0000UL,

        /// <summary>
        /// Block 0B00-0B7F.
        /// </summary>
        Oriya = 0x8_0000UL,

        /// <summary>
        /// Block 0B80-0BFF.
        /// </summary>
        Tamil = 0x10_0000UL,

        /// <summary>
        /// Block 0C00-0C7F.
        /// </summary>
        Telugu = 0x20_0000UL,

        /// <summary>
        /// Block 0C80-0CFF.
        /// </summary>
        Kannada = 0x40_0000UL,

        /// <summary>
        /// Block 0D00-0D7F.
        /// </summary>
        Malayalam = 0x80_0000UL,

        /// <summary>
        /// Block 0E00-0E7F.
        /// </summary>
        Thai = 0x100_0000UL,

        /// <summary>
        /// Block 0E80-0EFF.
        /// </summary>
        Lao = 0x200_0000UL,

        /// <summary>
        /// Block 10A0-10FF.
        /// </summary>
        Georgian = 0x400_0000UL,

        /// <summary>
        /// Block 1B00-1B7F.
        /// </summary>
        Balinese = 0x800_0000UL,

        /// <summary>
        /// Block 1100-11FF.
        /// </summary>
        HangulJamo = 0x1000_0000UL,

        /// <summary>
        /// Block 1E00-1EFF.
        /// </summary>
        LatinExtendedAdditional = 0x2000_0000UL,

        /// <summary>
        /// Block 1F00-1FFF.
        /// </summary>
        GreekExtended = 0x4000_0000UL,

        /// <summary>
        /// Block 2000-206F.
        /// </summary>
        GeneralPunctuation = 0x8000_0000UL,

        /// <summary>
        /// Block 2070-209F.
        /// </summary>
        SuperscriptsSubscripts = 0x1_0000_0000UL,

        /// <summary>
        /// Block 20A0-20CF.
        /// </summary>
        Currency = 0x2_0000_0000UL,

        /// <summary>
        /// Combining Diacritical Marks for Symbols - block 20D0-20FF.
        /// </summary>
        CombiningDiacriticalsForSymbols = 0x4_0000_0000UL,

        /// <summary>
        /// Block 2100-214F.
        /// </summary>
        LetterlikeSymbols = 0x8_0000_0000UL,

        /// <summary>
        /// Block 2150-218F.
        /// </summary>
        NumberForms = 0x10_0000_0000UL,

        /// <summary>
        /// Block 2190-21FF.
        /// </summary>
        Arrows = 0x20_0000_0000UL,

        /// <summary>
        /// Mathematical Operators - block 2200-22FF.
        /// </summary>
        MathsOperators = 0x40_0000_0000UL,

        /// <summary>
        /// Block 2300-23FF.
        /// </summary>
        MiscTechnical = 0x80_0000_0000UL,

        /// <summary>
        /// Block 2400-243F.
        /// </summary>
        ControlPictures = 0x100_0000_0000UL,

        /// <summary>
        /// Block 2440-245F.
        /// </summary>
        OCR = 0x200_0000_0000UL,

        /// <summary>
        /// Block 2460-24FF.
        /// </summary>
        EnclosedAlphanumerics = 0x400_0000_0000UL,
        
        /// <summary>
        /// Block 2500-257F.
        /// </summary>
        BoxDrawing = 0x800_0000_0000UL,

        /// <summary>
        /// Block 2580-259F.
        /// </summary>
        BlockElements = 0x1000_0000_0000UL,

        /// <summary>
        /// Block 25A0-25FF.
        /// </summary>
        GeometricShapes = 0x2000_0000_0000UL,

        /// <summary>
        /// Block 2600-26FF.
        /// </summary>
        MiscSymbols = 0x4000_0000_0000UL,

        /// <summary>
        /// Block 2700-27BF.
        /// </summary>
        Dingbats = 0x8000_0000_0000UL,

        /// <summary>
        /// CJK Symbols and Punctuation - block 3000-303F.
        /// </summary>
        CJKSymbols = 0x1_0000_0000_0000UL,

        /// <summary>
        /// Block 3040-309F.
        /// </summary>
        Hiragana = 0x2_0000_0000_0000UL,

        /// <summary>
        /// Block 30A0-30FF.
        /// </summary>
        Katakana = 0x4_0000_0000_0000UL,

        /// <summary>
        /// Block 3100-312F.
        /// </summary>
        Bopomofo = 0x8_0000_0000_0000UL,

        /// <summary>
        /// Block 3130-318F.
        /// </summary>
        HangulCompatiblityJamo = 0x10_0000_0000_0000UL,

        /// <summary>
        /// Phags-pa - block A840-A87F (note out of order).
        /// </summary>
        PhagsPa = 0x20_0000_0000_0000UL,

        /// <summary>
        /// Enclosed CJK Letters and Months - block 3200-32FF.
        /// </summary>
        EnclosedCJKLetters = 0x40_0000_0000_0000UL,

        /// <summary>
        /// Block 3300-33FF.
        /// </summary>
        CJKCompatibility = 0x80_0000_0000_0000UL,

        /// <summary>
        /// Block AC00-D7AF.
        /// </summary>
        HangulSyllables = 0x100_0000_0000_0000UL,

        /// <summary>
        /// Font provides at least one character in the range 10000-10FFFF.  A number of other bits imply this bit must be set.
        /// </summary>
        NonPlane0 = 0x200_0000_0000_0000UL,

        /// <summary>
        /// Block 10900-1091F (note out of order).
        /// </summary>
        Phoenician = 0x400_0000_0000_0000UL,

        /// <summary>
        /// Block 4E00-9FFF.
        /// </summary>
        CJKUnifiedIdeographs = 0x800_0000_0000_0000UL,

        /// <summary>
        /// Plane 0 Private Use Area - block E000-F8FF.
        /// </summary>
        PrivateUseArea0 = 0x1000_0000_0000_0000UL,

        /// <summary>
        /// Block 31C0-31EF (note out of order).
        /// </summary>
        CJKStrokes = 0x2000_0000_0000_0000UL,

        /// <summary>
        /// Block FB00-FB4F.
        /// </summary>
        AlphabeticPresentationForms = 0x4000_0000_0000_0000UL,

        /// <summary>
        /// Block FB50-FDFF.
        /// </summary>
        ArabicPresentationFormsA = 0x8000_0000_0000_0000UL,
    }

#pragma warning restore CA1028 // Enum Storage should be Int32

}
