using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Tests.Unit.TestHelpers;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class TableIndexRecordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TableIndexRecordClass_Constructor_SetsTableTagPropertyToValueOfFirstParameter()
        {
            Tag testParam0 = _rnd.NextOpenTypeTag();
            uint testParam1 = _rnd.NextUInt();
            uint? testParam2 = _rnd.NextNullableUInt();
            uint testParam3 = _rnd.NextUInt();

            TableIndexRecord testOutput = new TableIndexRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam0, testOutput.TableTag);
        }

        [TestMethod]
        public void TableIndexRecordClass_Constructor_SetsChecksumPropertyToValueOfSecondParameter()
        {
            Tag testParam0 = _rnd.NextOpenTypeTag();
            uint testParam1 = _rnd.NextUInt();
            uint? testParam2 = _rnd.NextNullableUInt();
            uint testParam3 = _rnd.NextUInt();

            TableIndexRecord testOutput = new TableIndexRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam1, testOutput.Checksum);
        }

        [TestMethod]
        public void TableIndexRecordClass_Constructor_SetsOffsetPropertyToValueOfThirdParameter()
        {
            Tag testParam0 = _rnd.NextOpenTypeTag();
            uint testParam1 = _rnd.NextUInt();
            uint? testParam2 = _rnd.NextNullableUInt();
            uint testParam3 = _rnd.NextUInt();

            TableIndexRecord testOutput = new TableIndexRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.Offset);
        }

        [TestMethod]
        public void TableIndexRecordClass_Constructor_SetsLengthPropertyToValueOfFourthParameter()
        {
            Tag testParam0 = _rnd.NextOpenTypeTag();
            uint testParam1 = _rnd.NextUInt();
            uint? testParam2 = _rnd.NextNullableUInt();
            uint testParam3 = _rnd.NextUInt();

            TableIndexRecord testOutput = new TableIndexRecord(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam3, testOutput.Length);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
