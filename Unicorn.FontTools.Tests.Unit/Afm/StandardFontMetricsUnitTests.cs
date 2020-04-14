using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class StandardFontMetricsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void StandardFontMetricsClass_CourierProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Courier;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierBoldProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierBold;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierBoldObliqueProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierBoldOblique;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_CourierObliqueProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.CourierOblique;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Helvetica;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaBoldProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaBold;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaBoldObliqueProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaBoldOblique;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_HelveticaObliqueProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.HelveticaOblique;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_SymbolProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.Symbol;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesBoldProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesBold;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesBoldItalicProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesBoldItalic;

            Assert.IsNotNull(testOutput);
        }


        [TestMethod]
        public void StandardFontMetricsClass_TimesItalicProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesItalic;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_TimesRomanProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.TimesRoman;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void StandardFontMetricsClass_ZapfDingbatsProperty_IsNotNull()
        {
            AfmFontMetrics testOutput = StandardFontMetrics.ZapfDingbats;

            Assert.IsNotNull(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores
    }
}
