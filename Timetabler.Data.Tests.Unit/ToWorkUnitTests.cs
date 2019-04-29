using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class ToWorkUnitTests
    {
        private static Random _rnd = new Random();

        [TestMethod]
        public void ToWorkClassCopyMethodReturnsCorrectTextProperty()
        {
            string testText = _rnd.NextString(_rnd.Next(256));
            ToWork testObject = new ToWork { Text = testText };

            ToWork testResult = testObject.Copy();

            Assert.AreEqual(testText, testResult.Text);
        }

        [TestMethod]
        public void ToWorkClassCopyMethodReturnsCorrectAtTimePropertyIfAtTimeIsNull()
        {
            ToWork testObject = new ToWork { AtTime = null };

            ToWork testResult = testObject.Copy();

            Assert.IsNull(testResult.AtTime);
        }

        [TestMethod]
        public void ToWorkClassCopyMethodReturnsCorrectAtTimePropertyIfAtTimeIsNotNull()
        {
            TimeOfDay testTime = _rnd.NextTimeOfDay();
            ToWork testObject = new ToWork { AtTime = testTime };

            ToWork testResult = testObject.Copy();

            Assert.AreEqual(testTime, testResult.AtTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToWorkClassCopyToMethodThrowsArgumentNullExceptionIfParameterIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay() };

            testObject.CopyTo(null);

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkClassCopyToMethodSetsAtTimePropertyOfParameter()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };
            ToWork testTarget = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };

            testObject.CopyTo(testTarget);

            Assert.AreEqual(testObject.AtTime, testTarget.AtTime);
        }

        [TestMethod]
        public void ToWorkClassCopyToMethodSetsTextPropertyOfParameter()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };
            ToWork testTarget = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };

            testObject.CopyTo(testTarget);

            Assert.AreEqual(testObject.Text, testTarget.Text);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodDoesNotThrowExceptionIfFirstParameterIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(null, null);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsActualTimePropertyOfTargetToNullIfTextPropertyIsSet()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64) + 1) };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.IsNull(testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsDisplayedTextPropertyOfTargetIfTextPropertyIsSet()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64) + 1) };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.Text, testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsActualTimePropertyOfTargetIfTextPropertyIsEmptyString()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.AtTime, testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsDisplayedTextPropertyOfTargetCorrectlyIfTextPropertyIsEmptyStringAndSecondParameterIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.AtTime.ToString(), testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsDisplayedTextPropertyOfTargetCorrectlyIfTextPropertyIsEmptyStringAndSecondParameterIsNotNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, new TimeDisplayFormattingStrings { TimeWithoutFootnotes = "mmHH" });

            Assert.AreEqual(testObject.AtTime.ToString("mmHH"), testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsActualTimePropertyOfTargetIfTextPropertyIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.AtTime, testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsDisplayedTextPropertyOfTargetCorrectlyIfTextPropertyIsNullAndSecondParameterIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.AtTime.ToString(), testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsDisplayedTextPropertyOfTargetCorrectlyIfTextPropertyIsNullAndSecondParameterIsNotNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, new TimeDisplayFormattingStrings { TimeWithoutFootnotes = "mmHH" });

            Assert.AreEqual(testObject.AtTime.ToString("mmHH"), testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsActualTimePropertyOfTargetToNullIfAtTimePropertyIsNullAndTextPropertyIsEmptyString()
        {
            ToWork testObject = new ToWork { AtTime = null, Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.IsNull(testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsDisplayedTextPropertyOfTargetToEmptyStringIfAtTimePropertyIsNullAndTextPropertyIsEmptyString()
        {
            ToWork testObject = new ToWork { AtTime = null, Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual("", testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsActualTimePropertyOfTargetToNullIfAtTimePropertyIsNullAndTextPropertyIsNull()
        {
            ToWork testObject = new ToWork { AtTime = null, Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.IsNull(testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClassUpdateModelMethodSetsDisplayedTextPropertyOfTargetToEmptyStringIfAtTimePropertyIsNullAndTextPropertyIsNull()
        {
            ToWork testObject = new ToWork { AtTime = null, Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual("", testTarget.DisplayedText);
        }
    }
}
