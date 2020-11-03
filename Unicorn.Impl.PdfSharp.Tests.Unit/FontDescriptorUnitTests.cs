using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;

namespace Unicorn.Impl.PdfSharp.Tests.Unit
{
    [TestClass]
    public class FontDescriptorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static FontDescriptor GetTestObject()
        {
            return new FontDescriptor("Times", _rnd.NextDouble() * 20);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FontDescriptorClass_Constructor_SetsPointSizePropertyToValueOfSecondParameter()
        {
            string testParam0 = "Times";
            double testParam1 = _rnd.NextDouble() * 20;

            FontDescriptor testOutput = new FontDescriptor(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.PointSize);
        }

        [TestMethod]
        public void FontDescriptorClass_PreferredEncodingProperty_HasValueEqualToEncodingUnicode()
        {
            FontDescriptor testObject = GetTestObject();

            Encoding testOutput = testObject.PreferredEncoding;

            Assert.AreEqual(Encoding.Unicode, testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_BoundingBoxProperty_HasValueEqualToDefaultUniRectangle()
        {
            FontDescriptor testObject = GetTestObject();

            UniRectangle testOutput = testObject.BoundingBox;

            Assert.AreEqual(default, testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_ItalicAngleProperty_IsEqualToZero()
        {
            FontDescriptor testObject = GetTestObject();

            decimal testOutput = testObject.ItalicAngle;

            Assert.AreEqual(0m, testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_CapHeightProperty_IsEqualToZero()
        {
            FontDescriptor testObject = GetTestObject();

            decimal testOutput = testObject.CapHeight;

            Assert.AreEqual(0m, testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_VerticalStemThicknessProperty_IsEqualToZero()
        {
            FontDescriptor testObject = GetTestObject();

            decimal testOutput = testObject.VerticalStemThickness;

            Assert.AreEqual(0m, testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_RequiresFullDescriptionProperty_IsEqualToFalse()
        {
            FontDescriptor testObject = GetTestObject();

            bool testOutput = testObject.RequiresFullDescription;

            Assert.AreEqual(false, testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_RequiresEmbeddingProperty_IsEqualToFalse()
        {
            FontDescriptor testObject = GetTestObject();

            bool testOutput = testObject.RequiresEmbedding;

            Assert.AreEqual(false, testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_EmbeddingKeyProperty_IsEqualToEmptyString()
        {
            FontDescriptor testObject = GetTestObject();

            string testOutput = testObject.EmbeddingKey;

            Assert.AreEqual("", testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_EmbeddingLengthProperty_IsEqualToZero()
        {
            FontDescriptor testObject = GetTestObject();

            long testOutput = testObject.EmbeddingLength;

            Assert.AreEqual(0L, testOutput);
        }

        [TestMethod]
        public void FontDescriptorClass_EmbeddingDataProperty_HasLengthZero()
        {
            FontDescriptor testObject = GetTestObject();

            IEnumerable<byte> testOutput = testObject.EmbeddingData;

            Assert.AreEqual(0, testOutput.Count());
        }

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
            testParam0Wrapper.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()))
                .Returns(new UniTextSize(expectedResult, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000));
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            testObject.GetNormalSpaceWidth(testParam0Wrapper.Object);

            testParam0Wrapper.Verify(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()), Times.Once());
        }

        [TestMethod]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_CallsMeasureStringMethodOfParameterWithFirstParameterEqualToSpace_IfParameterIsNotNull()
        {
            Mock<IGraphicsContext> testParam0Wrapper = new Mock<IGraphicsContext>();
            double expectedResult = _rnd.NextDouble() * 1000;
            testParam0Wrapper.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()))
                .Returns(new UniTextSize(expectedResult, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000));
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            testObject.GetNormalSpaceWidth(testParam0Wrapper.Object);

            testParam0Wrapper.Verify(m => m.MeasureString(Resources.SpaceCharacter, It.IsAny<IFontDescriptor>()), Times.Once());
        }

        [TestMethod]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_CallsMeasureStringMethodOfParameterWithSecondParameterEqualToItself_IfParameterIsNotNull()
        {
            Mock<IGraphicsContext> testParam0Wrapper = new Mock<IGraphicsContext>();
            double expectedResult = _rnd.NextDouble() * 1000;
            testParam0Wrapper.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()))
                .Returns(new UniTextSize(expectedResult, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000));
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            testObject.GetNormalSpaceWidth(testParam0Wrapper.Object);

            testParam0Wrapper.Verify(m => m.MeasureString(It.IsAny<string>(), testObject), Times.Once());
        }

        [TestMethod]
        public void FontDescriptorClass_GetNormalSpaceWidthMethod_ReturnsWidthPropertyOfObjectReturnedByMeasureStringMethodOfParameter_IfParameterIsNotNull()
        {
            Mock<IGraphicsContext> testParam0Wrapper = new Mock<IGraphicsContext>();
            double expectedResult = _rnd.NextDouble() * 1000;
            testParam0Wrapper.Setup(m => m.MeasureString(It.IsAny<string>(), It.IsAny<IFontDescriptor>()))
                .Returns(new UniTextSize(expectedResult, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000));
            FontDescriptor testObject = new FontDescriptor("Times", 10);

            double testOutput = testObject.GetNormalSpaceWidth(testParam0Wrapper.Object);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void FontDescriptorClass_MeasureStringMethod_ThrowsNotImplementedException()
        {
            double constrParam1 = _rnd.NextDouble() * 20;
            FontDescriptor testObject = new FontDescriptor("Times", constrParam1);
            string testParam0 = _rnd.NextString(_rnd.Next(20));

            _ = testObject.MeasureString(testParam0);

            Assert.Fail();
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
