﻿using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.TestHelpers.Extensions
{
    public static class RandomExtensions
    {
        public static TimeOfDayModel NextTimeOfDayModel(this Random random, int minSeconds, int maxSeconds)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
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

        public static Distance NextDistance(this Random random, Distance max)
        {
            int mileagePart;
            double chainagePart;
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

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
            return new Distance(mileagePart, chainagePart);
        }

        public static Distance NextDistance(this Random random)
        {
            return random.NextDistance(new Distance(32768, 0));
        }

        public static SerialData.Yaml.DistanceModel NextDistanceModel(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }

            return new SerialData.Yaml.DistanceModel { Miles = random.Next(32768), Chains = random.NextDouble() * 80 };
        }

        private static readonly string[] _validDashStyles = { "Solid", "Dash", "Dot", "DashDot", "DashDotDot", "Custom" };

        public static SerialData.Yaml.GraphTrainPropertiesModel NextGraphTrainPropertiesModel(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }

            int colour = random.Next();
            return new SerialData.Yaml.GraphTrainPropertiesModel
            {
                Colour = colour.ToString("X8", CultureInfo.InvariantCulture),
                Width = random.NextNullableFloat(5f),
                DashStyleName = random.NextPotentiallyValidString(_validDashStyles),
            };
        }
    }
}
