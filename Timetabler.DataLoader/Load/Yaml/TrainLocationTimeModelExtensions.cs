using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class TrainLocationTimeModelExtensions
    {
        public static TrainLocationTime ToTrainLocationTime(
            this TrainLocationTimeModel model,
            Dictionary<string, Location> locations,
            Dictionary<string, Note> notes,
            DocumentOptions options)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            TrainLocationTime output = new TrainLocationTime
            {
                Pass = model.Pass ?? false,
                ArrivalTime = model.Arrival?.ToTrainTime(notes),
                DepartureTime = model.Departure?.ToTrainTime(notes),
                Path = model.Path,
                Platform = model.Platform,
                Line = model.Line,
                FormattingStrings = options.FormattingStrings,
            };

            if (model.LocationId != null && locations != null && locations.ContainsKey(model.LocationId))
            {
                output.Location = locations[model.LocationId];
            }

            return output;
        }
    }
}
