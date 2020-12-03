using System;
using System.Diagnostics.CodeAnalysis;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Utility.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class ToWorkHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static ToWork GetToWork() => new ToWork
        {
            AtTime = _rnd.NextTimeOfDay(),
            Text = _rnd.NextBoolean() ? _rnd.NextString(_rnd.Next(4)) : null,
        };

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
