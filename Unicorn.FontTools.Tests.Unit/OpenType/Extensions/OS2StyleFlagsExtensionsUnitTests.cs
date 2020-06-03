using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.Tests.Unit.TestHelpers;

namespace Unicorn.FontTools.Tests.Unit.OpenType.Extensions
{
    [TestClass]
    public class OS2StyleFlagsExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithSymbolicBitSet_IfSecondParameterIsTrue()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = true;
            bool testParam2 = _rnd.NextBoolean();

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual(FontDescriptorFlags.Symbolic, testOutput & FontDescriptorFlags.Symbolic);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithNonsymbolicBitNotSet_IfSecondParameterIsTrue()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = true;
            bool testParam2 = _rnd.NextBoolean();

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual((FontDescriptorFlags)0, testOutput & FontDescriptorFlags.Nonsymbolic);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithNonsymbolicBitSet_IfSecondParameterIsFalse()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = false;
            bool testParam2 = _rnd.NextBoolean();

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual(FontDescriptorFlags.Nonsymbolic, testOutput & FontDescriptorFlags.Nonsymbolic);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithSymbolicBitNotSet_IfSecondParameterIsFalse()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = false;
            bool testParam2 = _rnd.NextBoolean();

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual((FontDescriptorFlags)0, testOutput & FontDescriptorFlags.Symbolic);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithFixedPitchFlagSet_IfThirdParameterIsTrue()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = true;

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual(FontDescriptorFlags.FixedPitch, testOutput & FontDescriptorFlags.FixedPitch);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithFixedPitchFlagNotSet_IfThirdParameterIsFalse()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = false;

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual((FontDescriptorFlags)0, testOutput & FontDescriptorFlags.FixedPitch);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithItalicFlagSet_IfFirstParameterHasItalicFlagSetAndObliqueFlagNotSet()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            testParam0 |= OS2StyleFlags.Italic;
            testParam0 &= ~OS2StyleFlags.Oblique;
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = _rnd.NextBoolean(); ;

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual(FontDescriptorFlags.Italic, testOutput & FontDescriptorFlags.Italic);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithItalicFlagSet_IfFirstParameterHasItalicFlagNotSetAndObliqueFlagSet()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            testParam0 &= ~OS2StyleFlags.Italic;
            testParam0 |= OS2StyleFlags.Oblique;
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = _rnd.NextBoolean(); ;

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual(FontDescriptorFlags.Italic, testOutput & FontDescriptorFlags.Italic);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithItalicFlagSet_IfFirstParameterHasItalicFlagSetAndObliqueFlagSet()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            testParam0 |= OS2StyleFlags.Italic;
            testParam0 |= OS2StyleFlags.Oblique;
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = _rnd.NextBoolean(); ;

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual(FontDescriptorFlags.Italic, testOutput & FontDescriptorFlags.Italic);
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithItalicFlagNotSet_IfFirstParameterHasItalicFlagNotSetAndObliqueFlagNotSet()
        {
            OS2StyleFlags testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            testParam0 &= ~OS2StyleFlags.Italic;
            testParam0 &= ~OS2StyleFlags.Oblique;
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = _rnd.NextBoolean(); ;

            FontDescriptorFlags testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.AreEqual((FontDescriptorFlags)0, testOutput & FontDescriptorFlags.Italic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
