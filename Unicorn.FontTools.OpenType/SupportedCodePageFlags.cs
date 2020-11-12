using System;

namespace Unicorn.FontTools.OpenType
{

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
#pragma warning disable CA1028 // Enum Storage should be Int32 - suppressed because this enum needs a full 64 bits.

    /// <summary>
    /// Code pages supported by a given font.
    /// </summary>
    [Flags]
    [CLSCompliant(false)]
    public enum SupportedCodePageFlags : ulong
    {
        /// <summary>
        /// Code page 1252.
        /// </summary>
        Latin1              =                   0x1UL,

        /// <summary>
        /// Code page 1250.
        /// </summary>
        Latin2              =                   0x2UL,

        /// <summary>
        /// Code page 1251.
        /// </summary>
        Cyrillic            =                   0x4UL,

        /// <summary>
        /// Code page 1253.
        /// </summary>
        Greek               =                   0x8UL,

        /// <summary>
        /// Code page 1254.
        /// </summary>
        Turkish             =                  0x10UL,

        /// <summary>
        /// Code page 1255.
        /// </summary>
        Hebrew              =                  0x20UL,

        /// <summary>
        /// Code page 1256.
        /// </summary>
        Arabic              =                  0x40UL,

        /// <summary>
        /// Code page 1257.
        /// </summary>
        WindowsBaltic       =                  0x80UL,

        /// <summary>
        /// Code page 1258.
        /// </summary>
        Vietnamese          =                 0x100UL,

        /// <summary>
        /// Code page 874.
        /// </summary>
        Thai                =              0x1_0000UL,

        /// <summary>
        /// Code page 932.
        /// </summary>
        JIS                 =              0x2_0000UL,

        /// <summary>
        /// Code page 936.
        /// </summary>
        ChineseSimplified   =              0x4_0000UL,

        /// <summary>
        /// Code page 949.
        /// </summary>
        KoreanWansung       =              0x8_0000UL,

        /// <summary>
        /// Code page 950.
        /// </summary>
        ChineseTraditional  =             0x10_0000UL,

        /// <summary>
        /// Code page 1361.
        /// </summary>
        KoreanJohab         =             0x20_0000UL,

        /// <summary>
        /// Macintosh US Roman.
        /// </summary>
        MacRoman            =           0x2000_0000UL,

        /// <summary>
        /// OEM character set.
        /// </summary>
        OEM                 =           0x4000_0000UL,

        /// <summary>
        /// Symbol character set.
        /// </summary>
        Symbol              =           0x8000_0000UL,

        /// <summary>
        /// Code page 869.
        /// </summary>
        IBMGreek            =    0x1_0000_0000_0000UL,

        /// <summary>
        /// Code page 866.
        /// </summary>
        MSDosRussian        =    0x2_0000_0000_0000UL,

        /// <summary>
        /// Code page 865.
        /// </summary>
        MSDosNordic         =    0x4_0000_0000_0000UL,

        /// <summary>
        /// Code page 864.
        /// </summary>
        MSDosArabic         =    0x8_0000_0000_0000UL,

        /// <summary>
        /// Code page 863.
        /// </summary>
        MSDosCanadianFrench =   0x10_0000_0000_0000UL,

        /// <summary>
        /// Code page 862.
        /// </summary>
        MSDosHebrew         =   0x20_0000_0000_0000UL,

        /// <summary>
        /// Code page 861.
        /// </summary>
        MSDosIslensk        =   0x40_0000_0000_0000UL,

        /// <summary>
        /// Code page 860.
        /// </summary>
        MSDosPortuguese     =   0x80_0000_0000_0000UL,

        /// <summary>
        /// Code page 857.
        /// </summary>
        IBMTurkish          =  0x100_0000_0000_0000UL,

        /// <summary>
        /// Code page 855.
        /// </summary>
        IBMCyrillic         =  0x200_0000_0000_0000UL,

        /// <summary>
        /// Code page 852.
        /// </summary>
        MSDosLatin2         =  0x400_0000_0000_0000UL,

        /// <summary>
        /// Code page 775.
        /// </summary>
        MSDosBaltic         =  0x800_0000_0000_0000UL,

        /// <summary>
        /// Code page 737 (formerly 437G).
        /// </summary>
        Greek737            = 0x1000_0000_0000_0000UL,

        /// <summary>
        /// Code page 708.
        /// </summary>
        Arabic708           = 0x2000_0000_0000_0000UL,

        /// <summary>
        /// Code page 850.
        /// </summary>
        WELatin1            = 0x4000_0000_0000_0000UL,

        /// <summary>
        /// Code page 437.
        /// </summary>
        US                  = 0x8000_0000_0000_0000UL
    }

#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
#pragma warning restore CA1028 // Enum Storage should be Int32

}
