using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public interface ICreator
    {
        IEnumerable<IMDFileRecord> GetAllRecords();
    }
}
