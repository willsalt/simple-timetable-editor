using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class TrainTimeExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainTimeExtensionsClass_ToTrainTimeModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainTime testObject = null;

            _ = testObject.ToTrainTimeModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeExtensionsClass_ToTrainTimeModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainTime testObject = null;

            try
            {
                _ = testObject.ToTrainTimeModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("time", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
