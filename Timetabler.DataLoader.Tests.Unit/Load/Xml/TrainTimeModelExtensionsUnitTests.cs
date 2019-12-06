using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class TrainTimeModelExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            TrainTimeModel testObject = null;
            Dictionary<string, Note> testParam1 = new Dictionary<string, Note>();

            _ = testObject.ToTrainTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            TrainTimeModel testObject = null;
            Dictionary<string, Note> testParam1 = new Dictionary<string, Note>();

            try
            {
                _ = testObject.ToTrainTime(testParam1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }
    }
}
