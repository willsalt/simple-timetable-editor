namespace Unicorn.Writer.Interfaces
{
    public interface IPdfCrossRefTable : IPdfWriteable
    {
        int Count { get; }

        int ClaimSlot();

        void SetSlot(IPdfIndirectObject value, int offset);
    }
}
