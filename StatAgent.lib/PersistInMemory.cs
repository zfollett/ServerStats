using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    public class PersistInMemory : IStatPersist
    {
        //This needs to be implimented using a thread safe structure
        //A sorted list is used here becasue it is O(1) to insert sorted data, Dictionarys are O(log(n))
        private Dictionary<string, SortedList<DateTime, ServerDataPoint>> data;

        
        public PersistInMemory(List<string> initDataTypes)
        {
            data = new Dictionary<string, SortedList<DateTime, ServerDataPoint>>();
            foreach(var key in initDataTypes)
            {
                data.Add(key, new SortedList<DateTime, ServerDataPoint>());
            }
        }
        public long Count { get; private set; }
        public void SaveDataRecord(ServerDataPoint record)
        {
            try
            {
                data[record.Name].Add(record.Time, record);
                Count++;
            }
            catch
            {
                //suppress this for now
                //error correction code should determine the duplicate key and do an update
            }
        }
        public List<ServerDataPoint> GetDataRecords(List<string> fields, DateTime start, DateTime end )
        {
            List<ServerDataPoint> selectedRanges = new List<ServerDataPoint>();
            if(start > end)
            {
                //Clearly they made a mistake in parameter order so be friendly and swap
                var t = end;
                end = start;
                start = end;
            }
            if( end == DateTime.MinValue) //This would only happen if start and end were both DateTime.Min
                end = DateTime.Now;
            foreach(var field in fields)
            {
                SortedList<DateTime, ServerDataPoint> fieldRange = null;
                if(data.TryGetValue(field, out fieldRange))
                {
                    //fieldRange.Keys is an IList<T> type which should provide a binary search 
                    //to get the index of the start and end elements, but it doesn't
                    //This would be a good opportunity for an extension method... 
                    selectedRanges.AddRange(fieldRange.Where(kvp => kvp.Key > start && kvp.Key <= end).Select(kvp => kvp.Value));
                }
            }
            return selectedRanges;
        }
        public void Clear()
        {
            foreach(var kvp in data)
            {
                kvp.Value.Clear();
            }
            Count = 0;
        }
    }
}
