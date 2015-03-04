using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatClient.Lib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerStats.Test.StatClient_Lib
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class StatDownloader_Test
    {
        [TestMethod]
        public async Task GetStats_Test()
        {
            IRestClient client = new RestClientMock();

            StatDownloader downloader = new StatDownloader(client);
            List<StatTableRow> stats = await downloader.GetStats("Localhost", DateTime.MinValue);

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Count > 0);


        }

        [TestMethod]
        public async Task DeserializeResponse_Test()
        {
            StatDownloader downloader = new StatDownloader();
            List<DataPoint> responceObj = await downloader.DeserializeResponse(RestClientMock.Response);
            Assert.IsNotNull(responceObj);
            Assert.IsTrue(responceObj.Count > 0);
        }
    }
}
