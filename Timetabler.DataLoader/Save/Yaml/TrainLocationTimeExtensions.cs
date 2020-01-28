using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class TrainLocationTimeExtensions
    {
        public static TrainLocationTimeModel ToYamlTrainLocationTimeModel(this TrainLocationTime tlt)
        {
            if (tlt is null)
            {
                throw new NullReferenceException();
            }

            return new TrainLocationTimeModel
            {
                Arrival = tlt.ArrivalTime.ToYamlTrainTimeModel(),
                Departure = tlt.DepartureTime.ToYamlTrainTimeModel(),
                LocationId = tlt.Location.Id,
                Pass = tlt.Pass,
                Platform = tlt.Platform,
                Path = tlt.Path,
                Line = tlt.Line,
            };
        }
    }
}
