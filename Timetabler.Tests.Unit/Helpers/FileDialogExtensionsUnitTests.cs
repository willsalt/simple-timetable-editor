using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Timetabler.Helpers;

namespace Timetabler.Tests.Unit.Helpers
{
    [TestClass]
    public class FileDialogExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileDialogExtensionsClass_SetInitialDirectoryMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            FileDialog testObject = null;

            testObject.SetInitialDirectory();

            Assert.Fail();
        }

        [TestMethod]
        public void FileDialogExtensionsClass_SetInitialDirectoryMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            FileDialog testObject = null;

            try
            {
                testObject.SetInitialDirectory();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("fd", ex.ParamName);
            }
        }
    }
}
