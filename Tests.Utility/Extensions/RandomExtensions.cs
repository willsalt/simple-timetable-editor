﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Timetabler.CoreData;

namespace Tests.Utility.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class RandomExtensions
    {

#pragma warning disable CA5394 // Do not use insecure randomness

        public const string AlphanumericCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public const string AlphabeticalCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string HexadecimalCharacters = "abcdef0123456789";
        public const string WhiteSpaceCharacters = " \x0\t\r\n\f";
        public const string DelimiterCharacters = "()<>[]{}/%"; // These are the characters classed as "delimiters" in PDF documents.

        public static string NextString(this Random random, int len)
        {
            return random.NextString(AlphanumericCharacters, len);
        }

        public static string NextAlphabeticalString(this Random random, int len)
        {
            return random.NextString(AlphabeticalCharacters, len);
        }

        public static string NextHexString(this Random random, int len)
        {
            return random.NextString(HexadecimalCharacters, len);
        }

        public static string NextString(this Random random, string characters, int len)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
            }
            return random.Next(2) == 0;
        }

        public static bool? NextNullableBoolean(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            bool?[] values = { true, false, null };
            return values[random.Next(values.Length)];
        }

        public static double? NextNullableDouble(this Random random, double scale)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return random.NextDouble() * scale;
        }

        public static double? NextNullableDouble(this Random random)
        {
            return NextNullableDouble(random, 1.0);
        }

        public static float? NextNullableFloat(this Random random)
        {
            return (float?)NextNullableDouble(random);
        }

        public static float? NextNullableFloat(this Random random, float scale)
        {
            return (float?)NextNullableDouble(random, scale);
        }

        public static DateTime NextDateTime(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            long ticks = NextLong(random, DateTime.MaxValue.Ticks);
            return new DateTime().AddTicks(ticks);
        }

        public static TimeOfDay NextTimeOfDay(this Random random)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
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
                throw new ArgumentNullException(nameof(random));
            }

            int lim = maxSeconds - minSeconds;
            return new TimeOfDay(random.Next(lim) + minSeconds);
        }

        public static ArrivalDepartureOptions NextArrivalDepartureOptions(this Random random)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            ArrivalDepartureOptions[] allValues = new ArrivalDepartureOptions[]
            {
                0,
                ArrivalDepartureOptions.Arrival,
                ArrivalDepartureOptions.Departure,
                ArrivalDepartureOptions.Arrival | ArrivalDepartureOptions.Departure
            };
            return allValues[random.Next(allValues.Length)];
        }

        public static ArrivalDepartureOptions? NextNullableArrivalDepartureOptions(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (random.Next(5) == 0)
            {
                return null;
            }

            return NextArrivalDepartureOptions(random);
        }

        public static TrainRoutingOptions NextTrainRoutingOptions(this Random random)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
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

        public static TrainRoutingOptions? NextNullableTrainRoutingOptions(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (random.Next(9) == 0)
            {
                return null;
            }

            return NextTrainRoutingOptions(random);
        }

        public static LocationFontType NextLocationFontType(this Random random)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            LocationFontType[] allValues = new LocationFontType[]
            {
                LocationFontType.Condensed,
                LocationFontType.Normal,
            };

            return allValues[random.Next(allValues.Length)];
        }

        public static string NextPotentiallyValidString(this Random random, string[] validValues)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (validValues is null)
            {
                throw new ArgumentNullException(nameof(validValues));
            }

            if (random.Next(5) == 0)
            {
                return NextDefinitelyInvalidString(random, validValues);
            }
            else
            {
                return validValues[random.Next(validValues.Length)];
            }
        }

        public static string NextDefinitelyInvalidString(this Random random, string[] validValues)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            string rval;
            do
            {
                rval = random.NextAlphabeticalString(random.Next(10));
            } while (validValues.Contains(rval));
            return rval;
        }

        public static Orientation NextOrientation(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            Orientation[] allValues = new[] { Orientation.Landscape, Orientation.Portrait };
            return allValues[random.Next(allValues.Length)];
        }

        public static Orientation? NextNullableOrientation(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return random.Next(5) == 0 ? (Orientation?)null : NextOrientation(random);
        }

        public static decimal NextDecimal(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (decimal)random.NextDouble() * 2000m - 1000m;
        }

        public static decimal? NextNullableDecimal(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextDecimal(random);
        }

        public static short NextShort(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (short)random.Next(short.MaxValue + 1);
        }

        public static short? NextNullableShort(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextShort(random);
        }

        public static int? NextNullableInt(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return random.Next();
        }

        [CLSCompliant(false)]
        public static ushort NextUShort(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (ushort)random.Next(ushort.MaxValue + 1);
        }

        [CLSCompliant(false)]
        public static uint NextUInt(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(2) == 0)
            {
                return (uint)random.Next();
            }
            return int.MaxValue + (uint)random.Next();
        }

        [CLSCompliant(false)]
        public static uint NextUInt(this Random random, uint max)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (max < int.MaxValue)
            {
                return (uint)random.Next((int)max);
            }
            return unchecked((uint)random.Next((int)(max >> 1)) << 1) | (uint)random.Next(2);
        }

        [CLSCompliant(false)]
        public static ulong NextULong(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(2) == 0)
            {
                return random.NextUInt();
            }
            return uint.MaxValue + (ulong)random.NextUInt();
        }

        public static long NextLong(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(63) < 32)
            {
                return NextUInt(random);
            }
            return NextUInt(random) | ((long)random.Next() << 32);
        }

        public static long NextLong(this Random random, long max)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (max < uint.MaxValue)
            {
                return random.NextUInt((uint)max);
            }
            return random.NextUInt() | (long)random.Next((int)(max >> 32)) << 32;
        }

        [CLSCompliant(false)]
        public static uint? NextNullableUInt(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextUInt(random);
        }

        public static byte NextByte(this Random random)
        {
            return NextByte(random, byte.MaxValue + 1);
        }

        public static byte NextByte(this Random random, int max)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (byte)random.Next(max);
        }

        public static SectionSelection NextSectionSelection(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            SectionSelection[] values = new[] { SectionSelection.None, SectionSelection.First, SectionSelection.All };
            return values[random.Next(values.Length)];
        }

        public static SectionSelection? NextNullableSectionSelection(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(4) == 0)
            {
                return null;
            }
            return NextSectionSelection(random);
        }

        public static Direction NextDirection(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return random.NextBoolean() ? Direction.Down : Direction.Up;
        }

        public static Direction? NextNullableDirection(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(3) == 0)
            {
                return null;
            }
            return NextDirection(random);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
