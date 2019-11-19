using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Writer.Primitives;
using Tests.Utility.Extensions;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Tests.Unit.TestHelpers
{
    public static class RandomExtensions
    {
        public static IPdfPrimitiveObject NextPdfPrimitive(this Random rnd)
        {
            int selector = rnd.Next(7);
            switch (selector)
            {
                case 0:
                default:
                    return rnd.NextPdfBoolean();
                case 1:
                    return rnd.NextPdfInteger();
                case 2:
                    return rnd.NextPdfName();
                case 3:
                    return rnd.NextPdfNull();
                case 4:
                    return rnd.NextPdfReal();
                case 5:
                    return rnd.NextPdfRectangle();
                case 6:
                    return rnd.NextPdfString(rnd.Next(32) + 1);
            }
        }

        public static PdfBoolean NextPdfBoolean(this Random rnd)
        {
            return PdfBoolean.Get(rnd.NextBoolean());
        }

        public static PdfInteger NextPdfInteger(this Random rnd)
        {
            return new PdfInteger(rnd.Next());
        }

        public static PdfInteger NextPdfInteger(this Random rnd, int maxValue)
        {
            return new PdfInteger(rnd.Next(maxValue));
        }

        public static PdfInteger NextPdfInteger(this Random rnd, int minValue, int maxValue)
        {
            return new PdfInteger(rnd.Next(minValue, maxValue));
        }

        public static PdfName NextPdfName(this Random rnd)
        {
            return new PdfName(rnd.NextAlphabeticalString(rnd.Next(16) + 1));
        }

#pragma warning disable IDE0060 // Remove unused parameter
        public static PdfNull NextPdfNull(this Random rnd)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            return PdfNull.Value;
        }

        public static PdfReal NextPdfReal(this Random rnd)
        {
            // The offset and multiplier here are arbitrary amounts that are within the range likely to be seen on a PDF - 5,000 points is just over 176cm.
            return new PdfReal(rnd.NextDouble() * 1000 - 5000);
        }

        public static PdfRectangle NextPdfRectangle(this Random rnd)
        {
            // See NextPdfReal() for a note on why these multipliers and offsets were chosen.
            double leftX = rnd.NextDouble() * 1000 - 5000;
            double bottomY = rnd.NextDouble() * 1000 - 5000;
            double width = rnd.NextDouble() * 500;
            double height = rnd.NextDouble() * 500;
            return new PdfRectangle(leftX, bottomY, leftX + width, bottomY + height);
        }

        public static PdfString NextPdfString(this Random rnd, int len)
        {
            return new PdfString(rnd.NextString(len));
        }
    }
}
