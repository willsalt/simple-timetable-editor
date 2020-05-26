using System.Collections.Generic;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Interfaces
{
    public interface IPdfFilterEncoder
    {
        PdfName FilterName { get; }

        IList<byte> Encode(IEnumerable<byte> data);
    }
}
