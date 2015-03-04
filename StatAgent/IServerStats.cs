using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace StatAgent
{
    [ServiceContract()]
    public interface IServerStats
    {

        [OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Stats/{FieldName}?start={StartTime}&end={EndTime}")]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Stats?start={StartTime}&end={EndTime}")]
        List<ServerDataPoint> getAllStatsRange( string StartTime, string EndTime);

        
        [OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Stats/{FieldName}?start={StartTime}&end={EndTime}")]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Stats/{FieldName}?start={StartTime}&end={EndTime}")]
        List<ServerDataPoint> getStatsRangeForField(string FieldName, string StartTime, string EndTime);


 


    }
}
