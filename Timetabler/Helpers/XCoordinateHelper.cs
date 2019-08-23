namespace Timetabler.Helpers
{
    /// <summary>
    /// A helper class for computing horizontal coordinates on a graph control.
    /// </summary>
    public class XCoordinateHelper
    {
        private float _margin;
        private double _stretchFactor;
        private int _baseValue;
        private double _range;

        /// <summary>
        /// Constructor which takes and caches the measurements which affect the computation of X coordinates.
        /// </summary>
        /// <param name="leftMargin">The position of the left-hand margin of the graph.</param>
        /// <param name="rightMargin">The position of the right-hand margin on the graph.</param>
        /// <param name="minValue">The minimum value of the X axis.</param>
        /// <param name="maxValue">The maximum value of the X axis.</param>
        public XCoordinateHelper(float leftMargin, float rightMargin, int minValue, int maxValue)
        {
            _margin = leftMargin;
            _stretchFactor = rightMargin - leftMargin;
            _baseValue = minValue;
            _range = maxValue - minValue;
        }

        /// <summary>
        /// Returns the X-coordinate of a point on the graph of a given X value, based on the dimensions passed in to the constructor.
        /// </summary>
        /// <param name="val">The X value of the point to compute the X coordinate of.</param>
        /// <returns>The X coordinate matching the given value.</returns>
        public float GetX(int val)
        {
            return (float)(_margin + _stretchFactor * (val - _baseValue) / _range);
        }
    }
}
