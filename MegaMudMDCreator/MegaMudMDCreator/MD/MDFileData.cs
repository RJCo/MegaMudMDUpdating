using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaMudMDCreator
{
    public class MDFileData
    {
        #region Header information
        /*
        char  szFiller1 [8];     // 4D 44 42 32 02 00 00 00
        WORD  wPageSize;         // 6A 02                    (618) DDF page size
        WORD  wStartOffset;      // 00 04
        char  szFiller2 [8];     // FF FF FF FF FF FF FF FF
        WORD  wNumKeys;          // 01 00                    (1)    Number of keys
        WORD  wDataSize;         // 30 04                    (1072) Data   length
        WORD  wRecSize;          // 32 04                    (1074) Record length
        char  szFiller4 [2];     // 00 00
        DWORD dwRecCount;        // 00 00 00 00              (1892) No. of records
        char  szFiller5 [8];     // 00 00 FF FF 01 00 00 00
        char  szFiller6 [9];     // 03 00 00 00 00 00 00 00
        */
        private static byte[] header = new byte[0x400];

        //private static readonly byte[] _filler1 = new byte[11]
        //{
        //    0x4D, 0x44, 0x42, 0x32, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00  // MDB2....
        //};

        //// private readonly ushort _pageSize; -- not needed?
        //private readonly ushort _startOffset = 0x0400;  // Definitely needed

        //private static readonly byte[] _filler2 = new byte[8] 
        //{ 
        //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 
        //};
        //private readonly ushort _numberOfKeys;
        //private readonly ushort _dataLength;
        //private readonly ushort _recordLength;
        //private static readonly byte[] _filler4 = new byte[] { 0x00, 0x00 };
        //private readonly uint _recordCount;
        //private static readonly byte[] _filler5 = new byte[] { 0x00, 0x00, 0xFF, 0xFF, 0x01, 0x00, 0x00, 0x00 };
        //// Note:  filler6 could be either 8 or 9 bytes in length.  Not sure yet.
        //private static readonly byte[] _filler6 = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //
        #endregion Header information

        public string Filename { get; }
        private List<byte[]> _records;

        //public ushort PageSize => _pageSize;
        //public ushort RecordLength => _recordLength;

        public MDFileData(string filename, List<byte[]> records)
        {
            Filename = filename;
            _records = records;
            //_pageSize = 0x1000; // TODO:  Any reason to not hardcode this at 4k?
            //_startOffset = 0x4000;  // TODO:  Any reason to not hardcode this at 16k?
            //_numberOfKeys = (ushort)records.Count;
            //_dataLength = 0;
            //_recordLength = 0;
            SetHeader();
        }

        public MDFileData(ushort pageSize, ushort startOffset, ushort numberOfKeys, ushort dataLength, ushort recordLength, ushort recordCount)
        {
            //_pageSize = pageSize;
            //_startOffset = startOffset;
            //_numberOfKeys = numberOfKeys;
            //_dataLength = dataLength;
            //_recordLength = recordLength;
            //_recordCount = recordCount;
            SetHeader();
        }

        private void SetHeader()
        {
            header[0] = 0x4D;
            header[1] = 0x44;
            header[2] = 0x42;
            header[3] = 0x32;
            header[4] = 0x02;
        }

        public override string ToString()
        {
            return $"MDFile {Filename} has {_records.Count} items";
        }

        private byte[] GetContent()
        {
            var contents = new List<byte[]> { header };

            // Page header #0:  00 00 05 00 2E 02 00 00 03 00 FF FF
            // Page header #1:  00 00 01 00 9A 03 00 00 FF FF 03 00
            // Page header #2:  01 (unused page)
            // Page header #3:  00 00 09 00 C8 00 00 00 01 00 00 00

            /*
             struct smallnode {  /* bcb node declaration * /
                INT16 smlevel;  /* level of node * / -- 0x0000 seems like all good values have
                INT16 smcount;  /* key count * / -- # of records in page
                INT16 smfree;   /* free space * / -- can just leave as 0x0000
                INT16 smp0;     /* p0 pointer * / -- can just leave as 0x0000
                INT16 smforwrd; /* forward pointer * /
                INT16 smrevrse; /* reverse pointer * /
            */
            ushort currentPageNumber = 0;
            int currentPageSize = 0;
            ushort currentPageRecordCount = 0;
            List<byte[]> page = new List<byte[]>();
            Console.WriteLine($"Record count = {_records.Count}");

            foreach (var rec in _records)
            {
                if (currentPageSize + rec.Length >= 0x400)
                {
                    HandleFullPage(contents, page, currentPageNumber, currentPageSize, currentPageRecordCount);

                    page = new List<byte[]>();
                    currentPageSize = 0;
                    currentPageRecordCount = 0;
                    currentPageNumber++;
                }

                currentPageSize += rec.Length;
                page.Add(rec);
                currentPageRecordCount++;
            }

            HandleFullPage(contents, page, currentPageNumber, currentPageSize, currentPageRecordCount, lastPage: true);

            byte[] unpaddedContents = contents.SelectMany(item => item).ToArray();
            int fullSize = ((unpaddedContents.Length / 4096) + 1) * 4096;

            byte[] fullContents = new byte[fullSize];

            Array.Copy(unpaddedContents, fullContents, unpaddedContents.Length);
            return fullContents;
        }

        private static void HandleFullPage(List<byte[]> contents, List<byte[]> page, ushort currentPage, int currentPageSize, ushort currentPageRecordCount, bool lastPage = false)
        {
            byte[] forwardPointer = (lastPage) ? UshortToByteArray(ushort.MaxValue) : UshortToByteArray((ushort)(currentPage + 1)); // FORWARD from LAST page is 0xFFFF, else next page
            byte[] backwardPointer = (currentPage == 0) ? UshortToByteArray(ushort.MaxValue) : UshortToByteArray((ushort)(currentPage - 1)); // BACKWARD from FIRST page is 0xFFFF, else last page

            Array.Reverse(forwardPointer);
            Array.Reverse(backwardPointer);

            var pageHeaderList = new List<byte[]>
                {
                    new byte[] { 0x00, },
                    UshortToByteArray(currentPageRecordCount),
                    new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00},
                    forwardPointer,
                    backwardPointer,
                };

            byte[] pageHeader = pageHeaderList.SelectMany(t => t).ToArray();

            int sizeRemaining = 0x400 - currentPageSize - pageHeader.Length;
            byte[] endOfPagePadding = new byte[sizeRemaining];
            page.Add(endOfPagePadding);

            page.Insert(0, pageHeader);
            contents.Add(page.SelectMany(t => t).ToArray());
        }

        internal static byte[] UshortToByteArray(ushort ushortValue)
        {
            byte[] shortBytes = BitConverter.GetBytes(ushortValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(shortBytes);
            byte[] result = shortBytes;
            return result;
        }

        //private byte[] GetHeader()
        //{
        //    /*
        //    char  szFiller1 [8];     // 46 43 00 00 01 00 00 00
        //    WORD  wPageSize;         // 00 10                    (4096) DDF page size
        //    WORD  wStartOffset;      // 00 40
        //    char  szFiller2 [8];     // FF FF FF FF FF FF FF FF
        //    WORD  wNumKeys;          // 01 00                    (1)    Number of keys
        //    WORD  wDataSize;         // 30 04                    (1072) Data   length
        //    WORD  wRecSize;          // 32 04                    (1074) Record length
        //    char  szFiller4 [2];     // 00 00
        //    DWORD dwRecCount;        // 00 00 00 00              (1892) No. of records
        //    char  szFiller5 [8];     // 00 00 FF FF 01 00 00 00
        //    char  szFiller6 [9];     // 03 00 00 00 00 00 00 00


        //    private static readonly byte[] _filler1 = new byte[] { 0x46, 0x43, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
        //    private readonly ushort _pageSize;
        //    private readonly ushort _startOffset;
        //    private static readonly byte[] _filler2 = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        //    private readonly ushort _numberOfKeys;
        //    private readonly ushort _dataLength;
        //    private readonly ushort _recordLength;
        //    private static readonly byte[] _filler4 = new byte[] { 0x00, 0x00 };
        //    private readonly uint _recordCount;
        //    private static readonly byte[] _filler5 = new byte[] { 0x00, 0x00, 0xFF, 0xFF, 0x01, 0x00, 0x00, 0x00 };
        //    // Note:  filler6 could be either 8 or 9 bytes in length.  Not sure yet.
        //    private static readonly byte[] _filler6 = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //    */

        //    List<byte[]> header = new List<byte[]>();

        //}

        public void WriteToFile()
        {
            MDFileWriter.FileWriter(Filename, GetContent());
        }
    }
}
