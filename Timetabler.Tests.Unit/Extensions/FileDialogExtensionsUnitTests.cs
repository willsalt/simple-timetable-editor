using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Extensions;

namespace Timetabler.Tests.Unit.Extensions
{
    [TestClass]
    public class FileDialogExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileDialogExtensionsClass_SetDirectoryAndFilenameMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            FileDialog testObject = null;
            string testParam1 = _rnd.NextString(_rnd.Next(20));

            testObject.SetDirectoryAndFilename(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void FileDialogExtensionsClass_SetDirectoryAndFilenameMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            FileDialog testObject = null;
            string testParam1 = _rnd.NextString(_rnd.Next(20));

            try
            {
                testObject.SetDirectoryAndFilename(testParam1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("fd", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
