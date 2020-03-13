using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class TrainClassExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainClassExtensionsClass_ToTrainClassModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainClass testObject = null;

            _ = testObject.ToTrainClassModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainClassExtensionsClass_ToTrainClassModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainClass testObject = null;

            try
            {
                _ = testObject.ToTrainClassModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("trainClass", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
