using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class TrainExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainExtensionsClass_ToTrainModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Train testObject = null;

            _ = testObject.ToTrainModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainExtensionsClass_ToTrainModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Train testObject = null;

            try
            {
                _ = testObject.ToTrainModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("train", ex.ParamName);
            }
        }
    }
}
