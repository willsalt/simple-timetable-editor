using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class SignalboxHoursModelExtensions
    {
        public static SignalboxHours ToSignalboxHours(this SignalboxHoursModel model, IDictionary<string, Signalbox> signalboxes)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }
            if (signalboxes is null)
            {
                throw new ArgumentNullException(nameof(signalboxes));
            }

            return new SignalboxHours
            {
                Signalbox = signalboxes.ContainsKey(model.SignalboxId) ? signalboxes[model.SignalboxId] : null,
                EndTime = model.FinishTime.ToTimeOfDay(),
                StartTime = model.StartTime.ToTimeOfDay(),
                TokenBalanceWarning = model.TokenBalanceWarning ?? false,
            };
        }
    }
}
