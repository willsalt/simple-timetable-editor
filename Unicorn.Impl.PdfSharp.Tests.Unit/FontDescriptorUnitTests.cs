using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Providers;
using Unicorn.Interfaces;

namespace Unicorn.Impl.PdfSharp.Tests.Unit
{
    [TestClass]
    public class FontDescriptorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            IGraphicsContext testParam0 = null;
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            testObject.GetNormalSpaceWidth(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            IGraphicsContext testParam0 = null;
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            try
            {
                testObject.GetNormalSpaceWidth(testParam0);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("graphicsContext", ex.ParamName);
            }
        }

        [TestMethod]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_CallsMeasureStringMethodOfParameter_IfParameterIsNotNull()
        {
            Mock<IGraphicsContext> testParam0Wrapper = new Mock<IGraphicsContext>();
            double expectedResult = _rnd.NextDouble() * 1000;
            testParam0Wrapper.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>())).Returns(new UniSize(expectedResult, _rnd.NextDouble() * 1000));
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            testObject.GetNormalSpaceWidth(testParam0Wrapper.Object);

            testParam0Wrapper.Verify(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()), Times.Once());
        }

        [TestMethod]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_CallsMeasureStringMethodOfParameterWithFirstParameterEqualToSpace_IfParameterIsNotNull()
        {
            Mock<IGraphicsContext> testParam0Wrapper = new Mock<IGraphicsContext>();
            double expectedResult = _rnd.NextDouble() * 1000;
            testParam0Wrapper.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>())).Returns(new UniSize(expectedResult, _rnd.NextDouble() * 1000));
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            testObject.GetNormalSpaceWidth(testParam0Wrapper.Object);

            testParam0Wrapper.Verify(m => m.MeasureString(Resources.SpaceCharacter, It.IsAny<IFontDescriptor>()), Times.Once());
        }

        [TestMethod]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_CallsMeasureStringMethodOfParameterWithSecondParameterEqualToItself_IfParameterIsNotNull()
        {
            Mock<IGraphicsContext> testParam0Wrapper = new Mock<IGraphicsContext>();
            double expectedResult = _rnd.NextDouble() * 1000;
            testParam0Wrapper.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>())).Returns(new UniSize(expectedResult, _rnd.NextDouble() * 1000));
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            testObject.GetNormalSpaceWidth(testParam0Wrapper.Object);

            testParam0Wrapper.Verify(m => m.MeasureString(It.IsAny<string>(), testObject), Times.Once());
        }

        [TestMethod]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_ReturnsWidthPropertyOfObjectReturnedByMeasureStringMethodOfParameter_IfParameterIsNotNull()
        {
            Mock<IGraphicsContext> testParam0Wrapper = new Mock<IGraphicsContext>();
            double expectedResult = _rnd.NextDouble() * 1000;
            testParam0Wrapper.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>())).Returns(new UniSize(expectedResult, _rnd.NextDouble() * 1000));
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            double testOutput = testObject.GetNormalSpaceWidth(testParam0Wrapper.Object);

            Assert.AreEqual(expectedResult, testOutput);
        }
    }
}
