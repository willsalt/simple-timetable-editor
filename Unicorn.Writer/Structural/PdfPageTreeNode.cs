using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    public class PdfPageTreeNode : PdfPageTreeItem
    {
        public IList<PdfPageTreeItem> Kids { get; }

        public PdfPageTreeNode(PdfPageTreeNode parent, int objectId, int generation = 0) : base(parent, objectId, generation)
        {
            Kids = new List<PdfPageTreeItem>();
        }

        public void Add(PdfPageTreeItem child)
        {
            Kids.Add(child);
        }

        public override int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, MakeDictionary().WriteTo, stream);
        }

        public override int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            return Write(WriteToList, MakeDictionary().WriteTo, list);
        }

        private PdfDictionary MakeDictionary()
        {
            PdfDictionary dictionary = new PdfDictionary();
            dictionary.Add(CommonPdfNames.Type, CommonPdfNames.Pages);
            dictionary.Add(CommonPdfNames.Count, new PdfInteger(Kids.Count));
            if (Parent != null)
            {
                dictionary.Add(CommonPdfNames.Parent, Parent.GetReference());
            }
            dictionary.Add(CommonPdfNames.Kids, new PdfArray(Kids.Select(item => (IPdfPrimitiveObject)item.GetReference())));
            return dictionary;
        }
    }
}
