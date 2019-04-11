namespace Unicorn.Interfaces
{
    /// <summary>
    /// An immutable class describing the dimensions and position of a rectangular area.
    /// </summary>
    public class UniRectangle : UniSize
    {
        /// <summary>
        /// The X-coordinate of the left edge of the rectangle.
        /// </summary>
        public double Left { get; private set; }

        /// <summary>
        /// The Y-coordinate of the top edge of the rectangle.
        /// </summary>
        public double Top { get; private set; }
        
        /// <summary>
        /// Constructor with initial values.
        /// </summary>
        /// <param name="left">X-coordinate of the left edge of the rectangle.</param>
        /// <param name="top">Y-coordinate of the top edge of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public UniRectangle(double left, double top, double width, double height) : base(width, height)
        {
            Left = left;
            Top = top;
        }
    }
}
