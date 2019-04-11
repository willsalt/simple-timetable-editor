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
        /// <param name="min">The value to return if the <see cref="P:prop"/> parameter is 0.</param>
        /// <param name="max">The value to return if the <see cref="P:Prop"/> parameter is 1.</param>
        /// <param name="prop">The proportional position between minimum and maximum.</param>
        /// <returns>The calculated absolute position.</returns>
        public static double Stretch(double min, double max, double prop)
        {
            return (max - min) * prop + min;
        }

        /// <summary>
        /// Transforms a value between 0 and 1 into a value between a minimum and maximum.
        /// </summary>
        /// <param name="min">The value to return if the <see cref="P:prop"/> parameter is 0.</param>
        /// <param name="max">The value to return if the <see cref="P:Prop"/> parameter is 1.</param>
        /// <param name="prop">The proportional position between minimum and maximum.</param>
        /// <returns>The calculated absolute position.</returns>
        public static float Stretch(float min, float max, double prop)
        {
            return (float)Stretch((double)min, (double)max, prop);
        }
    }
}
