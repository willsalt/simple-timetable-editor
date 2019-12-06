using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class DocumentTemplateExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DocumentTemplateExtensionsClass_ToTimetableDocumentTemplateModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            DocumentTemplate testObject = null;

            _ = testObject.ToTimetableDocumentTemplateModel();

            Assert.Fail();
        }

        [TestMethod]
        public void DocumentTemplateExtensionsClass_ToTimetableDocumentTemplateModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            DocumentTemplate testObject = null;

            try
            {
                _ = testObject.ToTimetableDocumentTemplateModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("template", ex.ParamName);
            }
        }
    }
}
