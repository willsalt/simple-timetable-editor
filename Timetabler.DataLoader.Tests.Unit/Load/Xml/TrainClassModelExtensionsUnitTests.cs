using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class TrainClassModelExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainClassModel testObject = null;

            _ = testObject.ToTrainClass();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainClassModel testObject = null;

            try
            {
                _ = testObject.ToTrainClass();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }
    }
}
