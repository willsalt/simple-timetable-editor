using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Writer.Structural
{
    public class PdfPage : PdfPageTreeItem
    {
        public PdfPage(int objectId, int generation, PdfPageTreeNode parent) : base(objectId, generation, parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }
        }
    }
}
