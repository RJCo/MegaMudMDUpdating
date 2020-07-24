using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    public class MonstersMDReader<T> : MDReaderFactory<T>
        where T : Monster
    {
        public override List<T> GetAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
