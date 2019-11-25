using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.Primitives
{
    [TestClass]
    public class CommonPdfNamesUnitTests
    {
        [TestMethod]
        public void CommonPdfNamesClass_CatalogField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Catalog;

            Assert.AreEqual("Catalog", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_CountField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Count;

            Assert.AreEqual("Count", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_KidsField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Kids;

            Assert.AreEqual("Kids", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_LengthField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Length;

            Assert.AreEqual("Length", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_MediaBoxField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.MediaBox;

            Assert.AreEqual("MediaBox", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_PageField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Page;

            Assert.AreEqual("Page", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_PagesField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Pages;

            Assert.AreEqual("Pages", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_ParentField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Parent;

            Assert.AreEqual("Parent", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_ResourcesField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Resources;

            Assert.AreEqual("Resources", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_RootField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Root;

            Assert.AreEqual("Root", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_SizeField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Size;

            Assert.AreEqual("Size", testOutput.Value);
        }

        [TestMethod]
        public void CommonPdfNamesClass_TypeField_HasCorrectValueProperty()
        {
            PdfName testOutput = CommonPdfNames.Type;

            Assert.AreEqual("Type", testOutput.Value);
        }
    }
}
