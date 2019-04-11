using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Timetabler.XmlData.Tests.Unit.Legacy.V2
{
    [TestClass]
    public class TrainModelUnitTests
    {
        [TestMethod]
        public void TrainModelClassIsPublic()
        {
            Assert.IsTrue(typeof(XmlData.Legacy.V2.TrainModel).IsPublic);
        }

        [TestMethod]
        public void TrainModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(XmlData.Legacy.V2.TrainModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }
    }
}
