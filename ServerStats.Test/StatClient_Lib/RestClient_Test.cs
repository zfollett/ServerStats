using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatClient.Lib;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ServerStats.Test.StatClient_Lib
{
    /// <summary>
    /// This is definetely something that would be tested in a seperate test suite
    /// </summary>
    [TestClass]
    public class RestClient_Test
    {
        [TestMethod]
        public async Task GetRequest_Test()
        {
            IRestClient client = new RestClient();
            string response = await client.GetRequest("http://localhost:8000/Stats/Memory?start=3-3-2015");
            Assert.IsTrue(!string.IsNullOrEmpty(response));
            Trace.WriteLine(response);
        }
    }
}
