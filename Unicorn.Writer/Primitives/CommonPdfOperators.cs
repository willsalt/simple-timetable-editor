namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Commonly-used PDF operators.
    /// </summary>
    public static class CommonPdfOperators
    {
        /// <summary>
        /// The "re" operator, for appending a rectangle to a path.
        /// </summary>
        public static readonly PdfOperator AppendRectangle = new PdfOperator("re");

        /// <summary>
        /// The "l" operator, for appending a straight line to a path.
        /// </summary>
        public static readonly PdfOperator AppendStraightLine = new PdfOperator("l");

        /// <summary>
        /// The "d" operator, for setting the current line dash pattern.
        /// </summary>
        public static readonly PdfOperator LineDashPattern = new PdfOperator("d");

        /// <summary>
        /// The "w" operator, for setting the current line width.
        /// </summary>
        public static readonly PdfOperator LineWidth = new PdfOperator("w");

        /// <summary>
        /// The "m" operator, for commencing a new path or subpath.
        /// </summary>
        public static readonly PdfOperator StartPath = new PdfOperator("m");

        /// <summary>
        /// The "S" operator, for stroking (and ending) a path.
        /// </summary>
        public static readonly PdfOperator StrokePath = new PdfOperator("S");
    }
}
