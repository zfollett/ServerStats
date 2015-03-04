using StatClient.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerStats.Test.StatClient_Lib
{
    public class RestClientMock : IRestClient
    {
        public static string Response = @"[{'Name':'Memory','Time':'\/Date(1425420935884-0800)\/','Value':'11153'},{'Name':'Memory','Time':'\/Date(1425420936900-0800)\/','Value':'11154'}]";



        
        public async Task<string> GetRequest(string Url)
        {
            return Response;
        }
    }
}
