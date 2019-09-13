using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    public abstract class PdfPageTreeItem : PdfIndirectObject
    {
        public PdfPageTreeNode Parent { get; }

        protected PdfPageTreeItem(int objectId, int generation, PdfPageTreeNode parent) : base(objectId, generation)
        {
            Parent = parent;
        }
    }
}
