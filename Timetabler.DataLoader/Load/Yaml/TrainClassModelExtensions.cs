using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class TrainClassModelExtensions
    {
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
