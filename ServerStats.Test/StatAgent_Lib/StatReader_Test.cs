using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatAgent;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ServerStats.Test.StatAgent_Lib
{
    [TestClass]
    public class StatReader_Test 
    {
        [TestMethod]
        public void GetMemoryUse_Test()
        {
            using (StatReader stats = new StatReader())
            {
                Trace.Write(string.Concat("Memory Use: ", stats.GetMemoryUse()));
                Assert.IsTrue(stats.GetMemoryUse() > 0);
            }
        }

        [TestMethod]
        public void GetCpuUse_Test()
        {
            //This generates a lot of 0 values. may not be super accurate.
            using (StatReader stats = new StatReader())
            {
                Trace.WriteLine(string.Concat("CPU Use: ", stats.GetCpuUse()));
                Trace.WriteLine(string.Concat("CPU Use: ", stats.GetCpuUse()));
                Trace.WriteLine(string.Concat("CPU Use: ", stats.GetCpuUse()));
                Trace.WriteLine(string.Concat("CPU Use: ", stats.GetCpuUse()));
                Assert.IsTrue(stats.GetCpuUse() <= 100);
            }
        }
    }
}
