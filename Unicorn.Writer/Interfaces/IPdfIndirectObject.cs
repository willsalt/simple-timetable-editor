using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Interfaces
{
    public interface IPdfIndirectObject
    {
        int ObjectId { get; }

        int Generation { get; }

        PdfReference GetReference();
    }
}
