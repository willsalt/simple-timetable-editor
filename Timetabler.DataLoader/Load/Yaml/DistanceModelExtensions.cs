using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class DistanceModelExtensions
    {
        public static Distance ToDistance(this DistanceModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            return new Distance
            {
                Mileage = model.Miles,
                Chainage = model.Chains,
            };
        }
    }
}
