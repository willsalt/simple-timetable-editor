using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Reflection;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.PdfExport.Interfaces;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class PdfExporterUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfExporterClass_ExportMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            Mock<IDocumentDescriptorFactory> mockDescriptorFactory = new Mock<IDocumentDescriptorFactory>();
            mockDescriptorFactory.Setup(f => f.ImplementationName).Returns("External");
            using (PdfExporter testObject = new PdfExporter(mockDescriptorFactory.Object))
            {
                TimetableDocument testParam0 = null;
                Stream testParam1 = new Mock<Stream>().Object;

                testObject.Export(testParam0, testParam1);
            }
            Assert.Fail();
        }

        [TestMethod]
        public void PdfExporterClass_ExportMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            Mock<IDocumentDescriptorFactory> mockDescriptorFactory = new Mock<IDocumentDescriptorFactory>();
            mockDescriptorFactory.Setup(f => f.ImplementationName).Returns("External");
            using (PdfExporter testObject = new PdfExporter(mockDescriptorFactory.Object))
            {
                TimetableDocument testParam0 = null;
                Stream testParam1 = new Mock<Stream>().Object;

                try
                {
                    testObject.Export(testParam0, testParam1);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("document", ex.ParamName);
                }
            }
        }

        [TestMethod]
        public void PdfExporterClass_OnStatusUpdateMethod_RaisesStatusUpdateEvent()
        {
            Mock<IDocumentDescriptorFactory> mockDescriptorFactory = new Mock<IDocumentDescriptorFactory>();
            mockDescriptorFactory.Setup(f => f.ImplementationName).Returns("External");
            int eventCount = 0;
            using (PdfExporter testObject = new PdfExporter(mockDescriptorFactory.Object))
            {
                testObject.StatusUpdate += (s, e) => { eventCount++; };

                MethodInfo method = testObject.GetType().GetMethod("OnStatusUpdate", BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(testObject, new object[] { _rnd.NextBoolean(), _rnd.NextDouble(), _rnd.NextString(_rnd.Next(64)) });
            }

            Assert.AreEqual(1, eventCount);
        }

        [TestMethod]
        public void PdfExporterClass_OnStatusUpdateMethod_RaisesStatusUpdateEventWithCorrectSender()
        {
            Mock<IDocumentDescriptorFactory> mockDescriptorFactory = new Mock<IDocumentDescriptorFactory>();
            mockDescriptorFactory.Setup(f => f.ImplementationName).Returns("External");
            object testSender = null;
            using (PdfExporter testObject = new PdfExporter(mockDescriptorFactory.Object))
            {
                testObject.StatusUpdate += (s, e) => { testSender = s; };

                MethodInfo method = testObject.GetType().GetMethod("OnStatusUpdate", BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(testObject, new object[] { _rnd.NextBoolean(), _rnd.NextDouble(), _rnd.NextString(_rnd.Next(64)) });

                Assert.AreSame(testObject, testSender);
            }
        }

        [TestMethod]
        public void PdfExporterClass_OnStatusUpdateMethod_RaisesStatusUpdateEventWithEventArgsWithCorrectProgressProperty()
        {
            Mock<IDocumentDescriptorFactory> mockDescriptorFactory = new Mock<IDocumentDescriptorFactory>();
            mockDescriptorFactory.Setup(f => f.ImplementationName).Returns("External");
            double expectedArg = _rnd.NextDouble();
            double capturedArg = -1d;
            using (PdfExporter testObject = new PdfExporter(mockDescriptorFactory.Object))
            {
                testObject.StatusUpdate += (s, e) => { capturedArg = e.Progress; };

                MethodInfo method = testObject.GetType().GetMethod("OnStatusUpdate", BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(testObject, new object[] { _rnd.NextBoolean(), expectedArg, _rnd.NextString(_rnd.Next(64)) });
            }

            Assert.AreEqual(expectedArg, capturedArg);
        }

        [TestMethod]
        public void PdfExporterClass_OnStatusUpdateMethod_RaisesStatusUpdateEventWithEventArgsWithCorrectStatusProperty()
        {
            Mock<IDocumentDescriptorFactory> mockDescriptorFactory = new Mock<IDocumentDescriptorFactory>();
            mockDescriptorFactory.Setup(f => f.ImplementationName).Returns("External");
            string expectedArg = _rnd.NextString(_rnd.Next(100));
            string capturedArg = null;
            using (PdfExporter testObject = new PdfExporter(mockDescriptorFactory.Object))
            {
                testObject.StatusUpdate += (s, e) => { capturedArg = e.Status; };

                MethodInfo method = testObject.GetType().GetMethod("OnStatusUpdate", BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(testObject, new object[] { _rnd.NextBoolean(), _rnd.NextDouble(), expectedArg });
            }

            Assert.AreEqual(expectedArg, capturedArg);
        }

        [TestMethod]
        public void PdfExporterClass_OnStatusUpdateMethod_RaisesStatusUpdateEventWithEventArgsWithCorrectInProgressProperty()
        {
            Mock<IDocumentDescriptorFactory> mockDescriptorFactory = new Mock<IDocumentDescriptorFactory>();
            mockDescriptorFactory.Setup(f => f.ImplementationName).Returns("External");
            bool expectedArg = _rnd.NextBoolean();
            bool capturedArg = !expectedArg;
            using (PdfExporter testObject = new PdfExporter(mockDescriptorFactory.Object))
            {
                testObject.StatusUpdate += (s, e) => { capturedArg = e.InProgress; };

                MethodInfo method = testObject.GetType().GetMethod("OnStatusUpdate", BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(testObject, new object[] { expectedArg, _rnd.NextDouble(), _rnd.NextString(_rnd.Next(64)) });
            }

            Assert.AreEqual(expectedArg, capturedArg);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
