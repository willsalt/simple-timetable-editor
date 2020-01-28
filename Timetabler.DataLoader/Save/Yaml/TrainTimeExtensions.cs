using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class TrainTimeExtensions
    {
        public static TrainTimeModel ToYamlTrainTimeModel(this TrainTime tt)
        {
            if (tt is null)
            {
                throw new NullReferenceException();
            }

            return new TrainTimeModel
            {
                At = tt.Time?.ToYamlTimeOfDayModel(),
                FootnoteIds = tt.Footnotes.Select(n => n.Id).ToList(),
            };
        }
    }
}
