namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// An individual entry in the 'name' table.
    /// </summary>
    public class NameRecord
    {
        /// <summary>
        /// The OS platform for this name.
        /// </summary>
        public PlatformId PlatformId { get; private set; }

        /// <summary>
        /// The byte encoding for this name (values are platform-specific).
        /// </summary>
        public ushort EncodingId { get; private set; }

        /// <summary>
        /// The language ID for this name.  Values less than 0x8000 are platform-specific.  Values greater than 0x8000 indicate that this name is from a Version 1
        /// name table and the language is defined using a language tag record in the table.
        /// </summary>
        public ushort LanguageId { get; private set; }

        /// <summary>
        /// The kind of name stored in this record.  Values greater than 0xff are font-specific.
        /// </summary>
        public NameField NameId { get; private set; }

        /// <summary>
        /// The content of the name record, or a message if the content cannot be decoded.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">The value for the <see cref="PlatformId" /> property.</param>
        /// <param name="encoding">The value for the <see cref="EncodingId" /> property.</param>
        /// <param name="lang">The value for the <see cref="LanguageId" /> property.</param>
        /// <param name="nameId">The value for the <see cref="NameId" /> property.</param>
        /// <param name="content">The value for the <see cref="Content" /> property.</param>
        public NameRecord(PlatformId platform, ushort encoding, ushort lang, NameField nameId, string content)
        {
            PlatformId = platform;
            EncodingId = encoding;
            LanguageId = lang;
            NameId = nameId;
            Content = content;
        }
    }
}
