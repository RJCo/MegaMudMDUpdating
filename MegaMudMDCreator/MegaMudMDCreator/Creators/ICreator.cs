using Records;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public interface ICreator
    {
        List<IRecord> GetAllRecords();
    }
}
