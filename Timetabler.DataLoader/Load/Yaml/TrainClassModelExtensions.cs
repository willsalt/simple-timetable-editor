using System;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    /// <summary>
    /// Extension methods for the <see cref="TrainClassModel" /> class.
    /// </summary>
    public static class TrainClassModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainClassModel" /> instance to a <see cref="TrainClass" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A <see cref="TrainClass" /> instance containing the same data as the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static TrainClass ToTrainClass (this TrainClassModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            return new TrainClass
            {
                Id = model.Id,
                Description = model.Description,
                TableCode = model.TableCode,
            };
        }
    }
}
