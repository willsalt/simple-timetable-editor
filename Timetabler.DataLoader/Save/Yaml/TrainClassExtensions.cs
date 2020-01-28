using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class TrainClassExtensions
    {
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
