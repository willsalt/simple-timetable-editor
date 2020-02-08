using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class TrainTimeModelExtensionsUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            TrainTimeModel testParam0 = null;
            Dictionary<string, Note> testParam1 = new Dictionary<string, Note>();

            _ = testParam0.ToTrainTime(testParam1);

            Assert.Fail();
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
