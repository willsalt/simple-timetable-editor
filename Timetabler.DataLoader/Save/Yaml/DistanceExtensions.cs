using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class DistanceExtensions
    {
        public static DistanceModel ToYamlDistanceModel(this Distance distance)
        {
            if (distance is null)
            {
                throw new ArgumentNullException(nameof(distance));
            }

            return new DistanceModel { Miles = distance.Mileage, Chains = distance.Chainage };
        }
    }
}
