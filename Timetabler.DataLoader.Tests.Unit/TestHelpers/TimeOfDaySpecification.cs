using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.TestHelpers
{
    internal class TimeOfDaySpecification
    {
        private static readonly Random _rnd = RandomProvider.Default;

        internal enum TimeOfDaySpecificationKind
        {
            NullValue,
            EmptyValue,
            WhitespaceValue,
            HoursOnly,
            HoursAndMinutes,
            HoursMinutesSeconds,
            HoursMinutesSecondsAndMore,
            NonNumericValue,
        };

        private string StringValue { get; set; }

        internal int? Hours { get; private set; }

        internal int? Minutes { get; private set; }

        internal int? Seconds { get; private set; }

        internal TimeOfDaySpecificationKind Kind { get; private set; }

        internal TimeOfDayModel Model
        {
            get
            {
                return new TimeOfDayModel { Time = StringValue };
            }
        }

        internal TimeOfDaySpecification(TimeOfDaySpecificationKind kind)
        {
            Kind = kind;
            Hours = null;
            Seconds = null;
            Minutes = null;

            switch (kind)
            {
                case TimeOfDaySpecificationKind.NullValue:
                    StringValue = null;
                    break;
                case TimeOfDaySpecificationKind.EmptyValue:
                    StringValue = "";
                    break;
                case TimeOfDaySpecificationKind.WhitespaceValue:
                    StringValue = _rnd.NextString(" \t\r\f", _rnd.Next(1, 20));
                    break;
                case TimeOfDaySpecificationKind.HoursOnly:
                    Hours = _rnd.Next(24);
                    StringValue = Hours.Value.ToString("d2", CultureInfo.InvariantCulture);
                    break;
                case TimeOfDaySpecificationKind.HoursAndMinutes:
                    Hours = _rnd.Next(24);
                    Minutes = _rnd.Next(60);
                    StringValue = Hours.Value.ToString("d2", CultureInfo.InvariantCulture) + ":" + Minutes.Value.ToString("d2", CultureInfo.InvariantCulture);
                    break;
                case TimeOfDaySpecificationKind.HoursMinutesSeconds:
                    Hours = _rnd.Next(24);
                    Minutes = _rnd.Next(60);
                    Seconds = _rnd.Next(60);
                    StringValue = Hours.Value.ToString("d2", CultureInfo.InvariantCulture) + ":" + Minutes.Value.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                        Seconds.Value.ToString("d2", CultureInfo.InvariantCulture);
                    break;
                case TimeOfDaySpecificationKind.HoursMinutesSecondsAndMore:
                    Hours = _rnd.Next(24);
                    Minutes = _rnd.Next(60);
                    Seconds = _rnd.Next(60);
                    StringValue = Hours.Value.ToString("d2", CultureInfo.InvariantCulture) + ":" + Minutes.Value.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                        Seconds.Value.ToString("d2", CultureInfo.InvariantCulture) + ":" + _rnd.NextString(":0123456789", _rnd.Next(2, 20));
                    break;
                case TimeOfDaySpecificationKind.NonNumericValue:
                    StringValue = _rnd.NextAlphabeticalString(_rnd.Next(10, 20));
                    break;
            }
        }
    }
}
