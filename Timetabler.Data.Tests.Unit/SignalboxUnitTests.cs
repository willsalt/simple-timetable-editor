using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data.Events;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class SignalboxUnitTests
    {
        private Random _random;

        public SignalboxUnitTests()
        {
            _random = new Random();
        }

        [TestMethod]
        public void SignalboxClassSettingCodePropertyRaisesCodeChangedEvent()
        {
            string firstCode = _random.NextString(_random.Next(1, 4));
            string secondCode;
            do
            {
                secondCode = _random.NextString(_random.Next(1, 4));
            } while (firstCode == secondCode);
            int invocations = 0;
            Signalbox testObject = new Signalbox { Code = firstCode };
            testObject.CodeChanged += new SignalboxEventHandler((o, e) => { invocations++; });

            testObject.Code = secondCode;

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void SignalboxClassSettingCodePropertyRaisesCodeChangedEventWithCorrectArguments()
        {
            string firstCode = _random.NextString(_random.Next(1, 4));
            string secondCode;
            do
            {
                secondCode = _random.NextString(_random.Next(1, 4));
            } while (firstCode == secondCode);
            object lastSender = null;
            SignalboxEventArgs lastEventArgs = null;
            Signalbox testObject = new Signalbox { Code = firstCode };
            testObject.CodeChanged += new SignalboxEventHandler((o, e) => { lastSender = o; lastEventArgs = e; });

            testObject.Code = secondCode;

            Assert.AreSame(testObject, lastSender as Signalbox);
            Assert.AreSame(testObject, lastEventArgs.Signalbox);
        }

        [TestMethod]
        public void SignalboxClassSettingCodePropertyToExistingValueDoesNotRaiseCodeChangedEvent()
        {
            string code = _random.NextString(_random.Next(1, 4));
            int invocations = 0;
            Signalbox testObject = new Signalbox { Code = code };
            testObject.CodeChanged += new SignalboxEventHandler((o, e) => { invocations++; });

            testObject.Code = code;

            Assert.AreEqual(0, invocations);
        }

        [TestMethod]
        public void SignalboxClassSettingEditorDisplayNamePropertyRaisesEditorDisplayNameChangedEvent()
        {
            string firstName = _random.NextString(_random.Next(128));
            string secondName;
            do
            {
                secondName = _random.NextString(_random.Next(128));
            } while (firstName == secondName);
            int invocations = 0;
            Signalbox testObject = new Signalbox { EditorDisplayName = firstName };
            testObject.EditorDisplayNameChanged += new SignalboxEventHandler((o, e) => { invocations++; });

            testObject.EditorDisplayName = secondName;

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void SignalboxClassSettingEditorDisplayNamePropertyRaisesEditorDisplayNameChangedEventWithCorrectSenderAndArguments()
        {
            string firstName = _random.NextString(_random.Next(128));
            string secondName;
            do
            {
                secondName = _random.NextString(_random.Next(128));
            } while (firstName == secondName);
            object lastSender = null;
            SignalboxEventArgs lastEventArgs = null;
            Signalbox testObject = new Signalbox { EditorDisplayName = firstName };
            testObject.EditorDisplayNameChanged += new SignalboxEventHandler((o, e) => { lastSender = o; lastEventArgs = e; });

            testObject.EditorDisplayName = secondName;

            Assert.AreSame(testObject, lastSender as Signalbox);
            Assert.AreSame(testObject, lastEventArgs.Signalbox);
        }

        [TestMethod]
        public void SignalboxClassSettingEditorDisplayNamePropertyToExistingValueDoesNotRaiseEditorDisplayNameChangedEvent()
        {
            string name = _random.NextString(_random.Next(128));
            int invocations = 0;
            Signalbox testObject = new Signalbox { EditorDisplayName = name };
            testObject.EditorDisplayNameChanged += new SignalboxEventHandler((o, e) => { invocations++; });

            testObject.EditorDisplayName = name;

            Assert.AreEqual(0, invocations);
        }

        [TestMethod]
        public void SignalboxClassSettingExportDisplayNamePropertyRaisesExportDisplayNameChangedEvent()
        {
            string firstName = _random.NextString(_random.Next(128));
            string secondName;
            do
            {
                secondName = _random.NextString(_random.Next(128));
            } while (firstName == secondName);
            int invocations = 0;
            Signalbox testObject = new Signalbox { ExportDisplayName = firstName };
            testObject.ExportDisplayNameChanged += new SignalboxEventHandler((o, e) => { invocations++; });

            testObject.ExportDisplayName = secondName;

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void SignalboxClassSettingExportDisplayNamePropertyRaisesExportDisplayNameChangedEventWithCorrectSenderAndArguments()
        {
            string firstName = _random.NextString(_random.Next(128));
            string secondName;
            do
            {
                secondName = _random.NextString(_random.Next(128));
            } while (firstName == secondName);
            object lastSender = null;
            SignalboxEventArgs lastEventArgs = null;
            Signalbox testObject = new Signalbox { ExportDisplayName = firstName };
            testObject.ExportDisplayNameChanged += new SignalboxEventHandler((o, e) => { lastSender = o; lastEventArgs = e; });

            testObject.ExportDisplayName = secondName;

            Assert.AreSame(testObject, lastSender as Signalbox);
            Assert.AreSame(testObject, lastEventArgs.Signalbox);
        }

        [TestMethod]
        public void SignalboxClassSettingExportDisplayNamePropertyToExistingVaueDoesNotRaiseExportDisplayNameChangedEvent()
        {
            string name = _random.NextString(_random.Next(128));
            int invocations = 0;
            Signalbox testObject = new Signalbox { ExportDisplayName = name };
            testObject.ExportDisplayNameChanged += new SignalboxEventHandler((o, e) => { invocations++; });

            testObject.ExportDisplayName = name;

            Assert.AreEqual(0, invocations);
        }

        [TestMethod]
        public void SignalboxClassCopyMethodReturnsDifferentObject()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();

            Signalbox testObject = sourceObject.Copy();

            Assert.AreNotSame(sourceObject, testObject);
        }

        [TestMethod]
        public void SignalboxClassCopyMethodReturnsObjectWithCorrectIdProperty()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();

            Signalbox testObject = sourceObject.Copy();

            Assert.AreEqual(sourceObject.Id, testObject.Id);
        }

        [TestMethod]
        public void SignalboxClassCopyMethodReturnsObjectWithCorrectCodeProperty()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();

            Signalbox testObject = sourceObject.Copy();

            Assert.AreEqual(sourceObject.Code, testObject.Code);
        }

        [TestMethod]
        public void SignalboxClassCopyMethodReturnsObjectWithCorrectEditorDisplayNameProperty()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();

            Signalbox testObject = sourceObject.Copy();

            Assert.AreEqual(sourceObject.EditorDisplayName, testObject.EditorDisplayName);
        }

        [TestMethod]
        public void SignalboxClassCopyMethodReturnsObjectWithCorrectExportDisplayNameProperty()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();

            Signalbox testObject = sourceObject.Copy();

            Assert.AreEqual(sourceObject.ExportDisplayName, testObject.ExportDisplayName);
        }

        private bool AreSignalboxesCompletelyDifferent(Signalbox s1, Signalbox s2)
        {
            return s1.Id != s2.Id && s1.Code != s2.Code && s1.EditorDisplayName != s2.EditorDisplayName && s1.ExportDisplayName != s2.ExportDisplayName;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxClass_CopyToMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Signalbox testObject = SignalboxHelpers.GetSignalbox();

            testObject.CopyTo(null);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxClass_CopyToMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Signalbox testObject = SignalboxHelpers.GetSignalbox();

            try
            {
                testObject.CopyTo(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("box", ex.ParamName);
            }
        }

        [TestMethod]
        public void SignalboxClass_CopyToMethod_OverwritesIdProperty()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();
            Signalbox testObject;
            do
            {
                testObject = SignalboxHelpers.GetSignalbox();
            } while (!AreSignalboxesCompletelyDifferent(sourceObject, testObject));

            sourceObject.CopyTo(testObject);

            Assert.AreEqual(sourceObject.Id, testObject.Id);
        }

        [TestMethod]
        public void SignalboxClass_CopyToMethod_OverwritesCodeProperty()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();
            Signalbox testObject;
            do
            {
                testObject = SignalboxHelpers.GetSignalbox();
            } while (!AreSignalboxesCompletelyDifferent(sourceObject, testObject));

            sourceObject.CopyTo(testObject);

            Assert.AreEqual(sourceObject.Code, testObject.Code);
        }

        [TestMethod]
        public void SignalboxClass_CopyToMethod_OverwritesEditorDisplayNameProperty()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();
            Signalbox testObject;
            do
            {
                testObject = SignalboxHelpers.GetSignalbox();
            } while (!AreSignalboxesCompletelyDifferent(sourceObject, testObject));

            sourceObject.CopyTo(testObject);

            Assert.AreEqual(sourceObject.EditorDisplayName, testObject.EditorDisplayName);
        }

        [TestMethod]
        public void SignalboxClass_CopyToMethod_OverwritesExportDisplayNameProperty()
        {
            Signalbox sourceObject = SignalboxHelpers.GetSignalbox();
            Signalbox testObject;
            do
            {
                testObject = SignalboxHelpers.GetSignalbox();
            } while (!AreSignalboxesCompletelyDifferent(sourceObject, testObject));

            sourceObject.CopyTo(testObject);

            Assert.AreEqual(sourceObject.ExportDisplayName, testObject.ExportDisplayName);
        }
    }
}
