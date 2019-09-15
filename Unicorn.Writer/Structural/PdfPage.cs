using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Interfaces;
using Unicorn.Writer.Dummy;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    public class PdfPage : PdfPageTreeItem, IPageDescriptor
    {
        public PhysicalPageSize PageSize { get; private set; }

        public PageOrientation PageOrientation { get; private set; }

        public IGraphicsContext PageGraphics
        {
            get
            {
                return new DummyPageGraphics();
            }
        }

        public double TopMarginPosition { get; private set; }

        public double BottomMarginPosition { get; private set; }

        public double LeftMarginPosition { get; private set; }

        public double RightMarginPosition { get; private set; }

        public double PageAvailableWidth { get; private set; }

        public double CurrentVerticalCursor { get; set; }

        public PdfRectangle MediaBox { get; private set; }

        public PdfPage(
            PdfPageTreeNode parent, 
            int objectId, 
            PhysicalPageSize size, 
            PageOrientation orientation, 
            double horizontalMarginProportion, 
            double verticalMarginProportion, 
            int generation = 0) 
            : base(parent, objectId, generation)
        {
            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }

            PageSize = size;
            PageOrientation = orientation;

            UniSize pagePtSize = size.ToUniSize(orientation);
            TopMarginPosition = pagePtSize.Height * verticalMarginProportion;
            BottomMarginPosition = pagePtSize.Height - TopMarginPosition;
            LeftMarginPosition = pagePtSize.Width * horizontalMarginProportion;
            RightMarginPosition = pagePtSize.Width - LeftMarginPosition;
            PageAvailableWidth = RightMarginPosition - LeftMarginPosition;
            CurrentVerticalCursor = TopMarginPosition;
            MediaBox = size.ToPdfRectangle(orientation);
        }

        public override int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, MakeDictionary().WriteTo, stream);
        }

        public override int WriteTo(List<byte> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            return Write(WriteToList, MakeDictionary().WriteTo, list);
        }

        private PdfDictionary MakeDictionary()
        {
            PdfDictionary dictionary = new PdfDictionary();
            dictionary.Add(CommonPdfNames.Type, CommonPdfNames.Page);
            dictionary.Add(CommonPdfNames.Parent, Parent.GetReference());
            dictionary.Add(CommonPdfNames.Resources, new PdfDictionary());
            dictionary.Add(CommonPdfNames.MediaBox, MediaBox);
            return dictionary;
        }
    }
}
