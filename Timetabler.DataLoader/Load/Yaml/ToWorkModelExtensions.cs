using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class ToWorkModelExtensions
    {
        public static ToWork ToToWork(this ToWorkModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            ToWork output = new ToWork { Text = model.Text };
            if (model.At != null)
            {
                output.AtTime = model.At.ToTimeOfDay();
            }
            return output;
        }
    }
}
