using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Models;

namespace Timetabler.Tests.Unit.Models
{
    [TestClass]
    public class TrainCopyFormModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private Train GetTrain()
        {
            return new Train { Id = _rnd.NextHexString(8), Headcode = _rnd.NextString(4) };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainCopyFormModelClass_FromTrainMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Train testParam = null;

            _ = TrainCopyFormModel.FromTrain(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainCopyFormModelClass_FromTrainMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Train testParam = null;

            try
            {
                _ = TrainCopyFormModel.FromTrain(testParam);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("train", ex.ParamName);
            }
        }

        [TestMethod]
        public void TrainCopyFormModelClass_FromTrainMethod_ReturnsObjectWithOffsetPropertyEqualToZero_IfParameterIsNotNull()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.AreEqual(0, testOutput.Offset);
        }

        [TestMethod]
        public void TrainCopyFormModelClass_FromTrainMethod_ReturnsObjectWithClearInlineNotesPropertyEqualToFalse_IfParameterIsNotNull()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.IsFalse(testOutput.ClearInlineNotes);
        }

        [TestMethod]
        public void TrainCopyFormModelClass_FromTrainMethod_ReturnsObjectWithAddSubtractPropertyEqualToAdd_IfParameterIsNotNull()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.AreEqual(AddSubtract.Add, testOutput.AddSubtract);
        }

        [TestMethod]
        public void TrainCopyFormModelClass_FromTrainMethod_ReturnsObjectWithCorrectTrainIdProperty_IfParameterIsNotNull()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.AreEqual(testParam.Id, testOutput.TrainId);
        }

        [TestMethod]
        public void TrainCopyFormModelClass_FromTrainMethod_ReturnsObjectWithCorrectTrainNameProperty_IfParameterIsNotNull()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.AreEqual(testParam.Headcode, testOutput.TrainName);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
