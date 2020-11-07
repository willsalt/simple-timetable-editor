using System;
using System.IO;

namespace Unicorn.FontTools.OpenType.Tests.Unit.Mocks
{
    internal class MockCharacterMapping : CharacterMapping
    {
        public MockCharacterMapping(PlatformId platform, ushort encoding, ushort lang) : base(platform, encoding, lang)
        {
        }

        public override void Dump(TextWriter writer)
        {
            throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);
        }

        public override ushort MapCodePoint(byte codePoint)
        {
            throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);
        }

        public override ushort MapCodePoint(ushort codePoint)
        {
            throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);
        }

        public override ushort MapCodePoint(uint codePoint)
        {
            throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);
        }
    }
}
