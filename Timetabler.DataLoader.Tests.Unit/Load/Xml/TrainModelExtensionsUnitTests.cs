using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class TrainModelExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainModelExtensionsClass_ToTrainMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            TrainModel testObject = null;
            Dictionary<string, Location> testParam1 = new Dictionary<string, Location>();
            Dictionary<string, TrainClass> testParam2 = new Dictionary<string, TrainClass>();
            Dictionary<string, Note> testParam3 = new Dictionary<string, Note>();
            DocumentOptions testParam4 = new DocumentOptions();

            _ = testObject.ToTrain(testParam1, testParam2, testParam3, testParam4);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainModelExtensionsClass_ToTrainMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            TrainModel testObject = null;
            Dictionary<string, Location> testParam1 = new Dictionary<string, Location>();
            Dictionary<string, TrainClass> testParam2 = new Dictionary<string, TrainClass>();
            Dictionary<string, Note> testParam3 = new Dictionary<string, Note>();
            DocumentOptions testParam4 = new DocumentOptions();

            try
            {
                _ = testObject.ToTrain(testParam1, testParam2, testParam3, testParam4);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
