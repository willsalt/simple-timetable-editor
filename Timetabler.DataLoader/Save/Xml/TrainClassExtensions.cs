using System;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Save.Xml
{
    /// <summary>
    /// Extension methods for converting <see cref="TrainClass"/> instances into serialisable form.
    /// </summary>
    public static class TrainClassExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainClass"/> instance into a <see cref="TrainClassModel"/> instance.
        /// </summary>
        /// <param name="trainClass">The object to convert.</param>
        /// <returns>A <see cref="TrainClassModel"/> instance whose properties are the same as the parameter.</returns>
        public static TrainClassModel ToTrainClassModel(this TrainClass trainClass)
        {
            if (trainClass is null)
            {
                throw new ArgumentNullException(nameof(trainClass));
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
