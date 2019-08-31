using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Unicorn.Writer.Interfaces
{
    public interface IPdfCrossRefTable
    {
        int ClaimSlot();

        void SetSlot(IPdfIndirectObject value, int offset);

        int WriteTo(Stream stream);
    }
}
