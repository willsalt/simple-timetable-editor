using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class DocumentOptionsExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DocumentOptionsExtensionsClass_ToDocumentOptionsModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            DocumentOptions testObject = null;

            _ = testObject.ToDocumentOptionsModel();

            Assert.Fail();
        }

        [TestMethod]
        public void DocumentOptionsExtensionsClass_ToDocumentOptionsModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            DocumentOptions testObject = null;

            try
            {
                _ = testObject.ToDocumentOptionsModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("options", ex.ParamName);
            }
        }

        [TestMethod]
        public void DocumentOptionsExtensionsClass_ToDocumentOptionsModelMethod_SetsGraphEditStylePropertyToCorrectValue_IfArgumentGraphEditStylePropertyEqualsFree()
        {
            DocumentOptions testObject = new DocumentOptions { GraphEditStyle = GraphEditStyle.Free };

            DocumentOptionsModel testOutput = testObject.ToDocumentOptionsModel();

            Assert.AreEqual("Free", testOutput.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsExtensionsClass_ToDocumentOptionsModelMethod_SetsGraphEditStylePropertyToCorrectValue_IfArgumentGraphEditStylePropertyEqualsPreserveSectionTimes()
        {
            DocumentOptions testObject = new DocumentOptions { GraphEditStyle = GraphEditStyle.PreserveSectionTimes };

            DocumentOptionsModel testOutput = testObject.ToDocumentOptionsModel();

            Assert.AreEqual("PreserveSectionTimes", testOutput.GraphEditStyle);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
