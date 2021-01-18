using FussballManagerLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FussballManagerTest
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void Creation()
        {
            Assert.IsNotNull( new Team());
        }

        public void CreationAndInitialization()
        {
            Team t = new Team();
            Assert.IsNotNull(t.Players);
            for (int counter = 0; counter < 11; counter++)
                t.Players.Add(new Player());
            Assert.IsTrue(t.Players.Count == 11);
        }

    }
}
