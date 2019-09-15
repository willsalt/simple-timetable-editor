using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    public class PdfCatalogue : PdfIndirectObject
    {
        public PdfPageTreeNode PageRoot { get; private set; }

        public PdfCatalogue(PdfPageTreeNode pageRoot, int objectId, int generation = 0) : base(objectId, generation)
        {
            PageRoot = pageRoot ?? throw new ArgumentNullException(nameof(pageRoot));
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
            PdfDictionary d = new PdfDictionary();
            d.Add(CommonPdfNames.Type, CommonPdfNames.Catalog);
            d.Add(CommonPdfNames.Pages, PageRoot.GetReference());
            return d;
        }
    }
}
