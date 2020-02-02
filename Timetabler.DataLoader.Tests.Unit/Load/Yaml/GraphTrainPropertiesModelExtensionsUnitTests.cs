using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class GraphTrainPropertiesModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static readonly string[] _validDashStyles = { "Solid", "Dash", "Dot", "DashDot", "DashDotDot", "Custom" };

        private static GraphTrainPropertiesModel GetModel()
        {
            int colour = _rnd.Next();
            return new GraphTrainPropertiesModel
            {
                Colour = colour.ToString("X8", CultureInfo.InvariantCulture),
                Width = _rnd.NextNullableFloat(5f),
                DashStyleName = _rnd.NextPotentiallyValidString(_validDashStyles),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GraphTrainPropertiesModelExtensionsClass_ToGraphTrainPropertiesMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            GraphTrainPropertiesModel testParam = null;

            testParam.ToGraphTrainProperties();

            Assert.Fail();
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
