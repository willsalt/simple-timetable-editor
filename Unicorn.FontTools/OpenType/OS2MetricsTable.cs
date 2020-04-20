using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.FontTools.OpenType
{
    public class OS2MetricsTable : Table
    {
        public ushort Version { get; private set; }

        public short AverageCharWidth { get; private set; }

        public ushort WeightClass { get; private set; }

        public ushort WidthClass { get; private set; }

        public EmbeddingPermissionsFlags EmbeddingPermissions { get; private set; }

        public short SubscriptXSize { get; private set; }

        public short SubscriptYSize { get; private set; }

        public short SubscriptXOffset { get; private set; }

        public short SubscriptYOffset { get; private set; }

        public short SuperscriptXSize { get; private set; }

        public short SuperscriptYSize { get; private set; }

        public short SuperscriptXOffset { get; private set; }

        public short SuperscriptYOffset { get; private set; }

        public short StrikeoutSize { get; private set; }

        public short StrikeoutPosition { get; private set; }

        public IBMFamily IBMFontFamily { get; private set; }

        public PanoseFamily PanoseFontFamily { get; private set; }

        public uint UnicodeRange1 { get; private set; }

        public uint UnicodeRange2 { get; private set; }

        public uint UnicodeRange3 { get; private set; }

        public uint UnicodeRange4 { get; private set; }

        public Tag VendorId { get; private set; }

        public OS2StyleFlags FontSelection { get; private set; }

        public ushort MinCodePoint { get; private set; }

        public ushort MaxCodePoint { get; private set; }

        public short Ascender { get; private set; }

        public short Descender { get; private set; }

        public short LineGap { get; private set; }

        public ushort WindowsAscender { get; private set; }

        public ushort WindowsDescender { get; private set; }

        public SupportedCodePageFlags CodePages { get; private set; }

        public short Height { get; private set; }

        public short CapHeight { get; private set; }

        public ushort DefaultChar { get; private set; }

        public ushort BreakChar { get; private set; }

        public ushort MaxContext { get; private set; }

        public ushort LowerOpticalPointSize { get; private set; }

        public ushort UpperOpticalPointSize { get; private set; }
    }
}
