using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class Record
    {
        public uint ID;
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
        private const int MAX_RECORDS_PER_PAGE = 25;  // This is the max records per page I've seen in the MD files
        private const int MAX_PAGE_DATA_LENGTH = 1012;  // 1024 minus header length which is always 12

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

        private int _totalRecordLength = 0;
        private readonly List<Record> _records = new List<Record>(MAX_RECORDS_PER_PAGE);
        public IReadOnlyList<Record> Records => _records;

        public bool TryAddRecord(Record toAdd)
        {
            if (_records.Count == MAX_RECORDS_PER_PAGE)
                return false;

            if (_totalRecordLength + toAdd.Length > MAX_PAGE_DATA_LENGTH)
                return false;

            _records.Add(toAdd);
            _totalRecordLength += toAdd.Length;
            return true;
        }

        public byte[] Serialize()
        {
            throw new NotImplementedException();
        }
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
