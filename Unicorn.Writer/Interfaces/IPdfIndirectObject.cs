using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Writer.Interfaces
{
    public interface IPdfIndirectObject
    {
        int ObjectId { get; }

        int Generation { get; }

        byte[] GetReference();

        int ReferenceLength { get; }
    }
}
