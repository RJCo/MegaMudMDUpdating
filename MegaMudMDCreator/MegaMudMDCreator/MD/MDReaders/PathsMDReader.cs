using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class PathsMDReader<T> : MDReaderFactory<T>
        where T : Paths
    {
        public override List<T> GetAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
