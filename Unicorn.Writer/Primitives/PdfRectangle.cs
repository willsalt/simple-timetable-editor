using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    public class PdfRectangle : PdfArray
    {
        public PdfRectangle(PdfInteger lowerLeftX, PdfInteger lowerLeftY, PdfInteger upperRightX, PdfInteger upperRightY) 
            : base(new IPdfPrimitiveObject[] { lowerLeftX, lowerLeftY, upperRightX ,upperRightY })
        {

        }

        public PdfRectangle(PdfReal lowerLeftX, PdfReal lowerLeftY, PdfReal upperRightX, PdfReal upperRightY)
            : base(new IPdfPrimitiveObject[] { lowerLeftX, lowerLeftY, upperRightX, upperRightY })
        {

        }

        public PdfRectangle(int lowerLeftX, int lowerLeftY, int upperRightX, int upperRightY)
            : this(new PdfInteger(lowerLeftX), new PdfInteger(lowerLeftY), new PdfInteger(upperRightX), new PdfInteger(upperRightY))
        {

        }

        public PdfRectangle(double lowerLeftX, double lowerLeftY, double upperRightX, double upperRightY)
            : this(new PdfReal(lowerLeftX), new PdfReal(lowerLeftY), new PdfReal(upperRightX), new PdfReal(upperRightY))
        {

        }
    }
}
