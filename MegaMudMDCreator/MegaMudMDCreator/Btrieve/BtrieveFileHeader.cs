using System;
using System.Collections.Generic;


namespace MegaMudMDCreator.Btrieve
{
    public class BtrieveFileHeader
    {
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

        private byte[] _filler1 = new byte[] { 0x46, 0x43, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
        public ushort PageSize;
        public ushort StartOffset;
        private byte[] _filler2 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        public ushort NumberOfKeys;
        public ushort DataLength;
        public ushort RecordLength;
        private byte[] _filler4 = new byte[] { 0x00, 0x00 };
        public ushort RecordCount;
        private byte[] _filler5 = new byte[] { 0x00, 0x00, 0xFF, 0xFF, 0x01, 0x00, 0x00, 0x00 };
        // Note:  filler6 could be either 8 or 9 bytes in length.  Not sure yet.
        private byte[] _filler6 = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public BtrieveFileHeader(ushort pageSize, ushort startOffset, ushort numberOfKeys,
            ushort dataLength, ushort recordLength, ushort recordCount)
        {
            PageSize = pageSize;
            StartOffset = startOffset;
            NumberOfKeys = numberOfKeys;
            DataLength = dataLength;
            RecordLength = recordLength;
            RecordCount = recordCount;
        }

        public override string ToString()
        {
            throw new NotImplementedException("BtrieveFileHeader.ToString is not implemented");
        }

        public List<byte> ToBytes()
        {
            throw new NotImplementedException("BtrieveFileHeader.ToBytes is not implemented");
        }
    }

}
