using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatAgent;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ServerStats.Test.StatAgent_Lib
{
    [TestClass]
    public class AgentController_Test
    {
        [TestMethod]
        public async Task Start_Test()
        {
            using (AgentController controller = new AgentController())
            {
                IStatPersist persist = StatPersistFactory.GetStatPersist();
                persist.Clear();
                Assert.AreEqual(0, persist.Count);

                controller.Start(10);
                await Task.Delay(100);
                controller.Stop();
                Trace.WriteLine(string.Concat("Saved ", persist.Count, " records.  Should be about 11"));
                Assert.IsTrue(persist.Count > 0);
            }
        }
    }
}
