using System.IO;

namespace Unicorn.Writer.Interfaces
{
    public interface IPdfPrimitiveObject
    {
        int WriteTo(Stream stream);
    }
}
