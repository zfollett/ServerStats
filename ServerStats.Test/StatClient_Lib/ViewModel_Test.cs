using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatClient.Lib;

namespace ServerStats.Test.StatClient_Lib
{
    [TestClass]
    public class ViewModel_Test
    {
        [TestMethod]
        public void LoadLastHour_Test()
        {
            ViewModel vm = new ViewModel(new RestClientMock());
            vm.LoadLastHour.Execute(null);
            Assert.IsTrue(vm.Stats.Count > 0);
        }

        [TestMethod]
        public void LoadLastDay_Test()
        {
            ViewModel vm = new ViewModel(new RestClientMock());
            vm.LoadLastDay.Execute(null);
            Assert.IsTrue(vm.Stats.Count > 0);

        }
    }
}
