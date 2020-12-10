using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.Data.Display;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class TimetableExportSectionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimetableExportSectionClass_Constructor_SetsDirectionPropertyToValueOfFirstParameter()
        {
            Direction testParam0 = _rnd.NextDirection();
            TimetableSectionModel testParam1 = new TimetableSectionModel(_rnd.NextDirection(), new LocationCollection());
            string testParam2 = _rnd.NextString(_rnd.Next(50));

            TimetableExportSection testOutput = new TimetableExportSection(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.Direction);
        }

        [TestMethod]
        public void TimetableExportSectionClass_Constructor_SetsSectionDataPropertyToValueOfSecondParameter()
        {
            Direction testParam0 = _rnd.NextDirection();
            TimetableSectionModel testParam1 = new TimetableSectionModel(_rnd.NextDirection(), new LocationCollection());
            string testParam2 = _rnd.NextString(_rnd.Next(50));

            TimetableExportSection testOutput = new TimetableExportSection(testParam0, testParam1, testParam2);

            Assert.AreSame(testParam1, testOutput.SectionData);
        }

        [TestMethod]
        public void TimetableExportSectionClass_Constructor_SetsLabelPropertyToValueOfThirdParameter()
        {
            Direction testParam0 = _rnd.NextDirection();
            TimetableSectionModel testParam1 = new TimetableSectionModel(_rnd.NextDirection(), new LocationCollection());
            string testParam2 = _rnd.NextString(_rnd.Next(50));

            TimetableExportSection testOutput = new TimetableExportSection(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.Label);
        }

        [TestMethod]
        public void TimetableExportSectionClass_FromDocumentMethod_ReturnsObjectWithDirectionPropertyEqualToSecondParameterOfMethod()
        {
            TimetableDocument testParam0 = new TimetableDocument
            {
                ExportOptions = new DocumentExportOptions
                {
                    DownSectionLabel = _rnd.NextString(_rnd.Next(50)),
                    UpSectionLabel = _rnd.NextString(_rnd.Next(50)),
                }
            };
            Direction testParam1 = _rnd.NextDirection();

            TimetableExportSection testOutput = TimetableExportSection.FromDocument(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Direction);
        }

        [TestMethod]
        public void TimetableExportSectionClass_FromDocumentMethod_ReturnsObjectWithSectionDataPropertySameAsDownTrainsDisplayPropertyOfFirstParameter_IfSecondParameterEqualsDown()
        {
            TimetableDocument testParam0 = new TimetableDocument
            {
                ExportOptions = new DocumentExportOptions
                {
                    DownSectionLabel = _rnd.NextString(_rnd.Next(50)),
                    UpSectionLabel = _rnd.NextString(_rnd.Next(50)),
                }
            };
            Direction testParam1 = Direction.Down;

            TimetableExportSection testOutput = TimetableExportSection.FromDocument(testParam0, testParam1);

            Assert.AreSame(testParam0.DownTrainsDisplay, testOutput.SectionData);
        }

        [TestMethod]
        public void TimetableExportSectionClass_FromDocumentMethod_ReturnsObjectWithSectionDataPropertySameAsUpTrainsDisplayPropertyOfFirstParameter_IfSecondParameterEqualsUp()
        {
            TimetableDocument testParam0 = new TimetableDocument
            {
                ExportOptions = new DocumentExportOptions
                {
                    DownSectionLabel = _rnd.NextString(_rnd.Next(50)),
                    UpSectionLabel = _rnd.NextString(_rnd.Next(50)),
                }
            };
            Direction testParam1 = Direction.Up;

            TimetableExportSection testOutput = TimetableExportSection.FromDocument(testParam0, testParam1);

            Assert.AreSame(testParam0.UpTrainsDisplay, testOutput.SectionData);
        }

        [TestMethod]
        public void TimetableExportSectionClass_FromDocumentMethod_ReturnsObjectWithLabelPropertyEqualToDownSectionLabelPropertyOfExportOptionsPropertyOfFirstParameter_IfSecondParameterEqualsDown()
        {
            TimetableDocument testParam0 = new TimetableDocument
            {
                ExportOptions = new DocumentExportOptions
                {
                    DownSectionLabel = _rnd.NextString(_rnd.Next(50)),
                    UpSectionLabel = _rnd.NextString(_rnd.Next(50)),
                }
            };
            Direction testParam1 = Direction.Down;

            TimetableExportSection testOutput = TimetableExportSection.FromDocument(testParam0, testParam1);

            Assert.AreSame(testParam0.ExportOptions.DownSectionLabel, testOutput.Label);
        }

        [TestMethod]
        public void TimetableExportSectionClass_FromDocumentMethod_ReturnsObjectWithLabelPropertyEqualToUpSectionLabelPropertyOfExportOptionsPropertyOfFirstParameter_IfSecondParameterEqualsUp()
        {
            TimetableDocument testParam0 = new TimetableDocument
            {
                ExportOptions = new DocumentExportOptions
                {
                    DownSectionLabel = _rnd.NextString(_rnd.Next(50)),
                    UpSectionLabel = _rnd.NextString(_rnd.Next(50)),
                }
            };
            Direction testParam1 = Direction.Up;

            TimetableExportSection testOutput = TimetableExportSection.FromDocument(testParam0, testParam1);

            Assert.AreSame(testParam0.ExportOptions.UpSectionLabel, testOutput.Label);
        }

        [TestMethod]
        public void TimetableExportSectionClass_FromDocumentMethod_ReturnsObjectWithSectionDataPropertySameAsDownTrainsDisplayPropertyOfFirstParameter_IfSecondParameterIsNotAValidDirection()
        {
            TimetableDocument testParam0 = new TimetableDocument
            {
                ExportOptions = new DocumentExportOptions
                {
                    DownSectionLabel = _rnd.NextString(_rnd.Next(50)),
                    UpSectionLabel = _rnd.NextString(_rnd.Next(50)),
                }
            };
            Direction testParam1;
            do
            {
                testParam1 = (Direction)_rnd.Next();
            } while (testParam1 == Direction.Down || testParam1 == Direction.Up);

            TimetableExportSection testOutput = TimetableExportSection.FromDocument(testParam0, testParam1);

            Assert.AreSame(testParam0.DownTrainsDisplay, testOutput.SectionData);
        }

        [TestMethod]
        public void TimetableExportSectionClass_FromDocumentMethod_ReturnsObjectWithLabelPropertyEqualToDownSectionLabelPropertyOfExportOptionsPropertyOfFirstParameter_IfSecondParameterIsNotAValidDirection()
        {
            TimetableDocument testParam0 = new TimetableDocument
            {
                ExportOptions = new DocumentExportOptions
                {
                    DownSectionLabel = _rnd.NextString(_rnd.Next(50)),
                    UpSectionLabel = _rnd.NextString(_rnd.Next(50)),
                }
            };
            Direction testParam1;
            do
            {
                testParam1 = (Direction)_rnd.Next();
            } while (testParam1 == Direction.Down || testParam1 == Direction.Up);

            TimetableExportSection testOutput = TimetableExportSection.FromDocument(testParam0, testParam1);

            Assert.AreSame(testParam0.ExportOptions.DownSectionLabel, testOutput.Label);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
