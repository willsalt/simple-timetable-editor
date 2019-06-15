using System;
using System.Text;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.XmlData;

namespace Tests.Utility.Extensions
{
    public static class RandomExtensions
    {
        private const string _alphanumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private const string _hex = "abcdef0123456789";

        public static string NextString(this Random random, int len)
        {
            return random.NextString(_alphanumeric, len);
        }

        public static string NextHexString(this Random random, int len)
        {
            return random.NextString(_hex, len);
        }

        public static string NextString(this Random random, string characters, int len)
        {
            if (len == 0)
            {
                return string.Empty;
            }
            if (len == 1)
            {
                return new string(SelectCharacter(random, characters), 1);
            }
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < len; ++i)
            {
                sb.Append(SelectCharacter(random, characters));
            }
            return sb.ToString();
        }

        private static char SelectCharacter(Random random, string characters)
        {
            return characters[random.Next(characters.Length)];
        }

        public static bool NextBoolean(this Random random)
        {
            return random.Next(2) == 0;
        }

        public static TimeOfDay NextTimeOfDay(this Random random)
        {
            return new TimeOfDay(random.Next(86400));
        }

        public static TimeOfDay NextTimeOfDayBefore(this Random random, TimeOfDay t)
        {
            return new TimeOfDay(random.Next(t.AbsoluteSeconds));
        }

        public static TimeOfDay NextTimeOfDayAfter(this Random random, TimeOfDay t)
        {
            int lim = 86400 - t.AbsoluteSeconds;
            return new TimeOfDay(random.Next(lim) + t.AbsoluteSeconds);
        }

        public static ArrivalDepartureOptions NextArrivalDepartureOptions(this Random random)
        {
            ArrivalDepartureOptions[] allValues = new ArrivalDepartureOptions[]
            {
                0,
                ArrivalDepartureOptions.Arrival,
                ArrivalDepartureOptions.Departure,
                ArrivalDepartureOptions.Arrival | ArrivalDepartureOptions.Departure
            };
            return allValues[random.Next(allValues.Length)];
        }

        public static TrainRoutingOptions NextTrainRoutingOptions(this Random random)
        {
            TrainRoutingOptions[] allValues = new TrainRoutingOptions[]
{
                0,
                TrainRoutingOptions.Line,
                TrainRoutingOptions.Path,
                TrainRoutingOptions.Platform,
                TrainRoutingOptions.Line | TrainRoutingOptions.Path,
                TrainRoutingOptions.Line | TrainRoutingOptions.Platform,
                TrainRoutingOptions.Path | TrainRoutingOptions.Platform,
                TrainRoutingOptions.Line | TrainRoutingOptions.Path | TrainRoutingOptions.Platform,
};
            return allValues[random.Next(allValues.Length)];
        }

        public static LocationFontType NextLocationFontType(this Random random)
        {
            LocationFontType[] allValues = new LocationFontType[]
            {
                LocationFontType.Condensed,
                LocationFontType.Normal,
            };

            return allValues[random.Next(allValues.Length)];
        }

        public static Distance NextDistance(this Random random, Distance max)
        {
            int mileagePart;
            double chainagePart;
            if (max.Mileage > 0)
            {
                mileagePart = random.Next(max.Mileage);
            }
            else
            {
                mileagePart = 0;
            }
            if (mileagePart < max.Mileage)
            {
                chainagePart = random.NextDouble() * 80d;
            }
            else
            {
                chainagePart = random.NextDouble() * max.Chainage;
            }
            return new Distance { Mileage = mileagePart, Chainage = chainagePart };
        }

        public static Distance NextDistance(this Random random)
        {
            return random.NextDistance(new Distance { Mileage = 32768, Chainage = 0 });
        }

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
