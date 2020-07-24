using Records;
using System.Collections.Generic;

namespace MegaMudMDCreator
{
    internal interface IReaderFactory<T>
    {
        List<T> GetAllRecords();
    }
}