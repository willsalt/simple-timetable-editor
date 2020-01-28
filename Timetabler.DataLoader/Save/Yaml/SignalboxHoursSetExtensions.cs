using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class SignalboxHoursSetExtensions
    {
        public static SignalboxHoursSetModel ToYamlSignalboxHoursSetModel(this SignalboxHoursSet set)
        {
            if (set is null)
            {
                throw new NullReferenceException();
            }

            return new SignalboxHoursSetModel
            {
                Category = set.Category,
                Signalboxes = set.Hours.Values.Select(h => h.ToYamlSignalboxHoursModel()).ToList(),
            };
        }
    }
}
