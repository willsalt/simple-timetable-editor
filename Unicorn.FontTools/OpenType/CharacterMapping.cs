using System.IO;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Class representing a mapping from character set code points to font glyph IDs.
    /// </summary>
    public abstract class CharacterMapping
    {
        /// <summary>
        /// The platform that this mapping applies to.
        /// </summary>
        public PlatformId Platform { get; }

        /// <summary>
        /// The character encoding that this mapping is for.
        /// </summary>
        public ushort Encoding { get; }

        /// <summary>
        /// The language to which this mapping applies, if any.  Only relevant where the <see cref="Platform" /> property is set to <see cref="PlatformId.Macintosh" />;
        /// should be zero otherwise.
        /// </summary>
        public ushort Language { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">The valeue for the <see cref="Platform" /> property.</param>
        /// <param name="encoding">The valeue for the <see cref="Encoding" /> property.</param>
        /// <param name="lang">The valeue for the <see cref="Language" /> property.</param>
        public CharacterMapping(PlatformId platform, ushort encoding, ushort lang)
        {
            Platform = platform;
            Encoding = encoding;
            Language = lang;
        }

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public abstract ushort MapCodePoint(byte codePoint);

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public abstract ushort MapCodePoint(ushort codePoint);

        /// <summary>
        /// Convert a code point to a glyph ID.
        /// </summary>
        /// <param name="codePoint">The code point to convert.</param>
        /// <returns>A glyph ID, or zero if the code point is not encoded.</returns>
        public abstract ushort MapCodePoint(uint codePoint);

        /// <summary>
        /// Dump the content of this mapping to a <see cref="TextWriter" />.
        /// </summary>
        /// <param name="writer">The writer to dump to.</param>
        public abstract void Dump(TextWriter writer);
    }
}
