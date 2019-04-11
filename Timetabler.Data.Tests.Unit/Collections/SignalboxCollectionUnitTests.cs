using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Timetabler.Data.Collections;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Collections
{
    [TestClass]
    public class SignalboxCollectionUnitTests
    {
        private static Random _random = new Random();

        [TestMethod]
        public void SignalboxCollectionClassParameterlessConstructorReturnsEmptyCollection()
        {
            SignalboxCollection collection = new SignalboxCollection();

            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void SignalboxCollectionClassConstructorWithIEnumerableParameterReturnsCollectionOfCorrectSize()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);

            SignalboxCollection collection = new SignalboxCollection(testData);

            Assert.AreEqual(testData.Count, collection.Count);
        }

        [TestMethod]
        public void SignalboxCollectionClassConstructorWithIEnumerableParameterReturnsCollectionWithCorrectContents()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);

            SignalboxCollection collection = new SignalboxCollection(testData);

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], collection[i]);
            }
        }

        [TestMethod]
        public void SignalboxCollectionClassCopyMethodReturnsCollectionOfCorrectSize()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            Assert.AreEqual(sourceCollection.Count, testCollection.Count);
        }

        [TestMethod]
        public void SignalboxCollectionClassCopyMethodReturnsDifferentObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(0, 64);
            SignalboxCollection sourceCollection = new SignalboxCollection(testData);

            SignalboxCollection testCollection = sourceCollection.Copy();

            Assert.AreNotSame(testCollection, sourceCollection);
        }

        [TestMethod]
        public void SignalboxCollectionClassCopyMethodReturnsCollectionWhoseContentsAreDifferentObjects()
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
        public void SignalboxCollectionClassCopyMethodReturnsCollectionWhoseContentsHaveCorrectIdProperties()
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
        public void SignalboxCollectionClassCopyMethodReturnsCollectionWhoseContentsHaveCorrectCodeProperties()
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
        public void SignalboxCollectionClassCopyMethodReturnsCollectionWhoseContentsHaveCorrectEditorDisplayNameProperties()
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
        public void SignalboxCollectionClassCopyMethodReturnsCollectionWhoseContentsHaveCorrectExportDisplayNameProperties()
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
        public void SignalboxCollectionClassIndexerWithIntParameterReturnsCorrectObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(1, 64);
            SignalboxCollection testCollection = new SignalboxCollection(testData);
            int idx = _random.Next(testData.Count);

            Signalbox testObject = testCollection[idx];

            Assert.AreSame(testData[idx], testObject);
        }

        [TestMethod]
        public void SignalboxCollectionClassIndexerWithIntParameterSetsCorrectObject()
        {
            List<Signalbox> testData = SignalboxHelpers.GetSignalboxList(1, 64);
            SignalboxCollection testCollection = new SignalboxCollection(testData);
            Signalbox testObject = SignalboxHelpers.GetSignalbox();
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testObject, testCollection[idx]);
        }

        [TestMethod]
        public void SignalboxCollectionClassIndexerWithIntParameterRaisesSignalboxRemoveEventIfSetIsCalledWithDifferentObject()
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
        public void SignalboxCollectionClassIndexerWithIntParameterDoesNotRaiseSignalboxRemoveEventIfSetIsCalledWithSameObject()
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
        public void SignalboxCollectionClassIndexerWithIntParameterRaisesSignalboxRemoveEventWithCorrectSenderIfSetIsCalledWithDifferentObject()
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
        public void SignalboxCollectionClassIndexerWithIntParameterRaisesSignalboxRemoveEventWithCorrectEventArgsIfSetIsCalledWithDifferenObject()
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
    }
}
