using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.CoreTypes;

namespace Unicorn.FontTools.OpenType.Extensions
{
    public static class OS2StyleFlagsExtensions
    {
        public static FontDescriptorFlags ToFontDescriptorFlags(this OS2StyleFlags flags, bool isSymbolic, bool isMonospaced)
        {
            FontDescriptorFlags output = isSymbolic ? FontDescriptorFlags.Symbolic : FontDescriptorFlags.Nonsymbolic;
            if (isMonospaced)
            {
                output |= FontDescriptorFlags.FixedPitch;
            }
            if ((flags & OS2StyleFlags.Italic) == OS2StyleFlags.Italic || (flags & OS2StyleFlags.Oblique) == OS2StyleFlags.Oblique)
            {
                output |= FontDescriptorFlags.Italic;
            }
            return output;
        }
    }
}
