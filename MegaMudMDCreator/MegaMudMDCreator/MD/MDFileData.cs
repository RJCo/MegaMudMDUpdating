using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaMudMDCreator
{
    public class MDFileData
    {
        private static readonly byte[] _header = new byte[0x400];

        public string Filename { get; }
        private readonly List<byte[]> _records;

        public MDFileData(string filename, List<byte[]> records)
        {
            Filename = filename;
            _records = records;
            SetHeader();
        }

        private void SetHeader()
        {
            _header[0] = 0x4D;
            _header[1] = 0x44;
            _header[2] = 0x42;
            _header[3] = 0x32;
            _header[4] = 0x02;
        }

        public override string ToString()
        {
            return $"MDFile {Filename} has {_records.Count} items";
        }

        private byte[] GetContent()
        {
            var contents = new List<byte[]> { _header };

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

            byte[] recordCount = UshortToByteArray(currentPageRecordCount);
            Array.Reverse(recordCount);

            var pageHeaderList = new List<byte[]>
                {
                    new byte[] { 0x00, 0x00 }, // level of node - unused?  All top level nodes aka no leafs?
                    recordCount,
                    new byte[] { 0x00, 0x00 }, // [2] is placeholder for sizeRemaining
                    new byte[] { 0x00, 0x00 }, // p0 pointer - unused?
                    forwardPointer,
                    backwardPointer,
                };

            byte[] pageHeader = pageHeaderList.SelectMany(t => t).ToArray();
            ushort sizeRemaining = (ushort)(0x400 - currentPageSize - pageHeader.Length /* always 12? */);

            // Not sure we actually need page size remaining, but adding it anyway
            byte[] sizeRemain = UshortToByteArray(sizeRemaining);
            pageHeader[4] = sizeRemain[1];
            pageHeader[5] = sizeRemain[0];

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

        public void WriteToFile()
        {
            MDFileWriter.FileWriter(Filename, GetContent());
        }
    }
}
