using FussballManagerLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FussballManagerTest
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Creation()
        {
            Assert.IsNotNull( new Player());
        }

        [TestMethod]
        public void CreationOverload()
        {
            Player p = new Player {Name = "Hans", Speed = 50, Precision = 50, Duel = 50, Position = PlayerPositions.Keeper };
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void CreationOverloadWithoutName()
        {
            Player p = new Player {Speed = 50, Precision = 50, Duel = 50, Position = PlayerPositions.Keeper };
            Assert.IsNotNull(p);
            Assert.IsFalse(p.Name == "");
        }

        [TestMethod]
        public void PlayerGetNames()
        {
            Player p = new Player("B1", 0, 0, 0, PlayerPositions.Midfield);
            Assert.IsTrue(p.Name == "B1");
            
            p.Name=Player.GetRandomName();
            Assert.IsTrue(p.Name != "B1");

            p = new Player(0, 0, 0, PlayerPositions.Midfield);
            Assert.IsTrue(p.Name != "B1");
        }

        [TestMethod]
        public void TeamPlayerGetNames()
        {
            Team t = new Team(11);

            Assert.IsFalse(t.Players[0].Name != t.Players[1].Name);
        }
    }
}
