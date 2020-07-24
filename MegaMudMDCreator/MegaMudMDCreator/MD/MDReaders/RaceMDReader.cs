

using Records;
using System.Collections.Generic;

namespace MegaMudMDCreator
{
    public class RaceMDReader<T> : MDReaderFactory<T>
        where T : Race
    {
        public override List<T> GetAllRecords()
        {
            throw new System.NotImplementedException();
        }
    }
}
