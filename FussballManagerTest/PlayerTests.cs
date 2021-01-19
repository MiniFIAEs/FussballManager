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
    }
}
