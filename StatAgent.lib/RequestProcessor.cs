using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public class RequestProcessor
    {
        public List<ServerDataPoint> ProcessQuery(string FieldName, string StartTime, string EndTime)
        {
            IStatPersist persist = StatPersistFactory.GetStatPersist();
            List<string> fields = new List<string>();
            if (string.IsNullOrEmpty(FieldName))
            {
                fields.Add("Processor");
                fields.Add("Memory");
            }
            else
                fields.Add(FieldName);
            DateTime start = DateTime.MinValue;
            DateTime.TryParse(StartTime, out start);
            DateTime end = DateTime.Now;
            if(!string.IsNullOrEmpty(EndTime))
                DateTime.TryParse(EndTime, out end);
            return persist.GetDataRecords(fields, start, end);

        }
        
    }
}
