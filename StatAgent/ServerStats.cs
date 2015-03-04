using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public class ServerStats : IServerStats
    {
        public List<ServerDataPoint> getAllStatsRange( string StartTime, string EndTime)
        {
            RequestProcessor proc = new RequestProcessor();
            return proc.ProcessQuery(null, StartTime, EndTime);
        }
        public List<ServerDataPoint> getStatsRangeForField(string FieldName, string StartTime, string EndTime)
        {
            RequestProcessor proc = new RequestProcessor();
            return proc.ProcessQuery(FieldName, StartTime, EndTime);
        }

    }
}
