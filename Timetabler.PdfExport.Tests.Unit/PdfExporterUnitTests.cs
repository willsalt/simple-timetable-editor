using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Reflection;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.PdfExport.Interfaces;
using Unicorn.CoreTypes;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class PdfExporterUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private Mock<IDocumentDescriptorFactory> _mockDescriptorFactory;
        private Mock<IFontConfigurationProvider> _mockFontConfigurationProvider;

        [TestInitialize]
        public void SetUpTest()
        {
            Mock<IFontLoader> mockFontLoader = new Mock<IFontLoader>();
            mockFontLoader.Setup(m => m.LoadFont(It.IsAny<string>(), It.IsAny<double>())).Returns(() => new Mock<IFontDescriptor>().Object);
            _mockDescriptorFactory = new Mock<IDocumentDescriptorFactory>();
            _mockDescriptorFactory.Setup(m => m.ImplementationName).Returns("Unicorn");
            _mockDescriptorFactory.Setup(m => m.GetFontLoader()).Returns(mockFontLoader.Object);
            _mockFontConfigurationProvider = new Mock<IFontConfigurationProvider>();
            _mockFontConfigurationProvider.Setup(m => m.BasePath).Returns("fontfolder");
            _mockFontConfigurationProvider.Setup(m => m.SansBoldFace).Returns("font");
            _mockFontConfigurationProvider.Setup(m => m.SansRomanFace).Returns("font");
            _mockFontConfigurationProvider.Setup(m => m.SerifBoldFace).Returns("font");
            _mockFontConfigurationProvider.Setup(m => m.SerifBoldItalicFace).Returns("font");
            _mockFontConfigurationProvider.Setup(m => m.SerifItalicFace).Returns("font");
            _mockFontConfigurationProvider.Setup(m => m.SerifRomanFace).Returns("font");
        }

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfExporterClass_ExportMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            using (PdfExporter testObject = new PdfExporter(_mockDescriptorFactory.Object, _mockFontConfigurationProvider.Object))
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
            using (PdfExporter testObject = new PdfExporter(_mockDescriptorFactory.Object, _mockFontConfigurationProvider.Object))
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
            int eventCount = 0;
            using (PdfExporter testObject = new PdfExporter(_mockDescriptorFactory.Object, _mockFontConfigurationProvider.Object))
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
            object testSender = null;
            using (PdfExporter testObject = new PdfExporter(_mockDescriptorFactory.Object, _mockFontConfigurationProvider.Object))
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
            double expectedArg = _rnd.NextDouble();
            double capturedArg = -1d;
            using (PdfExporter testObject = new PdfExporter(_mockDescriptorFactory.Object, _mockFontConfigurationProvider.Object))
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
            string expectedArg = _rnd.NextString(_rnd.Next(100));
            string capturedArg = null;
            using (PdfExporter testObject = new PdfExporter(_mockDescriptorFactory.Object, _mockFontConfigurationProvider.Object))
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
            bool expectedArg = _rnd.NextBoolean();
            bool capturedArg = !expectedArg;
            using (PdfExporter testObject = new PdfExporter(_mockDescriptorFactory.Object, _mockFontConfigurationProvider.Object))
            {
                testObject.StatusUpdate += (s, e) => { capturedArg = e.InProgress; };

                MethodInfo method = testObject.GetType().GetMethod("OnStatusUpdate", BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(testObject, new object[] { expectedArg, _rnd.NextDouble(), _rnd.NextString(_rnd.Next(64)) });
            }

            Assert.AreEqual(expectedArg, capturedArg);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
