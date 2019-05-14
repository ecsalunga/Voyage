using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Core;
using Voyage.Entity;

namespace Voyage.Test
{
    [TestClass]
    public class Helper_Test
    {
        [TestMethod]
        public void ToDuration()
        {
            string duration = Helper.ToDuration(90);
            Assert.AreEqual("00:01:30", duration);

            duration = Helper.ToDuration(5490);
            Assert.AreEqual("01:31:30", duration);
        }
    }
}
