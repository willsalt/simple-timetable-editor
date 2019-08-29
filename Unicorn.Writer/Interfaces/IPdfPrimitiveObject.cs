using System.Collections.Generic;
using System.IO;

namespace Unicorn.Writer.Interfaces
{
    public interface IPdfPrimitiveObject
    {
        int ByteLength { get; }

        int WriteTo(Stream stream);

        int WriteTo(List<byte> bytes);
    }
}
