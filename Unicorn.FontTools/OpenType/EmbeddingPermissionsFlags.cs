using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.FontTools.OpenType
{
    [Flags]
    public enum EmbeddingPermissionsFlags
    {
        Installable = 0,
        Restricted = 2,
        Printing = 4,
        Editable = 8,
        NoSubsetting = 256,
        BitmapOnly = 512,
    }
}
