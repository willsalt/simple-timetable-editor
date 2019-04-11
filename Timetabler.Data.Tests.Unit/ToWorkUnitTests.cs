using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class ToWorkUnitTests
    {
        [TestMethod]
        public void ToWorkClassCopyMethodReturnsCorrectTextProperty()
        {
            Random random = new Random();
            string testText = random.NextString(random.Next(256));
            ToWork testObject = new ToWork { Text = testText };

            ToWork testResult = testObject.Copy();

            Assert.AreEqual(testText, testResult.Text);
        }

        [TestMethod]
        public void ToWorkClassCopyMethodReturnsCorrectAtTimePropertyIfAtTimeIsNull()
        {
            ToWork testObject = new ToWork { AtTime = null };

            ToWork testResult = testObject.Copy();

            Assert.IsNull(testResult.AtTime);
        }

        [TestMethod]
        public void ToWorkClassCopyMethodReturnsCorrectAtTimePropertyIfAtTimeIsNotNull()
        {
            Random random = new Random();
            TimeOfDay testTime = new TimeOfDay { AbsoluteSeconds = random.Next(86400) };
            ToWork testObject = new ToWork { AtTime = testTime };

            ToWork testResult = testObject.Copy();

            Assert.AreEqual(testTime, testResult.AtTime);
        }
    }
}
