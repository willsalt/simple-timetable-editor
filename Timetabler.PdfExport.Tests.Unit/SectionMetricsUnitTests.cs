using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class SectionMetricsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SectionMetricsClass_Constructor_SetsLineWidthPropertyToValueOfParameter()
        {
            double testParam0 = _rnd.NextDouble() * 10;

            SectionMetrics testOutput = new SectionMetrics(testParam0);

            Assert.AreEqual(testParam0, testOutput.LineWidth);
        }

        [TestMethod]
        public void SectionMetricsClass_TotalHeightProperty_EqualsHeaderHeightPropertyPlusToWorkHeightPropertyPlusLocoToWorkHeightPropertyPlusTitleHeightPropertyPlusSubtitleHeightPropertyPlusLineWidthPropertyPlusHeightPropertyOfTotalSizePropertyOfMainSectionMetricsProperty()
        {
            double headerHeight = _rnd.NextDouble() * 10;
            double toWorkHeight = _rnd.NextDouble() * 10;
            double locoToWorkHeight = _rnd.NextDouble() * 10;
            double titleHeight = _rnd.NextDouble() * 10;
            double subTitleHeight = _rnd.NextDouble() * 10;
            double lineWidth = _rnd.NextDouble() * 5;
            double mainSectionMetricsHeight = _rnd.NextDouble() * 200;
            SectionMetrics testObject = new SectionMetrics(lineWidth)
            {
                HeaderHeight = headerHeight,
                ToWorkHeight = toWorkHeight,
                LocoToWorkHeight = locoToWorkHeight,
                TitleHeight = titleHeight,
                SubtitleHeight = subTitleHeight,
                LocationMetrics = new LocationBoxDimensions
                {
                    TotalSize = new UniSize(_rnd.NextDouble() * 500, mainSectionMetricsHeight)
                }
            };

            double testOutput = testObject.TotalHeight;

            double expectedValue = headerHeight + toWorkHeight + locoToWorkHeight + titleHeight + subTitleHeight + lineWidth + mainSectionMetricsHeight;
            Assert.AreEqual(expectedValue, testOutput, 0.0000000001);
        }

        [TestMethod]
        public void SectionMetricsClass_TableHeightProperty_EqualsHeaderHeightPropertyPlusHeightPropertyOfTotalSizePropertyOfMainSectionMetricsPropertyPlusToWorkHeightPropertyPlusLocoToWorkHeightProperty()
        {
            double headerHeight = _rnd.NextDouble() * 10;
            double toWorkHeight = _rnd.NextDouble() * 10;
            double locoToWorkHeight = _rnd.NextDouble() * 10;
            double titleHeight = _rnd.NextDouble() * 10;
            double subTitleHeight = _rnd.NextDouble() * 10;
            double lineWidth = _rnd.NextDouble() * 5;
            double mainSectionMetricsHeight = _rnd.NextDouble() * 200;
            SectionMetrics testObject = new SectionMetrics(lineWidth)
            {
                HeaderHeight = headerHeight,
                ToWorkHeight = toWorkHeight,
                LocoToWorkHeight = locoToWorkHeight,
                TitleHeight = titleHeight,
                SubtitleHeight = subTitleHeight,
                LocationMetrics = new LocationBoxDimensions
                {
                    TotalSize = new UniSize(_rnd.NextDouble() * 500, mainSectionMetricsHeight)
                }
            };

            double testOutput = testObject.TableHeight;

            double expectedValue = headerHeight + mainSectionMetricsHeight + toWorkHeight + locoToWorkHeight;
            Assert.AreEqual(expectedValue, testOutput, 0.0000000001);
        }

        [TestMethod]
        public void SectionMetricsClass_HeaderOffsetProperty_EqualsTitleHeightPropertyPlusSubtitleHeightProperty()
        {
            double headerHeight = _rnd.NextDouble() * 10;
            double toWorkHeight = _rnd.NextDouble() * 10;
            double locoToWorkHeight = _rnd.NextDouble() * 10;
            double titleHeight = _rnd.NextDouble() * 10;
            double subTitleHeight = _rnd.NextDouble() * 10;
            double lineWidth = _rnd.NextDouble() * 5;
            double mainSectionMetricsHeight = _rnd.NextDouble() * 200;
            SectionMetrics testObject = new SectionMetrics(lineWidth)
            {
                HeaderHeight = headerHeight,
                ToWorkHeight = toWorkHeight,
                LocoToWorkHeight = locoToWorkHeight,
                TitleHeight = titleHeight,
                SubtitleHeight = subTitleHeight,
                LocationMetrics = new LocationBoxDimensions
                {
                    TotalSize = new UniSize(_rnd.NextDouble() * 500, mainSectionMetricsHeight)
                }
            };

            double testOutput = testObject.HeaderOffset;

            double expectedValue = titleHeight + subTitleHeight;
            Assert.AreEqual(expectedValue, testOutput, 0.0000000001);
        }

        [TestMethod]
        public void SectionMetricsClass_MainSectionOffsetProperty_EqualsTitleHeightPropertyPlusSubtitleHeightPropertyPlusHeaderHeightProperty()
        {
            double headerHeight = _rnd.NextDouble() * 10;
            double toWorkHeight = _rnd.NextDouble() * 10;
            double locoToWorkHeight = _rnd.NextDouble() * 10;
            double titleHeight = _rnd.NextDouble() * 10;
            double subTitleHeight = _rnd.NextDouble() * 10;
            double lineWidth = _rnd.NextDouble() * 5;
            double mainSectionMetricsHeight = _rnd.NextDouble() * 200;
            SectionMetrics testObject = new SectionMetrics(lineWidth)
            {
                HeaderHeight = headerHeight,
                ToWorkHeight = toWorkHeight,
                LocoToWorkHeight = locoToWorkHeight,
                TitleHeight = titleHeight,
                SubtitleHeight = subTitleHeight,
                LocationMetrics = new LocationBoxDimensions
                {
                    TotalSize = new UniSize(_rnd.NextDouble() * 500, mainSectionMetricsHeight)
                }
            };

            double testOutput = testObject.MainSectionOffset;

            double expectedValue = titleHeight + subTitleHeight + headerHeight;
            Assert.AreEqual(expectedValue, testOutput, 0.0000000001);
        }

        [TestMethod]
        public void SectionMetricsClass_ToWorkOffsetProperty_EqualsTitleHeightPropertyPlusSubtitleHeightPropertyPlusHeaderHeightPropertyPlusHeightPropertyOfTotalSizePropertyOfMainSectionMetricsProperty()
        {
            double headerHeight = _rnd.NextDouble() * 10;
            double toWorkHeight = _rnd.NextDouble() * 10;
            double locoToWorkHeight = _rnd.NextDouble() * 10;
            double titleHeight = _rnd.NextDouble() * 10;
            double subTitleHeight = _rnd.NextDouble() * 10;
            double lineWidth = _rnd.NextDouble() * 5;
            double mainSectionMetricsHeight = _rnd.NextDouble() * 200;
            SectionMetrics testObject = new SectionMetrics(lineWidth)
            {
                HeaderHeight = headerHeight,
                ToWorkHeight = toWorkHeight,
                LocoToWorkHeight = locoToWorkHeight,
                TitleHeight = titleHeight,
                SubtitleHeight = subTitleHeight,
                LocationMetrics = new LocationBoxDimensions
                {
                    TotalSize = new UniSize(_rnd.NextDouble() * 500, mainSectionMetricsHeight)
                }
            };

            double testOutput = testObject.ToWorkOffset;

            double expectedValue = titleHeight + subTitleHeight + headerHeight + mainSectionMetricsHeight;
            Assert.AreEqual(expectedValue, testOutput, 0.0000000001);
        }

        [TestMethod]
        public void SectionMetricsClass_MainSectionBoundingHeightProperty_EqualsSubtitleHeightPropertyPlusHeaderHeightPropertyPlusHeightPropertyOfTotalSizePropertyOfMainSectionMetricsPropertyPlusToWorkHeightPropertyPlusLocoToWorkHeightProperty()
        {
            double headerHeight = _rnd.NextDouble() * 10;
            double toWorkHeight = _rnd.NextDouble() * 10;
            double locoToWorkHeight = _rnd.NextDouble() * 10;
            double titleHeight = _rnd.NextDouble() * 10;
            double subTitleHeight = _rnd.NextDouble() * 10;
            double lineWidth = _rnd.NextDouble() * 5;
            double mainSectionMetricsHeight = _rnd.NextDouble() * 200;
            SectionMetrics testObject = new SectionMetrics(lineWidth)
            {
                HeaderHeight = headerHeight,
                ToWorkHeight = toWorkHeight,
                LocoToWorkHeight = locoToWorkHeight,
                TitleHeight = titleHeight,
                SubtitleHeight = subTitleHeight,
                LocationMetrics = new LocationBoxDimensions
                {
                    TotalSize = new UniSize(_rnd.NextDouble() * 500, mainSectionMetricsHeight)
                }
            };

            double testOutput = testObject.MainSectionBoundingHeight;

            double expectedValue = subTitleHeight + headerHeight + mainSectionMetricsHeight + toWorkHeight + locoToWorkHeight;
            Assert.AreEqual(expectedValue, testOutput, 0.0000000001);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
