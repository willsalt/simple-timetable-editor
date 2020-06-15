using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Display;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class ToWorkUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ToWorkClass_CopyMethod_ReturnsCorrectTextProperty()
        {
            string testText = _rnd.NextString(_rnd.Next(256));
            ToWork testObject = new ToWork { Text = testText };

            ToWork testResult = testObject.Copy();

            Assert.AreEqual(testText, testResult.Text);
        }

        [TestMethod]
        public void ToWorkClass_CopyMethod_ReturnsCorrectAtTimeProperty_IfAtTimeIsNull()
        {
            ToWork testObject = new ToWork { AtTime = null };

            ToWork testResult = testObject.Copy();

            Assert.IsNull(testResult.AtTime);
        }

        [TestMethod]
        public void ToWorkClass_CopyMethod_ReturnsCorrectAtTimeProperty_IfAtTimeIsNotNull()
        {
            TimeOfDay testTime = _rnd.NextTimeOfDay();
            ToWork testObject = new ToWork { AtTime = testTime };

            ToWork testResult = testObject.Copy();

            Assert.AreEqual(testTime, testResult.AtTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToWorkClass_CopyToMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay() };

            testObject.CopyTo(null);

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkClass_CopyToMethod_SetsAtTimePropertyOfParameter()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };
            ToWork testTarget = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };

            testObject.CopyTo(testTarget);

            Assert.AreEqual(testObject.AtTime, testTarget.AtTime);
        }

        [TestMethod]
        public void ToWorkClass_CopyToMethod_SetsTextPropertyOfParameter()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };
            ToWork testTarget = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };

            testObject.CopyTo(testTarget);

            Assert.AreEqual(testObject.Text, testTarget.Text);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_DoesNotThrowException_IfFirstParameterIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(null, null);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsActualTimePropertyOfTargetToNull_IfTextPropertyIsSet()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64) + 1) };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.IsNull(testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsDisplayedTextPropertyOfTarget_IfTextPropertyIsSet()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = _rnd.NextString(_rnd.Next(64) + 1) };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.Text, testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsActualTimePropertyOfTarget_IfTextPropertyIsEmptyString()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.AtTime, testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsDisplayedTextPropertyOfTargetCorrectly_IfTextPropertyIsEmptyStringAndSecondParameterIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.AtTime.ToString(), testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsDisplayedTextPropertyOfTargetCorrectly_IfTextPropertyIsEmptyStringAndSecondParameterIsNotNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, new TimeDisplayFormattingStrings { TimeWithoutFootnotes = "mmHH" });

            Assert.AreEqual(testObject.AtTime.ToString("mmHH", CultureInfo.CurrentCulture), testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsActualTimePropertyOfTarget_IfTextPropertyIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.AtTime, testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsDisplayedTextPropertyOfTargetCorrectly_IfTextPropertyIsNullAndSecondParameterIsNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual(testObject.AtTime.ToString(), testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsDisplayedTextPropertyOfTargetCorrectly_IfTextPropertyIsNullAndSecondParameterIsNotNull()
        {
            ToWork testObject = new ToWork { AtTime = _rnd.NextTimeOfDay(), Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, new TimeDisplayFormattingStrings { TimeWithoutFootnotes = "mmHH" });

            Assert.AreEqual(testObject.AtTime.ToString("mmHH", CultureInfo.CurrentCulture), testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsActualTimePropertyOfTargetToNull_IfAtTimePropertyIsNullAndTextPropertyIsEmptyString()
        {
            ToWork testObject = new ToWork { AtTime = null, Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.IsNull(testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsDisplayedTextPropertyOfTargetToEmptyString_IfAtTimePropertyIsNullAndTextPropertyIsEmptyString()
        {
            ToWork testObject = new ToWork { AtTime = null, Text = "" };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual("", testTarget.DisplayedText);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsActualTimePropertyOfTargetToNull_IfAtTimePropertyIsNullAndTextPropertyIsNull()
        {
            ToWork testObject = new ToWork { AtTime = null, Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.IsNull(testTarget.ActualTime);
        }

        [TestMethod]
        public void ToWorkClass_UpdateModelMethod_SetsDisplayedTextPropertyOfTargetToEmptyString_IfAtTimePropertyIsNullAndTextPropertyIsNull()
        {
            ToWork testObject = new ToWork { AtTime = null, Text = null };
            GenericTimeModel testTarget = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(64)) };

            testObject.UpdateModel(testTarget, null);

            Assert.AreEqual("", testTarget.DisplayedText);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
