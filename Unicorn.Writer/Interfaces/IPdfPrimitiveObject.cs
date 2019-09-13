using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Interfaces
{
    public interface IPdfPrimitiveObject : IPdfWriteable
    {
        int ByteLength { get; }

        int WriteTo(List<byte> bytes);

        int WriteTo(PdfStream stream);
    }
}
