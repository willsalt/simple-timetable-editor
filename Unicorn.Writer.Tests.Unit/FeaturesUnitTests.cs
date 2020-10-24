using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unicorn.Writer.Tests.Unit
{
    [TestClass]
    public class FeaturesUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FeaturesClass_StreamFeaturesProperty_DefaultValueHasAsciiEncodeBinaryStreamsFlagSet()
        {
            Assert.IsTrue(Features.StreamFeatures.HasFlag(Features.StreamFeatureFlags.AsciiEncodeBinaryStreams));
        }

        [TestMethod]
        public void FeaturesClass_StreamFeaturesProperty_DefaultValueHasCompressBinaryStreamsFlagSet()
        {
            Assert.IsTrue(Features.StreamFeatures.HasFlag(Features.StreamFeatureFlags.CompressBinaryStreams));
        }

        [TestMethod]
        public void FeaturesClass_StreamFeaturesProperty_DefaultValueHasCompressPageContentStreamsFlagSet()
        {
            Assert.IsTrue(Features.StreamFeatures.HasFlag(Features.StreamFeatureFlags.CompressPageContentStreams));
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
