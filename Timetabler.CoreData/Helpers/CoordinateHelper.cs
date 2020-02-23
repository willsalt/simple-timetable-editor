namespace Timetabler.CoreData.Helpers
{
    /// <summary>
    /// Helper class for tranforming coordinates.
    /// </summary>
    public static class CoordinateHelper
    {
        /// <summary>
        /// Transforms a value between 0 and 1 into a value between a minimum and maximum.
        /// </summary>
        /// <param name="min">The value to return if the <c>prop</c> parameter is 0.</param>
        /// <param name="max">The value to return if the <c>prop</c> parameter is 1.</param>
        /// <param name="prop">The proportional position between minimum and maximum.</param>
        /// <returns>The calculated absolute position.</returns>
        public static double Stretch(double min, double max, double prop)
        {
            return (max - min) * prop + min;
        }

        /// <summary>
        /// Transforms a value between 0 and 1 into a value between a minimum and maximum.
        /// </summary>
        /// <param name="min">The value to return if the <c>prop</c> parameter is 0.</param>
        /// <param name="max">The value to return if the <c>prop</c> parameter is 1.</param>
        /// <param name="prop">The proportional position between minimum and maximum.</param>
        /// <returns>The calculated absolute position.</returns>
        public static float Stretch(float min, float max, double prop)
        {
            return (float)Stretch((double)min, max, prop);
        }

        /// <summary>
        /// Transforms a value between a minimum and a maximum into a value between 0 and 1.
        /// </summary>
        /// <param name="min">The minimum value, scaling to 0.</param>
        /// <param name="max">The maximum value, scaling to 1.</param>
        /// <param name="amt">The value to be scaled.</param>
        /// <returns>A value representing the position of the <c>amt</c> parameter relative to the <c>min</c> and <c>max</c> parameters.</returns>
        public static double Unstretch(double min, double max, double amt)
        {
            if (min == max)
            {
                return 0.0;
            }
            return (amt - min) / (max - min);
        }
    }
}
