using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Interfaces;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// Class representing a page in a PDF document.
    /// </summary>
    public class PdfPage : PdfPageTreeItem, IPageDescriptor, IPdfPage
    {
        /// <summary>
        /// The <see cref="PdfDocument" /> that contains this page.
        /// </summary>
        public PdfDocument HomeDocument { get; private set; }

        /// <summary>
        /// The size of this page.
        /// </summary>
        public PhysicalPageSize PageSize { get; private set; }

        /// <summary>
        /// The orientation of this page.
        /// </summary>
        public PageOrientation PageOrientation { get; private set; }

        /// <summary>
        /// The graphics context, for drawing.  Currently dummied out.
        /// </summary>
        public IGraphicsContext PageGraphics { get; private set; }

        /// <summary>
        /// The Y-coordinate of the top margin, in Unicorn coordinates.
        /// </summary>
        public double TopMarginPosition { get; private set; }

        /// <summary>
        /// The Y-coordinate of the bottom margin, in Unicorn coordinates.
        /// </summary>
        public double BottomMarginPosition { get; private set; }

        /// <summary>
        /// The X-coordinate of the left margin, in Unicorn coordinates.
        /// </summary>
        public double LeftMarginPosition { get; private set; }

        /// <summary>
        /// The X-coordinate of the right margin, in Unicorn coordinates.
        /// </summary>
        public double RightMarginPosition { get; private set; }

        /// <summary>
        /// The width of the usable area of the page - in other words, the distane in points between the left margin and right margin.
        /// </summary>
        public double PageAvailableWidth { get; private set; }

        /// <summary>
        /// A saved Y-coordinate.  This is used purely by client code when laying out a page.
        /// </summary>
        public double CurrentVerticalCursor { get; set; }

        private double PageHeight { get; set; }

        /// <summary>
        /// The MediaBox rectangle, representing the usable area of the page (including margins) in PDF userspace coordinates.
        /// </summary>
        public PdfRectangle MediaBox { get; private set; }

        /// <summary>
        /// The <see cref="PdfStream" /> containing the content of this page.
        /// </summary>
        public PdfStream ContentStream { get; private set; }

        private readonly PdfDictionary _fontDictionary = new PdfDictionary();

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="parent">The parent node of this page in the document page tree.</param>
        /// <param name="objectId">The indirect object ID of this page.</param>
        /// <param name="homeDocument">The <see cref="PdfDocument" /> that this page belongs to.</param>
        /// <param name="size">The paper size of this page.</param>
        /// <param name="orientation">The orientation of this page.</param>
        /// <param name="horizontalMarginProportion">The proportion of the page taken up by each of the left and right margins.</param>
        /// <param name="verticalMarginProportion">The proportion of the page taken up by each of the top and bottom margins.</param>
        /// <param name="contentStream">The <see cref="PdfStream" /> which will store the content of this page.</param>
        /// <param name="generation">The object generation number.  Defaults to zero.  As we do not currently support rewriting existing documents, 
        /// this should not be set.</param>
        public PdfPage(
            PdfPageTreeNode parent, 
            int objectId,
            PdfDocument homeDocument,
            PhysicalPageSize size, 
            PageOrientation orientation, 
            double horizontalMarginProportion, 
            double verticalMarginProportion, 
            PdfStream contentStream,
            int generation = 0) 
            : base(parent, objectId, generation)
        {
            if (parent is null)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            if (homeDocument is null)
            {
                throw new ArgumentNullException(nameof(homeDocument));
            }

            HomeDocument = homeDocument;
            PageSize = size;
            PageOrientation = orientation;

            UniSize pagePtSize = size.ToUniSize(orientation);
            PageHeight = pagePtSize.Height;
            TopMarginPosition = pagePtSize.Height * verticalMarginProportion;
            BottomMarginPosition = pagePtSize.Height - TopMarginPosition;
            LeftMarginPosition = pagePtSize.Width * horizontalMarginProportion;
            RightMarginPosition = pagePtSize.Width - LeftMarginPosition;
            PageAvailableWidth = RightMarginPosition - LeftMarginPosition;
            CurrentVerticalCursor = TopMarginPosition;
            MediaBox = size.ToPdfRectangle(orientation);
            ContentStream = contentStream;
            PageGraphics = new PageGraphics(this, contentStream, XTransformer, YTransformer);
        }

        private double XTransformer(double x) => x;

        private double YTransformer(double y) => PageHeight - y;

        /// <summary>
        /// Write this page to a <see cref="Stream" />.  This writes the page metadata, but not the content stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public override int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, MakeDictionary().WriteTo, stream);
        }

        /// <summary>
        /// Convert the metadata for this page into an array of bytes and append them to a list.
        /// </summary>
        /// <param name="list">The list to append to.</param>
        /// <returns>The number of bytes appended.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list parameter is null.</exception>
        public override int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            return Write(WriteToList, MakeDictionary().WriteTo, list);
        }

        /// <summary>
        /// Register that a font is likely to be used on this page.  If the font format supports embedding, this will register the font for embedding also.
        /// </summary>
        /// <param name="font">The font that is likely to be used on this page.</param>
        /// <returns>A <see cref="PdfFont" /> object representing the font information dictionary that will be written to the output file.  This may be the 
        /// same object returned by other calls to the <see cref="UseFont(IFontDescriptor)" /> method with the same parameter, or parameters with the same
        /// <see cref="IFontDescriptor.UnderlyingKey" /> property, including calls on other <see cref="PdfPage" /> instances.</returns>
        public PdfFont UseFont(IFontDescriptor font)
        {
            PdfFont fontObject = HomeDocument.UseFont(font);
            lock (_fontDictionary)
            {
                if (!_fontDictionary.ContainsKey(fontObject.InternalName))
                {
                    _fontDictionary.Add(fontObject.InternalName, fontObject.GetReference());
                }
            }
            return fontObject;
        }

        private PdfDictionary MakeDictionary()
        {
            PdfDictionary dictionary = new PdfDictionary();
            PdfDictionary resourceDictionary = new PdfDictionary();
            if (_fontDictionary.Count > 0)
            {
                resourceDictionary.Add(CommonPdfNames.Font, _fontDictionary);
            }
            dictionary.Add(CommonPdfNames.Type, CommonPdfNames.Page);
            dictionary.Add(CommonPdfNames.Parent, Parent.GetReference());
            dictionary.Add(CommonPdfNames.Resources, resourceDictionary);
            dictionary.Add(CommonPdfNames.MediaBox, MediaBox);
            if (ContentStream != null)
            {
                dictionary.Add(CommonPdfNames.Contents, ContentStream.GetReference());
            }
            return dictionary;
        }
    }
}
