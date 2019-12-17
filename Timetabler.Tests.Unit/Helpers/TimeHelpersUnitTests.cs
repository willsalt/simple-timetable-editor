using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Windows.Forms;
using Tests.Utility.Providers;
using Timetabler.Helpers;
using Timetabler.Tests.Unit.TestHelpers;

namespace Timetabler.Tests.Unit.Helpers
{
    [TestClass]
    public class TimeHelpersUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeHelpersClass_ClearTimeBoxesMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            TextBox testParam0 = null;
            using (TextBox testParam1 = new TextBox())
            using (ComboBox testParam2 = new ComboBox())
            {
                TimeHelpers.ClearTimeBoxes(testParam0, testParam1, testParam2);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeHelpersClass_ClearTimeBoxesMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            TextBox testParam0 = null;
            using (TextBox testParam1 = new TextBox())
            using (ComboBox testParam2 = new ComboBox())
            {
                try
                {
                    TimeHelpers.ClearTimeBoxes(testParam0, testParam1, testParam2);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("tbHours", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeHelpersClass_ClearTimeBoxesMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            TextBox testParam1 = null;
            using (TextBox testParam0= new TextBox())
            using (ComboBox testParam2 = new ComboBox())
            {
                TimeHelpers.ClearTimeBoxes(testParam0, testParam1, testParam2);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeHelpersClass_ClearTimeBoxesMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            TextBox testParam1 = null;
            using (TextBox testParam0 = new TextBox())
            using (ComboBox testParam2 = new ComboBox())
            {
                try
                {
                    TimeHelpers.ClearTimeBoxes(testParam0, testParam1, testParam2);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("tbMinutes", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeHelpersClass_ClearTimeBoxesMethod_ThrowsArgumentNullException_IfThirdParameterIsNull()
        {
            ComboBox testParam2 = null;
            using (TextBox testParam1 = new TextBox())
            using (TextBox testParam0 = new TextBox())
            {
                TimeHelpers.ClearTimeBoxes(testParam0, testParam1, testParam2);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeHelpersClass_ClearTimeBoxesMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfThirdParameterIsNull()
        {
            ComboBox testParam2 = null;
            using (TextBox testParam1 = new TextBox())
            using (TextBox testParam0 = new TextBox())
            {
                try
                {
                    TimeHelpers.ClearTimeBoxes(testParam0, testParam1, testParam2);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("cbHalf", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeHelpersClass_SetTimePropertyMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            object testParam0 = new MockData();
            PropertyInfo testParam1 = null;
            int testParam5 = _rnd.Next();
            using (TextBox testParam2 = new TextBox())
            using (TextBox testParam3 = new TextBox())
            using (ComboBox testParam4 = new ComboBox())
            {
                TimeHelpers.SetTimeProperty(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeHelpersClass_SetTimePropertyMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            object testParam0 = new MockData();
            PropertyInfo testParam1 = null;
            int testParam5 = _rnd.Next();
            using (TextBox testParam2 = new TextBox())
            using (TextBox testParam3 = new TextBox())
            using (ComboBox testParam4 = new ComboBox())
            {
                try
                {
                    TimeHelpers.SetTimeProperty(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("prop", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeHelpersClass_SetTimePropertyMethod_ThrowsArgumentNullException_IfThirdParameterIsNull()
        {
            object testParam0 = new MockData();
            PropertyInfo testParam1 = testParam0.GetType().GetProperty("MockTimeProperty");
            TextBox testParam2 = null;
            int testParam5 = _rnd.Next();
            using (TextBox testParam3 = new TextBox())
            using (ComboBox testParam4 = new ComboBox())
            {
                TimeHelpers.SetTimeProperty(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeHelpersClass_SetTimePropertyMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfThirdParameterIsNull()
        {
            object testParam0 = new MockData();
            PropertyInfo testParam1 = testParam0.GetType().GetProperty("MockTimeProperty");
            TextBox testParam2 = null;
            int testParam5 = _rnd.Next();
            using (TextBox testParam3 = new TextBox())
            using (ComboBox testParam4 = new ComboBox())
            {
                try
                {
                    TimeHelpers.SetTimeProperty(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("tbHours", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeHelpersClass_SetTimePropertyMethod_ThrowsArgumentNullException_IfFourthParameterIsNull()
        {
            object testParam0 = new MockData();
            PropertyInfo testParam1 = testParam0.GetType().GetProperty("MockTimeProperty");
            TextBox testParam3 = null;
            int testParam5 = _rnd.Next();
            using (TextBox testParam2 = new TextBox())
            using (ComboBox testParam4 = new ComboBox())
            {
                TimeHelpers.SetTimeProperty(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeHelpersClass_SetTimePropertyMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFourthParameterIsNull()
        {
            object testParam0 = new MockData();
            PropertyInfo testParam1 = testParam0.GetType().GetProperty("MockTimeProperty");
            TextBox testParam3 = null;
            int testParam5 = _rnd.Next();
            using (TextBox testParam2 = new TextBox())
            using (ComboBox testParam4 = new ComboBox())
            {
                try
                {
                    TimeHelpers.SetTimeProperty(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("tbMinutes", ex.ParamName);
                }
            }
        }
    }
}
