namespace Timetabler.PdfExport.Interfaces
{
    public interface IFontConfigurationProvider
    {
        string BasePath { get; }

        string SerifRomanFace { get; }

        string SerifItalicFace { get; }

        string SerifBoldFace { get; }

        string SerifBoldItalicFace { get; }

        string SansRomanFace { get; }

        string SansBoldFace { get; }
    }
}
