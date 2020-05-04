using System;

namespace Unicorn.Interfaces
{
    /// <summary>
    /// A struct that describes a point in 2D Cartesian space.
    /// </summary>
    public struct UniPoint : IEquatable<UniPoint>
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
        /// Constructor setting initial values of properties.
        /// </summary>
        /// <param name="x">Initial value of the <see cref="X" /> property.</param>
        /// <param name="y">Initial value of the <see cref="Y" /> property.</param>
        public UniPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(UniPoint other) => this == other;

        public override bool Equals(object obj)
        {
            if (obj is UniPoint other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (Y * 2).GetHashCode();
        }

        public static bool operator ==(UniPoint a, UniPoint b) => a.X == b.X && a.Y == b.Y;

        public static bool operator !=(UniPoint a, UniPoint b) => a.X != b.X || a.Y != b.Y;
    }
}
