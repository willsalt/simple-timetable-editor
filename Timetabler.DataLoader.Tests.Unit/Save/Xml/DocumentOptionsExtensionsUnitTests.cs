using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class DocumentOptionsExtensionsUnitTests
    {
        [TestMethod]
        public void DocumentOptionsExtensionsClassToDocumentOptionsModelMethodSetsGraphEditStylePropertyToCorrectValueIfArgumentGraphEditStylePropertyEqualsFree()
        {
            DocumentOptions testObject = new DocumentOptions { GraphEditStyle = GraphEditStyle.Free };

            DocumentOptionsModel testOutput = testObject.ToDocumentOptionsModel();

            Assert.AreEqual("Free", testOutput.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsExtensionsClassToDocumentOptionsModelMethodSetsGraphEditStylePropertyToCorrectValueIfArgumentGraphEditStylePropertyEqualsPreserveSectionTimes()
        {
            DocumentOptions testObject = new DocumentOptions { GraphEditStyle = GraphEditStyle.PreserveSectionTimes };

            DocumentOptionsModel testOutput = testObject.ToDocumentOptionsModel();

            Assert.AreEqual("PreserveSectionTimes", testOutput.GraphEditStyle);
        }
    }
}
