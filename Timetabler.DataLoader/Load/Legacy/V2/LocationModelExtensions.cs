using Timetabler.Data;
using Timetabler.XmlData.Legacy.V2;

namespace Timetabler.DataLoader.Load.Legacy.V2
{
    /// <summary>
    /// Extension class for converting <see cref="LocationModel"/> instances to <see cref="Location"/> instances.
    /// </summary>
    public static class LocationModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="LocationModel"/> to a <see cref="Location"/>.
        /// </summary>
        /// <param name="model">The model to be converted.</param>
        /// <returns>A <see cref="Location"/> instance containing the same data as the model.</returns>
        public static Location ToLocation(this LocationModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Location
            {
                Id = model.Id,
                EditorDisplayName = model.EditorDisplayName,
                TimetableDisplayName = model.TimetableDisplayName,
                GraphDisplayName = model.GraphDisplayName,
                Tiploc = model.Tiploc,
                UpArrivalDepartureAlwaysDisplayed = model.UpArrivalDepartureAlwaysDisplayed,
                DownArrivalDepartureAlwaysDisplayed = model.DownArrivalDepartureAlwaysDisplayed,
                Mileage = model.Mileage.ToDistance(),
            };
        }
    }
}
