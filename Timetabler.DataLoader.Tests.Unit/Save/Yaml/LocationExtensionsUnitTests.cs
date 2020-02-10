using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
{
    [TestClass]
    public class LocationExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            Location testParam = null;

            _ = testParam.ToYamlLocationModel();

            Assert.Fail();
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
