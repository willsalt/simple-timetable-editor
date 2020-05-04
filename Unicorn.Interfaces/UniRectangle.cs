namespace Unicorn.Interfaces
{
    /// <summary>
    /// An immutable class describing the dimensions and position of a rectangular area.
    /// </summary>
    public struct UniRectangle
    {
        /// <summary>
        /// The X-coordinate of the left edge of the rectangle.
        /// </summary>
        public double Left { get; private set; }

        /// <summary>
        /// The Y-coordinate of the top edge of the rectangle.
        /// </summary>
        public double Top { get; private set; }

        public UniSize Size { get; private set; }

        public double Width => Size.Width;

        public double Height => Size.Height;
        
        /// <summary>
        /// Constructor with initial values.
        /// </summary>
        /// <param name="left">X-coordinate of the left edge of the rectangle.</param>
        /// <param name="top">Y-coordinate of the top edge of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public UniRectangle(double left, double top, double width, double height)
        {
            Size = new UniSize(width, height);
            Left = left;
            Top = top;
        }
    }
}
