using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Providers;
using Timetabler.Data.Collections;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Collections
{
    [TestClass]
    public class SignalboxCollectionUnitTests
    {
        private static readonly Random _random = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SignalboxCollectionClass_ParameterlessConstructor_ReturnsEmptyCollection()
        {
            SignalboxCollection collection = new SignalboxCollection();

            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void SignalboxCollectionClass_ConstructorWithIEnumerableParameter_ReturnsCollectionOfCorrectSize()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);

            SignalboxCollection collection = new SignalboxCollection(testData);

            Assert.AreEqual(testData.Count, collection.Count);
        }

        [TestMethod]
        public void SignalboxCollectionClass_ConstructorWithIEnumerableParameter_ReturnsCollectionWithCorrectContents()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);

            SignalboxCollection collection = new SignalboxCollection(testData);

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], collection[i]);
            }
        }

        [TestMethod]
        public void SignalboxCollectionClass_CopyMethod_ReturnsCollectionOfCorrectSize()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            Assert.AreEqual(sourceCollection.Count, testCollection.Count);
        }

        [TestMethod]
        public void SignalboxCollectionClass_CopyMethod_ReturnsDifferentObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            Assert.AreNotSame(testCollection, sourceCollection);
        }

        [TestMethod]
        public void SignalboxCollectionClass_CopyMethod_ReturnsCollectionWhoseContentsAreDifferentObjects()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreNotSame(sourceCollection[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void SignalboxCollectionClass_CopyMethod_ReturnsCollectionWhoseContentsHaveCorrectIdProperties()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].Id, testCollection[i].Id);
            }
        }

        [TestMethod]
        public void SignalboxCollectionClass_CopyMethod_ReturnsCollectionWhoseContentsHaveCorrectCodeProperties()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].Code, testCollection[i].Code);
            }
        }

        [TestMethod]
        public void SignalboxCollectionClass_CopyMethod_ReturnsCollectionWhoseContentsHaveCorrectEditorDisplayNameProperties()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].EditorDisplayName, testCollection[i].EditorDisplayName);
            }
        }

        [TestMethod]
        public void SignalboxCollectionClass_CopyMethod_ReturnsCollectionWhoseContentsHaveCorrectExportDisplayNameProperties()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].ExportDisplayName, testCollection[i].ExportDisplayName);
            }
        }

        [TestMethod]
        public void SignalboxCollectionClass_IndexerWithIntParameter_ReturnsCorrectObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(1, 64);
            SignalboxCollection testCollection = new SignalboxCollection(testData);
            int idx = _random.Next(testData.Count);

            Signalbox testObject = testCollection[idx];

            Assert.AreSame(testData[idx], testObject);
        }

        [TestMethod]
        public void SignalboxCollectionClass_IndexerWithIntParameter_SetsCorrectObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(1, 64);
            SignalboxCollection testCollection = new SignalboxCollection(testData);
            Signalbox testObject = SignalboxHelpers.GetSignalbox();
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testObject, testCollection[idx]);
        }

        [TestMethod]
        public void SignalboxCollectionClass_IndexerWithIntParameter_RaisesSignalboxRemoveEvent_IfSetIsCalledWithDifferentObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(1, 64);
            SignalboxCollection testCollection = new SignalboxCollection(testData);
            Signalbox testObject = SignalboxHelpers.GetSignalbox();
            int invocations = 0;
            testCollection.SignalboxRemove += new Events.SignalboxEventHandler((o, e) => { invocations++; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void SignalboxCollectionClass_IndexerWithIntParameter_DoesNotRaiseSignalboxRemoveEvent_IfSetIsCalledWithSameObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(1, 64);
            SignalboxCollection testCollection = new SignalboxCollection(testData);
            int invocations = 0;
            testCollection.SignalboxRemove += new Events.SignalboxEventHandler((o, e) => { invocations++; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testData[idx];

            Assert.AreEqual(0, invocations);
        }

        [TestMethod]
        public void SignalboxCollectionClass_IndexerWithIntParameter_RaisesSignalboxRemoveEventWithCorrectSender_IfSetIsCalledWithDifferentObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(1, 64);
            SignalboxCollection testCollection = new SignalboxCollection(testData);
            Signalbox testObject = SignalboxHelpers.GetSignalbox();
            SignalboxCollection capturedSender = null;
            testCollection.SignalboxRemove += new Events.SignalboxEventHandler((o, e) => { capturedSender = o as SignalboxCollection; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testCollection, capturedSender);
        }

        [TestMethod]
        public void SignalboxCollectionClass_IndexerWithIntParameter_RaisesSignalboxRemoveEventWithCorrectEventArgs_IfSetIsCalledWithDifferenObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(1, 64);
            SignalboxCollection testCollection = new SignalboxCollection(testData);
            Signalbox testObject = SignalboxHelpers.GetSignalbox();
            Signalbox capturedBox = null;
            testCollection.SignalboxRemove += new Events.SignalboxEventHandler((o, e) => { capturedBox = e.Signalbox; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testData[idx], capturedBox);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
