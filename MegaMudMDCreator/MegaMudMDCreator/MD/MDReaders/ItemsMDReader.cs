using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class ItemsMDReader<T> : MDReaderFactory<T>
        where T : Item
    {
        public override List<T> GetAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
