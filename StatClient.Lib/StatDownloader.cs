using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatClient.Lib
{
    public class StatDownloader : IStatDownloader
    {
        IRestClient restClient;
        public StatDownloader(IRestClient client = null)
        {
            restClient = client;
        }
        public async Task<List<StatTableRow>> GetStats(string ServerName, DateTime start)
        {
            if (restClient == null)
            {
                restClient = new RestClient();
            }
            string responseString = await restClient.GetRequest(string.Format("http://{0}:8000/Stats?start={1}", ServerName, start));
            List<DataPoint> responceObj = await DeserializeResponse(responseString);
            SortedDictionary<DateTime, StatTableRow> lookup = new SortedDictionary<DateTime, StatTableRow>();
            foreach (var point in responceObj)
            {
                StatTableRow row = null;
                if (!lookup.TryGetValue(point.Time, out row))
                {
                    row = new StatTableRow() { Time = point.Time };
                    lookup.Add(row.Time, row);
                }
                if (point.Name == "Memory")
                    row.Memory = point.Value;
                if (point.Name == "Processor")
                    row.Processor = point.Value;
            }

            return lookup.Values.ToList();
        }

        public async Task<List<DataPoint>> DeserializeResponse(string jsonString)
        {
            List<DataPoint> responceObj = await Task.Run(() => JsonConvert.DeserializeObject<List<DataPoint>>(jsonString));
            return responceObj;
        }
    }
}
