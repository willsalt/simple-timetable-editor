using System;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Class for loading <see cref="Distance"/> objects from serialised form into memory.
    /// </summary>
    public static class DistanceModelExtensions
    {
        /// <summary>
        /// Convert this <see cref="DistanceModel"/> instance into a <see cref="Distance"/> object.
        /// </summary>
        /// <param name="model">The data to be loaded.</param>
        /// <returns>The <see cref="Distance"/> object.</returns>
        public static Distance ToDistance(this DistanceModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return new Distance
            {
                Mileage = model.Mileage,
                Chainage = model.Chainage
            };
        }
    }
}
