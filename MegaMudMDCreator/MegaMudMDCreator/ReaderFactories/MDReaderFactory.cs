using Records;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public abstract class MDReaderFactory<T> : IReaderFactory<T>
    {
        public abstract List<T> GetAllRecords();
    }
}
