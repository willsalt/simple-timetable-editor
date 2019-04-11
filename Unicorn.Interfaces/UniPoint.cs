namespace Unicorn.Interfaces
{
    /// <summary>
    /// A class that describes a point in 2D Cartesian space.
    /// </summary>
    public class UniPoint
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The Y coordinate.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UniPoint()
        {

        }

        /// <summary>
        /// Constructor setting initial values of properties.
        /// </summary>
        /// <param name="x">Initial value of the <see cref="X" /> property.</param>
        /// <param name="y">Initial value of the <see cref="Y" /> property.</param>
        public UniPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
