using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="TrainClass" /> class.
    /// </summary>
    public static class TrainClassExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainClass" /> instance to a <see cref="TrainClassModel" /> instance.
        /// </summary>
        /// <param name="trainClass">The object to be converted.</param>
        /// <returns>A <see cref="TrainClassModel" /> instance containing the same data as the parameter in serialisable form.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static TrainClassModel ToYamlTrainClassModel(this TrainClass trainClass)
        {
            if (trainClass is null)
            {
                throw new NullReferenceException();
            }

            return new TrainClassModel
            {
                Description = trainClass.Description,
                Id = trainClass.Id,
                TableCode = trainClass.TableCode,
            };
        }
    }
}
