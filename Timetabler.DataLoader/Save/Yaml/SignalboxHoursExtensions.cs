using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    public static class SignalboxHoursExtensions
    {
        public static SignalboxHoursModel ToYamlSignalboxHoursModel(this SignalboxHours hours)
        {
            if (hours is null)
            {
                throw new NullReferenceException();
            }

            return new SignalboxHoursModel
            {
                SignalboxId = hours.Signalbox?.Id,
                FinishTime = hours.EndTime.ToYamlTimeOfDayModel(),
                StartTime = hours.StartTime.ToYamlTimeOfDayModel(),
                TokenBalanceWarning = hours.TokenBalanceWarning,
            };
        }
    }
}
