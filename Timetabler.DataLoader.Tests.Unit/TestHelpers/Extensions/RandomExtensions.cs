using System;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Tests.Unit.TestHelpers.Extensions
{
    public static class RandomExtensions
    {
        public static TimeOfDayModel NextTimeOfDayModel(this Random random, int minSeconds, int maxSeconds)
        {
            if (maxSeconds == 0)
            {
                maxSeconds = 86400;
            }
            int secs = random.Next(maxSeconds - minSeconds) + minSeconds;

            return new TimeOfDayModel
            {
                Hours24 = secs / 3600,
                Minutes = (secs % 3600) / 60,
                Seconds = secs % 60
            };
        }

        public static TimeOfDayModel NextTimeOfDayModel(this Random random)
        {
            return random.NextTimeOfDayModel(0, 0);
        }
    }
}
