﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class TimetableDocumentTemplateModelExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimetableDocumentTemplateModelExtensionsClass_ToDocumentTemplateMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TimetableDocumentTemplateModel testObject = null;

            _ = testObject.ToDocumentTemplate();

            Assert.Fail();
        }

        [TestMethod]
        public void TimetableDocumentTemplateModelExtensionsClass_ToDocumentTemplateMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TimetableDocumentTemplateModel testObject = null;

            try
            {
                _ = testObject.ToDocumentTemplate();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
