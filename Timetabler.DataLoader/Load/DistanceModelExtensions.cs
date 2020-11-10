using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for the <see cref="DistanceModel" /> class.
    /// </summary>
    public static class DistanceModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="DistanceModel" /> instance into a <see cref="Distance" /> instance.
        /// </summary>
        /// <param name="model">The <see cref="DistanceModel" /> instance to be converted.</param>
        /// <returns>A <see cref="Distance" /> instance.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <c>this</c> parameter is <c>null</c>.</exception>
        public static Distance ToDistance(this DistanceModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            return new Distance(model.Miles, model.Chains);
        }
    }
}
