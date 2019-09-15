using System;
using Unicorn.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    public static class UniSizeExtensions
    {
        private static Lazy<PdfReal> _zero = new Lazy<PdfReal>(() => new PdfReal(0));

        public static PdfRectangle ToPdfRectangle(this UniSize size)
        {
            if (size == null)
            {
                throw new NullReferenceException();
            }
            return new PdfRectangle(_zero.Value, _zero.Value, new PdfReal(size.Width), new PdfReal(size.Height));
        }
    }
}
