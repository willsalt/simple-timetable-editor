using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Interfaces;
using Unicorn.Interfaces.Tests.Utility.Extensions;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Structural;
using Unicorn.Writer.Tests.Unit.TestHelpers;

namespace Unicorn.Writer.Tests.Unit.Structural
{
    [TestClass]
    public class PageGraphicsUnitTests
    {
        private readonly static Random _rnd = RandomProvider.Default;

        private readonly List<double> _transformedXParameters = new List<double>();
        private readonly List<double> _transformedYParameters = new List<double>();

        private int _transformerCalls = 0;

        private double TransformParam(double val, List<double> store)
        {
            store.Add(val);
            return val * ++_transformerCalls;
        }

        private double TransformXParam(double val) => TransformParam(val, _transformedXParameters);

        private double TransformYParam(double val) => TransformParam(val, _transformedYParameters);

        [TestInitialize]
        public void Setup()
        {
            _transformerCalls = 0;
            _transformedXParameters.Clear();
            _transformedYParameters.Clear();
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PageGraphicsClass_Constructor_ThrowsArgumentNullExceptionIfFirstParameterIsNull()
        {
            PdfStream testParam0 = null;
            Func<double, double> testParam1 = TransformXParam;
            Func<double, double> testParam2 = TransformYParam;

            PageGraphics testOutput = new PageGraphics(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        // This test is to show that PageGraphics does not send out w operations unnecessarily.
        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFourDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwice()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawLine(testParam4, testParam5, testParam6, testParam7);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(1)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam4 * 5), new PdfReal(testParam5 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam6 * 7), new PdfReal(testParam7 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthParameters()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 5;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam9)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwiceWithSameFifthParameters()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);
            testObject.DrawLine(testParam5, testParam6, testParam7, testParam8, testParam4);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam5 * 5), new PdfReal(testParam6 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam7 * 7), new PdfReal(testParam8 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsSolid()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Solid;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDash()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Dash;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDot()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.Dot;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDashDot()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.DashDot;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4), new PdfReal(testParam4), new PdfReal(testParam4)), 
                PdfInteger.Zero).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnceAndSixthParameterEqualsDashDotDot()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = UniDashStyle.DashDotDot;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.LineDashPattern(new PdfArray(new PdfReal(testParam4 * 3), new PdfReal(testParam4), new PdfReal(testParam4), new PdfReal(testParam4), 
                new PdfReal(testParam4), new PdfReal(testParam4)), PdfInteger.Zero).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsSecondParameterOfConstructorWithThirdParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedXParameters.Contains(testParam2));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsThirdParameterOfConstructorWithSecondParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_CallsThirdParameterOfConstructorWithFourthParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwiceWithSameFifthAndSixthParameters()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 500;

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam4, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthAndSameSixthParameters()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 500;
            double testParam10;
            do
            {
                testParam10 = _rnd.NextDouble() * 5;
            } while (testParam10 == testParam4);

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam10, testParam5);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam10)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam10);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwiceWithSameFifthAndDifferentSixthParameters()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 500;
            UniDashStyle testParam10;
            do
            {
                testParam10 = _rnd.NextUniDashStyle();
            } while (testParam5 == testParam10);

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam4, testParam10);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands0 = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands0[0] as PdfArray, operands0[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            IPdfPrimitiveObject[] operands1 = testParam10.ToPdfObjects(testParam4);
            PdfOperator.LineDashPattern(operands1[0] as PdfArray, operands1[1] as PdfInteger).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawLineMethodWithFiveDoubleAndOneUniDashStyleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthAndSixthParameters()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            UniDashStyle testParam5 = _rnd.NextUniDashStyle();
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9 = _rnd.NextDouble() * 500;
            double testParam10;
            do
            {
                testParam10 = _rnd.NextDouble() * 5;
            } while (testParam10 == testParam4);
            UniDashStyle testParam11;
            do
            {
                testParam11 = _rnd.NextUniDashStyle();
            } while (testParam5 == testParam11);

            testObject.DrawLine(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);
            testObject.DrawLine(testParam6, testParam7, testParam8, testParam9, testParam10, testParam11);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            if (testParam5 != UniDashStyle.Solid)
            {
                IPdfPrimitiveObject[] operands = testParam5.ToPdfObjects(testParam4);
                PdfOperator.LineDashPattern(operands[0] as PdfArray, operands[1] as PdfInteger).WriteTo(expected);
            }
            PdfOperator.StartPath(new PdfReal(testParam0), new PdfReal(testParam1 * 2)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam2 * 3), new PdfReal(testParam3 * 4)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam10)).WriteTo(expected);
            IPdfPrimitiveObject[] operands1 = testParam11.ToPdfObjects(testParam10);
            PdfOperator.LineDashPattern(operands1[0] as PdfArray, operands1[1] as PdfInteger).WriteTo(expected);
            PdfOperator.StartPath(new PdfReal(testParam6 * 5), new PdfReal(testParam7 * 6)).WriteTo(expected);
            PdfOperator.AppendStraightLine(new PdfReal(testParam8 * 7), new PdfReal(testParam9 * 8)).WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(1d)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_CallsThirdParameterOfConstructorWithSumOfSecondAndFourthParameters_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1 + testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwice()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3);
            testObject.DrawRectangle(testParam4, testParam5, testParam6, testParam7);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(1d)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam4 * 3), new PdfReal((testParam5 + testParam7) * 4), new PdfReal(testParam6), new PdfReal(testParam7))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_CallsSecondParameterOfConstructorWithFirstParameter_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedXParameters.Contains(testParam0));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFiveDoubleParameters_CallsThirdParameterOfConstructorWithSumOfSecondAndFourthParameters_IfCalledOnce()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.IsTrue(_transformedYParameters.Contains(testParam1 + testParam3));
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwiceWithSameFifthParameter()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);
            testObject.DrawRectangle(testParam5, testParam6, testParam7, testParam8, testParam4);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam5 * 3), new PdfReal((testParam6 + testParam8) * 4), new PdfReal(testParam7), new PdfReal(testParam8))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        public void PageGraphicsClass_DrawRectangleMethodWithFourDoubleParameters_WritesCorrectValueToFirstParameterOfConstructor_IfCalledTwiceWithDifferentFifthParameter()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 5;
            double testParam5 = _rnd.NextDouble() * 500;
            double testParam6 = _rnd.NextDouble() * 500;
            double testParam7 = _rnd.NextDouble() * 500;
            double testParam8 = _rnd.NextDouble() * 500;
            double testParam9;
            do
            {
                testParam9 = _rnd.NextDouble() * 5;
            } while (testParam9 == testParam4);

            testObject.DrawRectangle(testParam0, testParam1, testParam2, testParam3, testParam4);
            testObject.DrawRectangle(testParam5, testParam6, testParam7, testParam8, testParam9);

            List<byte> expected = new List<byte>();
            PdfOperator.LineWidth(new PdfReal(testParam4)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam0), new PdfReal((testParam1 + testParam3) * 2), new PdfReal(testParam2), new PdfReal(testParam3))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            PdfOperator.LineWidth(new PdfReal(testParam9)).WriteTo(expected);
            PdfOperator.AppendRectangle(new PdfReal(testParam5 * 3), new PdfReal((testParam6 + testParam8) * 4), new PdfReal(testParam7), new PdfReal(testParam8))
                .WriteTo(expected);
            PdfOperator.StrokePath().WriteTo(expected);
            AssertionHelpers.AssertSameElements(expected, constrParam0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PageGraphicsClass_MeasureStringMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            IFontDescriptor testParam1 = null;

            _ = testObject.MeasureString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_CallsMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniSize expectedResult = new UniSize(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100);
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            _ = testObject.MeasureString(testParam0, testParam1);

            mockFont.Verify(f => f.MeasureString(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_PassesFirstParameterToMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniSize expectedResult = new UniSize(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100);
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            _ = testObject.MeasureString(testParam0, testParam1);

            mockFont.Verify(f => f.MeasureString(testParam0), Times.Once());
        }

        [TestMethod]
        public void PageGraphicsClass_MeasureStringMethod_ReturnsValueReturnedByMeasureStringMethodOfSecondParameter_IfSecondParameterIsNotNull()
        {
            PdfStream constrParam0 = new PdfStream(_rnd.Next(1, int.MaxValue));
            Func<double, double> constrParam1 = TransformXParam;
            Func<double, double> constrParam2 = TransformYParam;
            PageGraphics testObject = new PageGraphics(constrParam0, constrParam1, constrParam2);
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniSize expectedResult = new UniSize(_rnd.NextDouble() * 100, _rnd.NextDouble() * 100);
            Mock<IFontDescriptor> mockFont = new Mock<IFontDescriptor>();
            mockFont.Setup(f => f.MeasureString(It.IsAny<string>())).Returns(expectedResult);
            IFontDescriptor testParam1 = mockFont.Object;

            UniSize testOutput = testObject.MeasureString(testParam0, testParam1);

            Assert.AreSame(expectedResult, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
