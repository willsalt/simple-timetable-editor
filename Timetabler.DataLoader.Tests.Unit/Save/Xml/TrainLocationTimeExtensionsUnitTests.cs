using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class TrainLocationTimeExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainLocationTimeExtensionsClass_ToTrainLocationTimeModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainLocationTime testObject = null;

            _ = testObject.ToTrainLocationTimeModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainLocationTimeExtensionsClass_ToTrainLocationTimeModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainLocationTime testObject = null;

            try
            {
                _ = testObject.ToTrainLocationTimeModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("tlt", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
