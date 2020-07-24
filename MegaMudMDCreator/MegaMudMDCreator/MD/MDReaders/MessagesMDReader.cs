using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class MessagesMDReader<T> : MDReaderFactory<T>
        where T : Message
    {
        public override List<T> GetAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
