using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatAgent;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ServerStats.Test.StatAgent_Lib
{
    [TestClass]
    public class RequestProcessor_Test
    {
        [TestMethod]
        public async Task ProcessQuery_Test()
        {
            using (AgentController controller = new AgentController())
            {
                IStatPersist persist = StatPersistFactory.GetStatPersist();
                persist.Clear();
                Assert.AreEqual(0, persist.Count);

                controller.Start(10);
                await Task.Delay(100);
                controller.Stop();
                Assert.IsTrue(persist.Count > 0);
                RequestProcessor processor = new RequestProcessor();
                var data = processor.ProcessQuery("Processor", "3-3-2015", null);
                Trace.WriteLine(string.Concat(data.Count, " Records"));
                Assert.IsTrue(data.Count > 0,string.Format("Expected > 0 Actual: {0}",data.Count));

            }

        }
    }
}
