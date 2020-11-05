using System;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class DistanceHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

        public static Distance GetDistance()
        {
            return new Distance(_rnd.Next(short.MaxValue), _rnd.Next(80));
        }

        public static Distance GetDistanceGreaterThan(Distance d)
        {
            return d + GetDistance();
        }
    }
}
