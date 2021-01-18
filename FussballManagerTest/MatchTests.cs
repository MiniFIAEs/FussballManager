using FussballManagerLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FussballManagerTest
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void Creation()
        {
            Assert.IsNotNull(new Match());
        }

    }
}
