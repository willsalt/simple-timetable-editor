using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;
using Timetabler.PdfExport.Extensions;
using Unicorn.Interfaces;

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
    }
}
