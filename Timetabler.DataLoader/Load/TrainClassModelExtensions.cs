using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for loading a TrainClass object from serializable form.
    /// </summary>
    public static class TrainClassModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TrainClassModel"/> instance into a <see cref="TrainClass"/> instance.
        /// </summary>
        /// <param name="model">The instance to convert.</param>
        /// <returns>A <see cref="TrainClass"/> instance.</returns>
        public static TrainClass ToTrainClass(this TrainClassModel model)
        {
            return new TrainClass
            {
                Id = model.Id,
                Description = model.Description,
                TableCode = model.TableCode,
            };
        }
    }
}
