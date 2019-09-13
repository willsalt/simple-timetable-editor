using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    public class PdfCatalogue : IPdfIndirectObject
    {
        public int ObjectId { get; }

        public int Generation { get; }

        public PdfCatalogue(int objectId, int generation = 0)
        {
            ObjectId = objectId;
            Generation = generation;
        }

        public PdfReference GetReference()
        {
            throw new NotImplementedException();
        }

        public int WriteTo(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
