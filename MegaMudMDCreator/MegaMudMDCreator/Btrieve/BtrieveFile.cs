using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator.Btrieve
{
    public class BtrieveFile
    {
        private MDFileData _header;
        private List<IRecord> _records;

        private uint _currentPage;

        private string _fileName;

        public BtrieveFile(string fileName)
        {
            _currentPage = 0;
            _fileName = fileName;

            // Open file & read it in!
            // SetupHeaderInformation();
            // LoadAllRecords();
        }

        public bool Open()
        {
            throw new NotImplementedException("BtrieveFile.Open not implemented");
        }

        public void Close()
        {
            throw new NotImplementedException("BtrieveFile.Close not implemented");
        }

        private void SetupHeaderInformation()
        {
            // _header = new BtrieveFileHeader();
            throw new NotImplementedException("BtrieveFile.setupHeaderInformation not implemented");
        }

        private void LoadAllRecords()
        {
            _records = new List<IRecord>();
            throw new NotImplementedException("BtrieveFile.loadAllRecords not implemented");
        }

        //public int GetPageSize()
        //{
        //    return _header.PageSize;
        //}

        public BtrieveRecord GetRecord(int index)
        {
            throw new NotImplementedException("BtrieveFile.GetRecord not implemented");
            /*
            BTRIEVEPAGE* pPage = reinterpret_cast<BTRIEVEPAGE*>(m_pBuffer);

            // Valid index?
            if (iIndex < 0)
                return NULL;
            //@@if (iIndex > pPage->cRecords)
            //@@    return NULL;

            // Get offset
            int iOffset = iIndex * m_header.wRecSize;
            if ((m_header.wPageSize - iOffset) < m_header.wRecSize)
                return NULL;

            // Empty record?
            WORD wStatus = *((WORD*)(m_pBuffer + sizeof (BTRIEVEPAGE) + iOffset));
            if (wStatus == 0)
                return NULL;

            return m_pBuffer + sizeof (BTRIEVEPAGE) + iOffset + sizeof (WORD);
            */
        }

        //public int GetRecordSize()
        //{
        //    return _header.RecordLength;
        //}

        public bool ReadFirstPage()
        {
            _currentPage = 0;
            throw new NotImplementedException("BtrieveFile.ReadFirstPage not implemented");
            /*
            // Seek to start of data
            if (!seekAbsolute ((DWORD)m_header.wPageSize * 2))
                return false;

            // Set initial page number
            m_iPage = 0;

            return readNextPage();
            */
        }

        public bool ReadNextPage()
        {
            _currentPage++;
            throw new NotImplementedException("BtrieveFile.ReadNextPage not implemented");
            /*
            for (;;)
            {
                // Read in next page
                long lPos = getPosition();
                if (!read (m_pBuffer, m_header.wPageSize))
                    return false;

                // Increment page number
                m_iPage++;

                // Valid page record?
                BTRIEVEPAGE* pPage = reinterpret_cast<BTRIEVEPAGE*>(m_pBuffer);
                //@@@if (pPage->wPage != m_iPage)
                //@@@    continue;

                // Valid record type
                if (pPage->wUnknown1 == 0x5050)     // Index record/unused?
                    continue;
        
                // 0x4400 is a valid record in the rooms file!
                //if (pPage->wUnknown1 == 0x4400)     // Deleted record?
                //    continue;

                // It appears if the high-bit is not set, the record is not valid
                if (!(pPage->cFlags & 0x80))    // Valid record?
                {
                    if (pPage->wUnknown1 == 0x4400)
                        MessageBeep(-1);
                    continue;
                }

                // Appears to be valid!
                break;
            }

            return true;
            */
        }
    }
}
