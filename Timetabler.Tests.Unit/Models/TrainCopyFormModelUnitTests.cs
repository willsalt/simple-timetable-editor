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
        private static Random _rnd = RandomProvider.Default;

        private Train GetTrain()
        {
            return new Train { Id = _rnd.NextHexString(8), Headcode = _rnd.NextString(4) };
        }

        [TestMethod]
        public void TrainCopyFormModelClassFromTrainMethodReturnsObjectWithOffsetPropertyEqualToZero()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.AreEqual(0, testOutput.Offset);
        }

        [TestMethod]
        public void TrainCopyFormModelClassFromTrainMethodReturnsObjectWithClearInlineNotesPropertyEqualToFalse()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.IsFalse(testOutput.ClearInlineNotes);
        }

        [TestMethod]
        public void TrainCopyFormModelClassFromTrainMethodReturnsObjectWithAddSubtractPropertyEqualToAdd()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.AreEqual(AddSubtract.Add, testOutput.AddSubtract);
        }

        [TestMethod]
        public void TrainCopyFormModelClassFromTrainMethodReturnsObjectWithCorrectTrainIdProperty()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.AreEqual(testParam.Id, testOutput.TrainId);
        }

        [TestMethod]
        public void TrainCopyFormModelClassFromTrainMethodReturnsObjectWithCorrectTrainNameProperty()
        {
            Train testParam = GetTrain();

            TrainCopyFormModel testOutput = TrainCopyFormModel.FromTrain(testParam);

            Assert.AreEqual(testParam.Headcode, testOutput.TrainName);
        }
    }
}
