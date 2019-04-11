namespace Unicorn.Interfaces
{
    /// <summary>
    /// Immutable class which encapsulates the size of a 2D rectangle.
    /// </summary>
    public class UniSize
    {
        /// <summary>
        /// Width
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Constructor, setting <see cref="Width" /> and <see cref="Height" /> properties.  
        /// </summary>
        /// <param name="width">The value of the <see cref="Width" /> property.</param>
        /// <param name="height">The value of the <see cref="Height" /> property.</param>
        public UniSize(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}
