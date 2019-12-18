using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// A class which represents a PDF catalogue.  This is the root object of every PDF file, referenced from the trailer.
    /// </summary>
    public class PdfCatalogue : PdfIndirectObject
    {
        /// <summary>
        /// The root of the document page tree.
        /// </summary>
        public PdfPageTreeNode PageRoot { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pageRoot">The document page tree root node.</param>
        /// <param name="objectId">The indirect object ID of the catalogue.</param>
        /// <param name="generation">The generation number of the catalogue.  This defaults to zero and can effectively be ignored when creating a new document.</param>
        /// <exception cref="ArgumentNullException">Thrown if the pageRoot parameter is null.</exception>
        public PdfCatalogue(PdfPageTreeNode pageRoot, int objectId, int generation = 0) : base(objectId, generation)
        {
            PageRoot = pageRoot ?? throw new ArgumentNullException(nameof(pageRoot));
        }

        /// <summary>
        /// Write this object to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns></returns>
        public override int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, MakeDictionary().WriteTo, stream);
        }

        /// <summary>
        /// Convert this object to bytes and append them to a list.
        /// </summary>
        /// <param name="list">The list to append to.</param>
        /// <returns>The number of bytes appended.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list parameter is null.</exception>
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
