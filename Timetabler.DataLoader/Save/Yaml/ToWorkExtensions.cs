using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class ToWorkExtensions
    {
        public static ToWorkModel ToYamlToWorkModel(this ToWork toWork)
        {
            if (toWork is null)
            {
                throw new NullReferenceException();
            }

            return new ToWorkModel
            {
                Text = toWork.Text,
                At = toWork.AtTime?.ToYamlTimeOfDayModel(),
            };
        }
    }
}
