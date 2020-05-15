using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;
using Timetabler.PdfExport.Extensions;
using Unicorn.CoreTypes;
using Unicorn.CoreTypes.Tests.Utility.Extensions;

namespace Timetabler.PdfExport.Tests.Unit.Extensions
{
    [TestClass]
    public class TrainGraphAxisTickInfoExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TrainGraphAxisTickInfo GetTickInfo()
        {
            return new TrainGraphAxisTickInfo(_rnd.NextString(_rnd.Next(1, 10)), _rnd.NextDouble() * 1000);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            TrainGraphAxisTickInfo testObject = null;
            IGraphicsContext testParam1 = new Mock<IGraphicsContext>().Object;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            testObject.PopulateSize(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            TrainGraphAxisTickInfo testObject = null;
            IGraphicsContext testParam1 = new Mock<IGraphicsContext>().Object;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            try
            {
                testObject.PopulateSize(testParam1, testParam2);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("tickInfo", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            TrainGraphAxisTickInfo testObject = GetTickInfo();
            IGraphicsContext testParam1 = null;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            testObject.PopulateSize(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            TrainGraphAxisTickInfo testObject = GetTickInfo();
            IGraphicsContext testParam1 = null;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            try
            {
                testObject.PopulateSize(testParam1, testParam2);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("context", ex.ParamName);
            }
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_CallsMeasureStringMethodOfSecondParameter()
        {
            TrainGraphAxisTickInfo testObject = GetTickInfo();
            Mock<IGraphicsContext> mockGraphicsContext = new Mock<IGraphicsContext>();
            IGraphicsContext testParam1 = mockGraphicsContext.Object;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            testObject.PopulateSize(testParam1, testParam2);

            mockGraphicsContext.Verify(g => g.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()), Times.Once());
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_CallsMeasureStringMethodOfSecondParameterWithLabelPropertyOfFirstParameter()
        {
            TrainGraphAxisTickInfo testObject = GetTickInfo();
            Mock<IGraphicsContext> mockGraphicsContext = new Mock<IGraphicsContext>();
            IGraphicsContext testParam1 = mockGraphicsContext.Object;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            testObject.PopulateSize(testParam1, testParam2);

            mockGraphicsContext.Verify(g => g.MeasureString(testObject.Label, It.IsAny<IFontDescriptor>()), Times.Once());
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_CallsMeasureStringMethodOfSecondParameterWithThirdParameter()
        {
            TrainGraphAxisTickInfo testObject = GetTickInfo();
            Mock<IGraphicsContext> mockGraphicsContext = new Mock<IGraphicsContext>();
            IGraphicsContext testParam1 = mockGraphicsContext.Object;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            testObject.PopulateSize(testParam1, testParam2);

            mockGraphicsContext.Verify(g => g.MeasureString(It.IsAny<string>(), testParam2), Times.Once());
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_SetsWidthPropertyOfFirstParameterToWidthPropertyOfValueReturnedByMeasureStringMethodOfSecondParameter()
        {
            UniTextSize expectedData = _rnd.NextUniTextSize();
            TrainGraphAxisTickInfo testObject = GetTickInfo();
            Mock<IGraphicsContext> mockGraphicsContext = new Mock<IGraphicsContext>();
            mockGraphicsContext.Setup(g => g.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>())).Returns(expectedData);
            IGraphicsContext testParam1 = mockGraphicsContext.Object;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            testObject.PopulateSize(testParam1, testParam2);

            Assert.AreEqual(expectedData.Width, testObject.Width);
        }

        [TestMethod]
        public void TrainGraphAxisTickInfoExtensionsClass_PopulateSizeMethod_SetsHeightPropertyOfFirstParameterToTotalHeightPropertyOfValueReturnedByMeasureStringMethodOfSecondParameter()
        {
            UniTextSize expectedData = _rnd.NextUniTextSize();
            TrainGraphAxisTickInfo testObject = GetTickInfo();
            Mock<IGraphicsContext> mockGraphicsContext = new Mock<IGraphicsContext>();
            mockGraphicsContext.Setup(g => g.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>())).Returns(expectedData);
            IGraphicsContext testParam1 = mockGraphicsContext.Object;
            IFontDescriptor testParam2 = new Mock<IFontDescriptor>().Object;

            testObject.PopulateSize(testParam1, testParam2);

            Assert.AreEqual(expectedData.TotalHeight, testObject.Height);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
