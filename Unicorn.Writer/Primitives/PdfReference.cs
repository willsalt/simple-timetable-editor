using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfReference : PdfSimpleObject, IEquatable<PdfReference>
    {
        public IPdfIndirectObject Value { get; }
        
        public PdfReference(IPdfIndirectObject referent)
        {
            if (referent == null)
            {
                throw new ArgumentNullException(nameof(referent));
            }
            Value = referent;
        }

        protected override byte[] FormatBytes()
        {
            return Encoding.ASCII.GetBytes($"{Value.ObjectId} {Value.Generation} R\xa");
        }

        public bool Equals(PdfReference other)
        {
            if (other == null)
            {
                return false;
            }
            return Value.ObjectId == other.Value.ObjectId && Value.Generation == other.Value.Generation;
        }

        public override bool Equals(object obj)
        {
            PdfReference other = obj as PdfReference;
            if (other == null)
            {
                return false;
            }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.ObjectId.GetHashCode() ^ Value.Generation.GetHashCode();
        }

        public static bool operator ==(PdfReference a, PdfReference b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a == null || b == null)
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(PdfReference a, PdfReference b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            if (a == null || b == null)
            {
                return true;
            }
            return !a.Equals(b);
        }
    }
}
