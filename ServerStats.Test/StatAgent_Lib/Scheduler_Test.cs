using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using StatAgent;
using System.Threading.Tasks;

namespace ServerStats.Test.StatAgent_Lib
{
    [TestClass]
    public class Scheduler_Test
    {
        [TestMethod]
        public async Task RunSchedule_Test()
        {
            int i = 0;
            using (CancellationTokenSource source = new CancellationTokenSource())
            {
                Scheduler scheduler = new Scheduler();
                Action<CancellationToken> work = (t) => { i++; if (i > 3)source.Cancel(); };
                await scheduler.RunSchedule(work, 10, source.Token);
            }
            Assert.IsTrue(i == 4);
        }
    }
}
