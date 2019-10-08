using System;
using System.Text;
using Timetabler.CoreData;

namespace Tests.Utility.Extensions
{
    public static class RandomExtensions
    {
        private const string _alphanumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string _alphabetical = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _hex = "abcdef0123456789";

        public static string NextString(this Random random, int len)
        {
            return random.NextString(_alphanumeric, len);
        }

        public static string NextAlphabeticalString(this Random random, int len)
        {
            return random.NextString(_alphabetical, len);
        }

        public static string NextHexString(this Random random, int len)
        {
            return random.NextString(_hex, len);
        }

        public static string NextString(this Random random, string characters, int len)
        {
            if (random == null)
            {
                throw new NullReferenceException();
            }
            if (characters == null)
            {
                throw new ArgumentNullException(nameof(characters));
            }

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
            if (random == null)
            {
                throw new NullReferenceException();
            }
            return random.Next(2) == 0;
        }

        public static TimeOfDay NextTimeOfDay(this Random random)
        {
            if (random == null)
            {
                throw new NullReferenceException();
            }
            return new TimeOfDay(random.Next(86400));
        }

        public static TimeOfDay NextTimeOfDayBefore(this Random random, TimeOfDay t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            return random.NextTimeOfDayBefore(t.AbsoluteSeconds);
        }

        public static TimeOfDay NextTimeOfDayBefore(this Random random, int seconds)
        {
            if (random == null)
            {
                throw new NullReferenceException();
            }
            return new TimeOfDay(random.Next(seconds));
        }

        public static TimeOfDay NextTimeOfDayAfter(this Random random, TimeOfDay t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }
            return random.NextTimeOfDayAfter(t.AbsoluteSeconds);
        }

        public static TimeOfDay NextTimeOfDayAfter(this Random random, int seconds)
        {
            if (random == null)
            {
                throw new NullReferenceException();
            }
            int lim = 86400 - seconds;
            return new TimeOfDay(random.Next(lim) + seconds);
        }

        public static TimeOfDay NextTimeOfDayBetween(this Random random, TimeOfDay min, TimeOfDay max)
        {
            if (min == null)
            {
                throw new ArgumentNullException(nameof(min));
            }
            if (max == null)
            {
                throw new ArgumentNullException(nameof(max));
            }

            return random.NextTimeOfDayBetween(min.AbsoluteSeconds, max.AbsoluteSeconds);
        }

        public static TimeOfDay NextTimeOfDayBetween(this Random random, TimeOfDay min, int maxSeconds)
        {
            if (min == null)
            {
                throw new ArgumentNullException(nameof(min));
            }

            return random.NextTimeOfDayBetween(min.AbsoluteSeconds, maxSeconds);
        }

        public static TimeOfDay NextTimeOfDayBetween(this Random random, int minSeconds, int maxSeconds)
        {
            if (random == null)
            {
                throw new NullReferenceException();
            }

            int lim = maxSeconds - minSeconds;
            return new TimeOfDay(random.Next(lim) + minSeconds);
        }

        public static ArrivalDepartureOptions NextArrivalDepartureOptions(this Random random)
        {
            if (random == null)
            {
                throw new NullReferenceException();
            }

            ArrivalDepartureOptions[] allValues = new ArrivalDepartureOptions[]
            {
                ArrivalDepartureOptions.Arrival,
                ArrivalDepartureOptions.Departure,
                ArrivalDepartureOptions.Arrival | ArrivalDepartureOptions.Departure
            };
            return allValues[random.Next(allValues.Length)];
        }

        public static TrainRoutingOptions NextTrainRoutingOptions(this Random random)
        {
            if (random == null)
            {
                throw new NullReferenceException();
            }

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
            if (random == null)
            {
                throw new NullReferenceException();
            }

            LocationFontType[] allValues = new LocationFontType[]
            {
                LocationFontType.Condensed,
                LocationFontType.Normal,
            };

            return allValues[random.Next(allValues.Length)];
        }
    }
}
