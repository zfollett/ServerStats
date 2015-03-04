using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatAgent;

namespace ServerStats.Test.StatAgent_Lib
{
    [TestClass]
    public class StatReaderFactory_Test
    {
        [TestMethod]
        public void BuildStatReader_Test()
        {
            using(IStatReader rdr = StatReaderFactory.BuildStatReader())
            {
                Assert.IsNotNull(rdr);
            }
        }
    }
}
