using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class Record
    {
        public byte Length;
        public byte[] Data;
    }

    public enum PageType : ushort
    {
        RecordChain = 0,
        RecordIndex = 1,
        IndexIndex = 2
    }

    public abstract class Page
    {
        public abstract PageType PageType { get; }
        public ushort Count
        {
            get
            {
                return (ushort)Records.Count;
            }
        }

        public ushort FreeSpace = 0;  // TODO if we need to
        public ushort P0Pointer = 0;  // TODO if we need to
        public ushort Next = 0xFFFF;
        public ushort Previous = 0xFFFF;

        public List<Record> Records { get; } = new List<Record>();
    }

    public class RecordChain : Page
    {
        public override PageType PageType => PageType.RecordChain;
    }

    public class RecordIndex : Page
    {
        public override PageType PageType => PageType.RecordIndex;
    }

    public class IndexIndex : Page
    {
        public override PageType PageType => PageType.IndexIndex;
    }
}
