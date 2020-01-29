using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    public static class SignalboxHoursSetModelExtensions
    {
        public static SignalboxHoursSet ToSignalboxHoursSet(
            this SignalboxHoursSetModel model, 
            IDictionary<string, Signalbox> signalboxes, 
            IEnumerable<SignalboxHoursSet> existingSets)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }
            if (signalboxes is null)
            {
                throw new ArgumentNullException(nameof(signalboxes));
            }
            if (existingSets is null)
            {
                throw new ArgumentNullException(nameof(existingSets));
            }

            SignalboxHoursSet hoursSet = new SignalboxHoursSet { Id = GeneralHelper.GetNewId(existingSets), Category = model.Category };
            foreach (SignalboxHoursModel hoursModel in model.Signalboxes)
            {
                SignalboxHours hours = hoursModel.ToSignalboxHours(signalboxes);
                hoursSet.Hours.Add(hours.Signalbox.Id, hours);
            }
            return hoursSet;
        }
    }
}
