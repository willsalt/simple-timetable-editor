using System;

namespace Unicorn.FontTools.OpenType
{
    [Flags]
    public enum OS2StyleFlags
    {
        Italic = 1,
        Underscore = 2,
        Negative = 4,
        Outlined = 8,
        Strikeout = 16,
        Bold = 32,
        Regular = 64,
        UseOS2LineGapMetrics = 128,
        ConsistentNamingSceheme = 256,
        Oblique = 512,
    }
}
