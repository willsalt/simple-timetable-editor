using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Interfaces;
using Unicorn.FontTools.Tests.Unit.TestHelpers;
using Unicorn.Interfaces;

namespace Unicorn.FontTools.Tests.Unit
{
    [TestClass]
    public class OpenTypeFontDescriptorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static HorizontalHeaderTable GetHheaTable()
        {
            return new HorizontalHeaderTable(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort());
        }

        private static OS2MetricsTable GetOS2MetricsTableVersion0()
        {
            return new OS2MetricsTable(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextShort(), _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeLowerUnicodeRangeFlags(),
                _rnd.NextOpenTypeUpperUnicodeRangeFlags(), _rnd.NextOpenTypeTag(), _rnd.NextOpenTypeOS2StyleFlags(), _rnd.NextUShort(), _rnd.NextUShort());
        }

        private static OS2MetricsTable GetOS2MetricsTable()
        {
            return new OS2MetricsTable(_rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextOpenTypeEmbeddingPermissionsFlags(), _rnd.NextShort(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextShort(), _rnd.NextOpenTypeIBMFamily(), _rnd.NextOpenTypePanoseFamily(), _rnd.NextOpenTypeLowerUnicodeRangeFlags(),
                _rnd.NextOpenTypeUpperUnicodeRangeFlags(), _rnd.NextOpenTypeTag(), _rnd.NextOpenTypeOS2StyleFlags(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextOpenTypeSupportedCodePageFlags(),
                _rnd.NextShort(), _rnd.NextShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort());
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void OpenTypeFontDescriptor_Constructor_SetsPointSizePropertyToValueOfSecondParameter()
        {
            IOpenTypeFont testParam0 = new Mock<IOpenTypeFont>().Object;
            double testParam1 = _rnd.NextDouble() * 48;

            OpenTypeFontDescriptor testOutput = new OpenTypeFontDescriptor(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.PointSize);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_Constructor_SetsCalculationStylePropertyToWindows()
        {
            IOpenTypeFont testParam0 = new Mock<IOpenTypeFont>().Object;
            double testParam1 = _rnd.NextDouble() * 48;

            OpenTypeFontDescriptor testOutput = new OpenTypeFontDescriptor(testParam0, testParam1);

            Assert.AreEqual(CalculationStyle.Windows, testOutput.CalculationStyle);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_UnderlyingKeyProperty_HasValueDerivedFromFilenamePropertyOfFirstParameterOfConstructor()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            string expectedData = _rnd.NextString(_rnd.Next(1, 64));
            mockFont.Setup(f => f.Filename).Returns(expectedData);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1);

            string testOutput = testObject.UnderlyingKey;

            Assert.AreEqual($"OpenType_{expectedData}", testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Macintosh
            };

            double testOutput = testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscentProperty_HasValueDerivedFromAscenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockOs2MetricsTable.Ascender.Value / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.Ascent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Descender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Macintosh
            };

            double testOutput = testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Descender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescentProperty_HasValueDerivedFromDescenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockOs2MetricsTable.Descender.Value / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.Descent;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockHorizontalHeaderTable.Ascender - mockHorizontalHeaderTable.Descender) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Macintosh
            };

            double testOutput = testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockHorizontalHeaderTable.Ascender - mockHorizontalHeaderTable.Descender) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_InterlineSpacingProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockOs2MetricsTable.Ascender.Value - mockOs2MetricsTable.Descender.Value) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.InterlineSpacing;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_EmptyStringMetricsProperty_HasWidthPropertyEqualToZero()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockOs2MetricsTable.Ascender.Value - mockOs2MetricsTable.Descender.Value) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = _rnd.NextOpenTypeCalculationStyle(),
            };

            double testOutput = testObject.EmptyStringMetrics.Width;

            Assert.AreEqual(0d, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_EmptyStringMetricsProperty_HasTotalHeightPropertyEqualToSecondParameterOfConstructor()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 - testParam1 * (mockOs2MetricsTable.Ascender.Value - mockOs2MetricsTable.Descender.Value) / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = _rnd.NextOpenTypeCalculationStyle(),
            };

            double testOutput = testObject.EmptyStringMetrics.TotalHeight;

            Assert.AreEqual(testParam1, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = (testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits) +
                (testParam1 - testParam1 * (mockHorizontalHeaderTable.Ascender - mockHorizontalHeaderTable.Descender) / mockDesignUnits) / 2;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Macintosh
            };

            double testOutput = testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = (testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits) +
                (testParam1 - testParam1 * (mockHorizontalHeaderTable.Ascender - mockHorizontalHeaderTable.Descender) / mockDesignUnits) / 2;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_HeightAboveBaselinePropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderAndDescenderPropertiesOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = (testParam1 * mockOs2MetricsTable.Ascender.Value / mockDesignUnits) +
                (testParam1 - testParam1 * (mockOs2MetricsTable.Ascender.Value - mockOs2MetricsTable.Descender.Value) / mockDesignUnits) / 2;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.EmptyStringMetrics.HeightAboveBaseline;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Macintosh
            };

            double testOutput = testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockHorizontalHeaderTable.Ascender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_AscenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromAscenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = testParam1 * mockOs2MetricsTable.Ascender.Value / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.EmptyStringMetrics.AscenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintosh()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = -testParam1 * mockHorizontalHeaderTable.Descender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Macintosh
            };

            double testOutput = testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfHorizontalHeaderPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableDoesNotHaveAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = -testParam1 * mockHorizontalHeaderTable.Descender / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_DescenderHeightPropertyOfEmptyStringMetricsProperty_HasValueDerivedFromDescenderPropertyOfOS2MetricsPropertyOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfCalculationStylePropertyIsMacintoshAndOS2MetricsTableHasAscenderPropertyPopulated()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            HorizontalHeaderTable mockHorizontalHeaderTable = GetHheaTable();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.HorizontalHeader).Returns(mockHorizontalHeaderTable);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont testParam0 = mockFont.Object;
            double testParam1 = _rnd.NextDouble() * 48;
            double expectedValue = -testParam1 * mockOs2MetricsTable.Descender.Value / mockDesignUnits;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(testParam0, testParam1)
            {
                CalculationStyle = CalculationStyle.Windows
            };

            double testOutput = testObject.EmptyStringMetrics.DescenderHeight;

            Assert.AreEqual(expectedValue, testOutput, 0.000000001);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructor_IfOS2MetricsTableIsVersion0()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<uint>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithFirstParameterEqualToWindows_IfOS2MetricsTableIsVersion0()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(PlatformId.Windows, It.IsAny<uint>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithSecondParameterEqualTo32_IfOS2MetricsTableIsVersion0()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), 32), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_ReturnsValueDerivedFromReturnValueOfAdvanceWidthMethodOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfOS2MetricsTableIsVersion0()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTableVersion0();
            int mockDesignUnits = _rnd.Next(1, 16384);
            int mockCharacterWidth = _rnd.Next();
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            mockFont.Setup(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<uint>())).Returns(mockCharacterWidth);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;
            double expectedValue = constrParam1 * mockCharacterWidth / mockDesignUnits;

            double testOutput = testObject.GetNormalSpaceWidth(testParam0);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructor_IfOS2MetricsTableIsVersion5()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<uint>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithFirstParameterEqualToWindows_IfOS2MetricsTableIsVersion5()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(PlatformId.Windows, It.IsAny<uint>()), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_CallsAdvanceWidthMethodOfFirstParameterOfConstructorWithSecondParameterEqualToBreakCharPropertyOfOS2MetricsTable_IfOS2MetricsTableIsVersion5()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;

            _ = testObject.GetNormalSpaceWidth(testParam0);

            mockFont.Verify(f => f.AdvanceWidth(It.IsAny<PlatformId>(), mockOs2MetricsTable.BreakChar.Value), Times.Once());
        }

        [TestMethod]
        public void OpenTypeFontDescriptor_GetNormalSpaceWidthMethod_ReturnsValueDerivedFromReturnValueOfAdvanceWidthMethodOfFirstParameterOfConstructorAndSecondParameterOfConstructor_IfOS2MetricsTableIsVersion5()
        {
            Mock<IOpenTypeFont> mockFont = new Mock<IOpenTypeFont>();
            OS2MetricsTable mockOs2MetricsTable = GetOS2MetricsTable();
            int mockDesignUnits = _rnd.Next(1, 16384);
            int mockCharacterWidth = _rnd.Next();
            mockFont.Setup(f => f.DesignUnitsPerEm).Returns(mockDesignUnits);
            mockFont.Setup(f => f.OS2Metrics).Returns(mockOs2MetricsTable);
            mockFont.Setup(f => f.AdvanceWidth(It.IsAny<PlatformId>(), It.IsAny<uint>())).Returns(mockCharacterWidth);
            IOpenTypeFont constrParam0 = mockFont.Object;
            double constrParam1 = _rnd.NextDouble() * 48;
            OpenTypeFontDescriptor testObject = new OpenTypeFontDescriptor(constrParam0, constrParam1) { CalculationStyle = _rnd.NextOpenTypeCalculationStyle() };
            IGraphicsContext testParam0 = new Mock<IGraphicsContext>().Object;
            double expectedValue = constrParam1 * mockCharacterWidth / mockDesignUnits;

            double testOutput = testObject.GetNormalSpaceWidth(testParam0);

            Assert.AreEqual(expectedValue, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
