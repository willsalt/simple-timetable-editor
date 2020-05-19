using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// A flags enumeration which describes the style of a font.
    /// </summary>
    [Flags]
    public enum UniFontStyles
    {
        /// <summary>
        /// Regular roman face
        /// </summary>
        Regular = 0,

        /// <summary>
        /// Bold face
        /// </summary>
        Bold = 1,

        /// <summary>
        /// Italic face
        /// </summary>
        Italic = 2,

        /// <summary>
        /// Underlined face
        /// </summary>
        Underline = 4,

        /// <summary>
        /// Stricken-through face
        /// </summary>
        Strikethrough = 8
    }
}
