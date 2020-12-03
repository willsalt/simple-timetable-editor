using Timetabler.CoreData;

namespace Timetabler.Data.Extensions
{
    public static class HalfOfDayExtensions
    {
        public static string ToCustomName(this HalfOfDay value, DocumentExportOptions customOptions)
        {
            if (customOptions is null)
            {
                return value.ToNameString();
            }
            switch (value)
            {
                default:
                case HalfOfDay.AM:
                    return customOptions.MorningLabel;
                case HalfOfDay.Noon:
                    return customOptions.MiddayLabel;
                case HalfOfDay.PM:
                    return customOptions.AfternoonLabel;
            }
        }

        public static string ToCustomName(this HalfOfDay? value, DocumentExportOptions customOptions) => value.HasValue ? value.Value.ToCustomName(customOptions) : "";
    }
}
