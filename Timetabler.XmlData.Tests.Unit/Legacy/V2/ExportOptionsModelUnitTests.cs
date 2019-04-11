using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Timetabler.XmlData.Tests.Unit.Legacy.V2
{
    [TestClass]
    public class ExportOptionsModelUnitTests
    {
        [TestMethod]
        public void ExportOptionsModelClassIsPublic()
        {
            Assert.IsTrue(typeof(XmlData.Legacy.V2.ExportOptionsModel).IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(XmlData.Legacy.V2.ExportOptionsModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClassHasPublicDisplayLocoDiagramRowPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.ExportOptionsModel).GetProperty("DisplayLocoDiagramRow");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void ExportOptionsModelClassDisplayLocoDiagramRowPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.ExportOptionsModel).GetProperty("DisplayLocoDiagramRow").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
