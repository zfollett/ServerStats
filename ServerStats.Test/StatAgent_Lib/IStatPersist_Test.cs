using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatAgent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerStats.Test.StatAgent_Lib
{
    /// <summary>
    /// This can be in the same test suite for now because it is in memory and runs relitively
    /// fast.  If IStatPersist is implimented by a slower storage mechanisum then break out to
    /// a seperate test suite.
    /// </summary>
    [TestClass]
    public class IStatPersist_Test
    {
        /// <summary>
        /// Build all the persist objects.
        /// 
        /// </summary>
        /// <returns></returns>
        private List<IStatPersist> statPersistTestFactory()
        {
            List<IStatPersist> persistObjects = new List<IStatPersist>();
            persistObjects.Add(StatPersistFactory.GetStatPersist());
            return persistObjects;
        }
        [TestMethod]
        public void StoreDataRecord_Test()
        {
            foreach(var p in statPersistTestFactory())
            {
                p.Clear();
                long count = p.Count;
                p.SaveDataRecord(new ServerDataPoint() { Time = DateTime.Now, Name = "Memory", Value = "12000" });
                p.SaveDataRecord(new ServerDataPoint() { Time = DateTime.Now, Name = "Processor", Value = "50" });
                Assert.AreEqual(count + 2, p.Count, string.Concat(p.GetType().ToString(), " Failed to store record incorrect count "));
            }
        }

        [TestMethod]
        public void GetDataRecords_Test()
        {
            foreach (var p in statPersistTestFactory())            
            {
                p.Clear();
                p.SaveDataRecord(new ServerDataPoint() { Time = DateTime.Now, Name = "Memory", Value = "12000" });
                p.SaveDataRecord(new ServerDataPoint() { Time = DateTime.Now, Name = "Processor", Value = "50" });
                p.SaveDataRecord(new ServerDataPoint() { Time = DateTime.Now.AddDays(-5), Name = "Memory", Value = "10000" });
                p.SaveDataRecord(new ServerDataPoint() { Time = DateTime.Now.AddDays(-5), Name = "Processor", Value = "10" });


                
                var start = DateTime.Now.Date;//DateTime.Now.AddDays(-1);
                List<ServerDataPoint> now = p.GetDataRecords(new List<string>(){"Memory"},start,DateTime.Now);
                Assert.AreEqual(1, now.Count, string.Concat(p.GetType().ToString(), " Incorrect record count"));
                Assert.AreEqual("Memory", now[0].Name, string.Concat(p.GetType().ToString(), " Incorrect record"));
                Assert.AreEqual("12000", now[0].Value, string.Concat(p.GetType().ToString(), " Incorrect record"));
            }
        }
    }
}
