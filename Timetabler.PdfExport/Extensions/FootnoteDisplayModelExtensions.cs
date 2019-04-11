using System.Collections.Generic;
using Timetabler.Data.Display;
using Unicorn;
using Unicorn.Interfaces;

namespace Timetabler.PdfExport.Extensions
{
    internal static class FootnoteDisplayModelExtensions
    {
        internal static PositionedLine ToPositionedLine(this FootnoteDisplayModel footnote, IGraphicsContext context, IFontDescriptor symbolFont, IFontDescriptor definitionFont)
        {
            Word symbolWord = new Word(footnote.Symbol, symbolFont, context, 5); // FIXME that very naked-looing "5" should definitely not be hard-coded.
            List<Word> theWords = new List<Word> { symbolWord };
            theWords.AddRange(Word.MakeWords(footnote.Definition, definitionFont, context));
            return new PositionedLine(theWords);
        }
    }
}
