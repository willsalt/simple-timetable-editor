using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class TimeOfDayModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            TimeOfDayModel testParam = null;

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterHasTimePropertyThatIsNull()
        {
            TimeOfDayModel testParam = new TimeOfDayModel { Time = null };

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterHasTimePropertyThatIsEmptyString()
        {
            TimeOfDayModel testParam = new TimeOfDayModel { Time = "" };

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterHasTimePropertyThatIsSolelyWhitespace()
        {
            TimeOfDayModel testParam = new TimeOfDayModel { Time = _rnd.NextString(" \t\f\n", _rnd.Next(1, 10)) };

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
