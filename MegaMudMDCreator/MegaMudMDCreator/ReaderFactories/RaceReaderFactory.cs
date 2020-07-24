using Records;
using System;
using System.Collections.Generic;


namespace MegaMudMDCreator
{
    internal abstract class RaceReaderFactory<T> : MDReaderFactory<T>
        where T : Race
    {
        public override List<T> GetAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
