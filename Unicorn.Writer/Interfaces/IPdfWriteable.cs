using System.IO;

namespace Unicorn.Writer.Interfaces
{
    public interface IPdfWriteable
    {
        int WriteTo(Stream stream);
    }
}
