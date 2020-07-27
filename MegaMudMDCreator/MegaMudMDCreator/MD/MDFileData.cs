using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class MDFileData
    {
        #region Header information
        /*
        char  szFiller1 [8];     // 46 43 00 00 01 00 00 00
        WORD  wPageSize;         // 00 10                    (4096) DDF page size
        WORD  wStartOffset;      // 00 40
        char  szFiller2 [8];     // FF FF FF FF FF FF FF FF
        WORD  wNumKeys;          // 01 00                    (1)    Number of keys
        WORD  wDataSize;         // 30 04                    (1072) Data   length
        WORD  wRecSize;          // 32 04                    (1074) Record length
        char  szFiller4 [2];     // 00 00
        DWORD dwRecCount;        // 00 00 00 00              (1892) No. of records
        char  szFiller5 [8];     // 00 00 FF FF 01 00 00 00
        char  szFiller6 [9];     // 03 00 00 00 00 00 00 00
        */

        private static readonly byte[] _filler1 = new byte[] { 0x46, 0x43, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
        private readonly ushort _pageSize;
        private readonly ushort _startOffset;
        private static readonly byte[] _filler2 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        private readonly ushort _numberOfKeys;
        private readonly ushort _dataLength;
        private readonly ushort _recordLength;
        private static readonly byte[] _filler4 = new byte[] { 0x00, 0x00 };
        private readonly uint _recordCount;
        private static readonly byte[] _filler5 = new byte[] { 0x00, 0x00, 0xFF, 0xFF, 0x01, 0x00, 0x00, 0x00 };
        // Note:  filler6 could be either 8 or 9 bytes in length.  Not sure yet.
        private static readonly byte[] _filler6 = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        #endregion Header information

        public string Filename { get; }
        public List<IRecord> _records;
        public ushort PageSize => _pageSize;
        public ushort RecordLength => _recordLength;

        public MDFileData(string filename, List<IRecord> records)
        {
            Filename = filename;
            _records = records;
            _pageSize = 0x1000; // TODO:  Any reason to not hardcode this at 4k?
            _startOffset = 0x4000;  // TODO:  Any reason to not hardcode this at 16k?
            _numberOfKeys = (ushort)records.Count;
            _dataLength = 0;
            _recordLength = 0;
        }

        public MDFileData(ushort pageSize, ushort startOffset, ushort numberOfKeys, ushort dataLength, ushort recordLength, ushort recordCount)
        {
            _pageSize = pageSize;
            _startOffset = startOffset;
            _numberOfKeys = numberOfKeys;
            _dataLength = dataLength;
            _recordLength = recordLength;
            _recordCount = recordCount;
        }

        public override string ToString()
        {
            return $"MDFile {Filename} has {_records.Count} items.  ";
        }

        public List<byte> ToBytes()
        {
            throw new NotImplementedException("MDFileData.ToBytes is not implemented");
        }
    }

}
