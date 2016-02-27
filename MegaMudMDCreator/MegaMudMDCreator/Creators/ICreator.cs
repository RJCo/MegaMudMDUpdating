using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMudMDCreator {
    public interface ICreator {
        IEnumerable<IMDFileRecord> GetAllRecords();
    }
}
