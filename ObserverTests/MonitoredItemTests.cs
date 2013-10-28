using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Observer;

namespace Observer.Tests
{
    [TestClass()]
    public class MonitoredItemTests
    {
        [TestMethod()]
        public void notifyObserverTest()
        {
            MonitoredItem mi = new MonitoredItem();
            MockChangeLogger logger = new MockChangeLogger();
            mi.addObserver(logger);

            Assert.AreEqual(0, logger._notifiedCount);

            mi.changeState(State.CRITICAL);
            Assert.AreEqual(1, logger._notifiedCount);

            mi.changeState(State.CRITICAL);
            Assert.AreEqual(2, logger._notifiedCount);
        }
    }
}