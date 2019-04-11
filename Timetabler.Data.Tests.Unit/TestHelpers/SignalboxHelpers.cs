using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Timetabler.CoreData.Helpers;

namespace Timetabler.Data.Tests.Unit.TestHelpers
{
    public static class SignalboxHelpers
    {
        public static Random _random = new Random();

        public static Signalbox GetSignalbox()
        {
            return new Signalbox
            {
                Id = GeneralHelper.GetNewId(new Signalbox[0]),
                Code = _random.NextString(_random.Next(1, 4)),
                EditorDisplayName = _random.NextString(_random.Next(128)),
                ExportDisplayName = _random.NextString(_random.Next(128))
            };
        }

        public static List<Signalbox> GetSignalboxList(int min, int max)
        {
            int count = _random.Next(min, max);
            List<Signalbox> output = new List<Signalbox>(count);
            for (int i = 0; i < count; ++i)
            {
                output.Add(GetSignalbox());
            }
            return output;
        }
    }
}
