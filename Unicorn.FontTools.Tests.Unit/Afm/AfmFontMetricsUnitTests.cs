using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Tests.Unit.TestHelpers;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class AfmFontMetricsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsFontNamePropertyToValueOfFirstParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam00, testOutput.FontName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsFullNamePropertyToValueOfSecondParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam01, testOutput.FullName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsFamilyNamePropertyToValueOfThirdParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam02, testOutput.FamilyName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsWeightPropertyToValueOfFourthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam03, testOutput.Weight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsFontBoundingBoxPropertyToValueOfFifthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam04, testOutput.FontBoundingBox);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsVersionPropertyToValueOfSixthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam05, testOutput.Version);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsNoticePropertyToValueOfSeventhParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam06, testOutput.Notice);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsEncodingSchemePropertyToValueOfEighthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam07, testOutput.EncodingScheme);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsMappingSchemePropertyToValueOfNinthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam08, testOutput.MappingScheme);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsEscapeCharacterPropertyToValueOfTenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam09, testOutput.EscapeCharacter);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsCharacterSetPropertyToValueOfEleventhParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam10, testOutput.CharacterSet);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsCharacterCountPropertyToValueOfTwelfthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam11, testOutput.CharacterCount);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsBaseFontPropertyToValueOfThirteenthParameter_IfThirteenthParameterIsNotNull()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam12, testOutput.IsBaseFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsBaseFontPropertyToTrue_IfThirteenthParameterIsNull()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = null;
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.IsTrue(testOutput.IsBaseFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsVVectorPropertyToValueOfFourteenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam13, testOutput.VVector);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsFixedVPropertyToValueOfFifteenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam14, testOutput.IsFixedV);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsCIDFontPropertyToValueOfSixteenthParameter_IfSixteenthParameterIsNotNull()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam15, testOutput.IsCIDFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsCIDFontPropertyToFalse_IfSixteenthParameterIsNull()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = null;
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.IsFalse(testOutput.IsCIDFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsCapHeightPropertyToValueOfSeventeenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam16, testOutput.CapHeight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsXHeightPropertyToValueOfEighteenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam17, testOutput.XHeight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsAscenderPropertyToValueOfNineteenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam18, testOutput.Ascender);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsDescenderPropertyToValueOfTwentiethParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam19, testOutput.Descender);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsStdHWPropertyToValueOfTwentyFirstParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam20, testOutput.StdHW);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsStdVWPropertyToValueOfTwentySecondParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam21, testOutput.StdVW);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsDirection0MetricsPropertyToValueOfTwentyThirdParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam22, testOutput.Direction0Metrics);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsDirection1MetricsPropertyToValueOfTwentyFourthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam23, testOutput.Direction1Metrics);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            _ = AfmFontMetrics.FromLines(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterHasLengthZero()
        {
            string[] testParam = Array.Empty<string>();

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterDoesNotStartWithCorrectLine()
        {
            string openingLine;
            do
            {
                openingLine = _rnd.NextString(_rnd.Next(50));
            } while (openingLine == "StartFontMetrics");
            string[] testParam = new[] { openingLine };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterDoesNotEndWithCorrectLine()
        {
            string[] testParam = new[] { "StartFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsNonNullObject_IfParameterIsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNotNull(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
