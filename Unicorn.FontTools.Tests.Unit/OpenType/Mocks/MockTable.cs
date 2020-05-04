using System;
using System.IO;
using Unicorn.FontTools.OpenType;

namespace Unicorn.FontTools.Tests.Unit.OpenType.Mocks
{
    internal class MockTable : Table
    {
        public MockTable(Tag tag) : base(tag)
        {
        }

        public MockTable(string tag) : base(tag)
        {
        }

        public override void Dump(TextWriter writer)
        {
            throw new NotImplementedException(TestResources.OpenType_Mocks_MockTable_NotImplementedError);
        }
    }
}
