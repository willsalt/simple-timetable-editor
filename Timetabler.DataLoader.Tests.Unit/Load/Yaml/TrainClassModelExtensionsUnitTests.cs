using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class TrainClassModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TrainClassModel GetModel()
        {
            return new TrainClassModel
            {
                Id = _rnd.NextHexString(8),
                Description = _rnd.NextString(_rnd.Next(50)),
                TableCode = _rnd.NextString(_rnd.Next(5)),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            TrainClassModel testParam = null;

            _ = testParam.ToTrainClass();

            Assert.Fail();
        }

        [TestMethod]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ReturnsObjectWithCorrectIdProperty_IfParameterHasIdPropertyThatIsNotNull()
        {
            TrainClassModel testParam = GetModel();

            TrainClass testOutput = testParam.ToTrainClass();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ReturnsObjectWithIdPropertyEqualToNull_IfParameterHasIdPropertyThatIsNull()
        {
            TrainClassModel testParam = GetModel();
            testParam.Id = null;

            TrainClass testOutput = testParam.ToTrainClass();

            Assert.IsNull(testOutput.Id);
        }

        [TestMethod]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ReturnsObjectWithCorrectDescriptionProperty_IfParameterHasDescriptionPropertyThatIsNotNull()
        {
            TrainClassModel testParam = GetModel();

            TrainClass testOutput = testParam.ToTrainClass();

            Assert.AreEqual(testParam.Description, testOutput.Description);
        }

        [TestMethod]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ReturnsObjectWithDescriptionPropertyEqualToNull_IfParameterHasDescriptionPropertyThatIsNull()
        {
            TrainClassModel testParam = GetModel();
            testParam.Description = null;

            TrainClass testOutput = testParam.ToTrainClass();

            Assert.IsNull(testOutput.Description);
        }

        [TestMethod]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ReturnsObjectWithCorrectTableCodeProperty_IfParameterHasTableCodePropertyThatIsNotNull()
        {
            TrainClassModel testParam = GetModel();

            TrainClass testOutput = testParam.ToTrainClass();

            Assert.AreEqual(testParam.TableCode, testOutput.TableCode);
        }

        [TestMethod]
        public void TrainClassModelExtensionsClass_ToTrainClassMethod_ReturnsObjectWithTableCodePropertyEqualToNull_IfParameterHasTableCodePropertyThatIsNull()
        {
            TrainClassModel testParam = GetModel();
            testParam.TableCode = null;

            TrainClass testOutput = testParam.ToTrainClass();

            Assert.IsNull(testOutput.TableCode);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
