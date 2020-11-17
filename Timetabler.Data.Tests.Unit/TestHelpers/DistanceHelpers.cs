using System;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class DistanceHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static Distance GetDistance() => new Distance(_rnd.Next(short.MaxValue), _rnd.Next(80));

#pragma warning restore CA5394 // Do not use insecure randomness

        public static Distance GetDistanceGreaterThan(Distance d) => d + GetDistance();
    }
}
