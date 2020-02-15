using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
{
    [TestClass]
    public class TrainClassExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TrainClass GetTestObject()
        {
            return new TrainClass
            {
                Description = _rnd.NextString(_rnd.Next(50)),
                Id = _rnd.NextHexString(8),
                TableCode = _rnd.NextString(_rnd.Next(5)),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TrainClassExtensionsClass_ToYamlTrainClassModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            TrainClass testParam = null;

            _ = testParam.ToYamlTrainClassModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainClassExtensionsClass_ToYamlTrainClassModelMethod_ReturnsObjectWithCorrectDescriptionProperty_IfParameterIsNotNull()
        {
            TrainClass testParam = GetTestObject();

            TrainClassModel testOutput = testParam.ToYamlTrainClassModel();

            Assert.AreEqual(testParam.Description, testOutput.Description);
        }

        [TestMethod]
        public void TrainClassExtensionsClass_ToYamlTrainClassModelMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            TrainClass testParam = GetTestObject();

            TrainClassModel testOutput = testParam.ToYamlTrainClassModel();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void TrainClassExtensionsClass_ToYamlTrainClassModelMethod_ReturnsObjectWithCorrectTableCodeProperty_IfParameterIsNotNull()
        {
            TrainClass testParam = GetTestObject();

            TrainClassModel testOutput = testParam.ToYamlTrainClassModel();

            Assert.AreEqual(testParam.TableCode, testOutput.TableCode);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
