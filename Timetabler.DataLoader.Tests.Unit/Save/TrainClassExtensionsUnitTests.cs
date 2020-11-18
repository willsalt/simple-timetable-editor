using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class TrainClassExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static TrainClass GetTestObject() => new TrainClass
        {
            Description = _rnd.NextString(_rnd.Next(50)),
            Id = _rnd.NextHexString(8),
            TableCode = _rnd.NextString(_rnd.Next(5)),
        };

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainClassExtensionsClass_ToTrainClassModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainClass testParam = null;

            _ = testParam.ToTrainClassModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainClassExtensionsClass_ToTrainClassModelMethod_ReturnsObjectWithCorrectDescriptionProperty_IfParameterIsNotNull()
        {
            TrainClass testParam = GetTestObject();

            TrainClassModel testOutput = testParam.ToTrainClassModel();

            Assert.AreEqual(testParam.Description, testOutput.Description);
        }

        [TestMethod]
        public void TrainClassExtensionsClass_ToTrainClassModelMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            TrainClass testParam = GetTestObject();

            TrainClassModel testOutput = testParam.ToTrainClassModel();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void TrainClassExtensionsClass_ToTrainClassModelMethod_ReturnsObjectWithCorrectTableCodeProperty_IfParameterIsNotNull()
        {
            TrainClass testParam = GetTestObject();

            TrainClassModel testOutput = testParam.ToTrainClassModel();

            Assert.AreEqual(testParam.TableCode, testOutput.TableCode);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
