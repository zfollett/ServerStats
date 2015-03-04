using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public interface IStatPersist
    {
        void Clear();
        void SaveDataRecord(ServerDataPoint record);
        long Count { get; }
        List<ServerDataPoint> GetDataRecords(List<string> fields, DateTime start, DateTime end);
    }
}
