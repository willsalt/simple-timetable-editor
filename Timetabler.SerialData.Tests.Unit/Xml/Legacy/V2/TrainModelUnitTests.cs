using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.SerialData.Xml.Legacy.V2;

namespace Timetabler.SerialData.Tests.Unit.Xml.Legacy.V2
{
    [TestClass]
    public class TrainModelUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainModelClass_ReadXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainModel testObject = new TrainModel();

            testObject.ReadXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainModelClass_ReadXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainModel testObject = new TrainModel();

            try
            {
                testObject.ReadXml(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("reader", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainModelClass_WriteXmlMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainModel testObject = new TrainModel();

            testObject.WriteXml(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainModelClass_WriteXmlMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainModel testObject = new TrainModel();

            try
            {
                testObject.WriteXml(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("writer", ex.ParamName);
            }
        }
    }
}
