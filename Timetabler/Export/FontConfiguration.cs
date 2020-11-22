using Timetabler.PdfExport.Interfaces;

namespace Timetabler.Export
{
    internal class FontConfiguration : IFontConfigurationProvider
    {
        public string BasePath => Properties.Settings.Default.FontFolder;

        public string SerifRomanFace => Properties.Settings.Default.SerifRomanFace;

        public string SerifItalicFace => Properties.Settings.Default.SerifItalicFace;

        public string SerifBoldFace => Properties.Settings.Default.SerifBoldFace;

        public string SerifBoldItalicFace => Properties.Settings.Default.SerifBoldItalicFace;

        public string SansRomanFace => Properties.Settings.Default.SansRomanFace;

        public string SansBoldFace => Properties.Settings.Default.SansBoldFace;

        internal static FontConfiguration Default { get; } = new FontConfiguration();

        private FontConfiguration() { }
    }
}
