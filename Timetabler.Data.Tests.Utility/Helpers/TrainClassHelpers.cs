using System;
using System.Diagnostics.CodeAnalysis;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Utility.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class TrainClassHelpers
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        public static TrainClass GetTrainClass() => new TrainClass
        {
            Description = _rnd.NextString(_rnd.Next(1, 50)),
            Id = _rnd.NextHexString(8),
            TableCode = _rnd.NextString(2),
        };

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
