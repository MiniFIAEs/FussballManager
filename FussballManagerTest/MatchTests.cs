using FussballManagerLogic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
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
            Match m = new();
            Match m2 = new();
            Assert.IsTrue(m.TeamOne.Name == "Auto1");
            Assert.IsTrue(m2.TeamTwo.Name == "Auto2");
        }

        [TestMethod]
        public void CreationBig()
        {
            Player p = new("test", 0, 0, 0, PlayerPositions.Midfield);
            Assert.IsNotNull(p);
            Assert.IsTrue(p.Name == "test");
            Assert.IsTrue(p.Speed == 0);
            Assert.IsTrue(p.Precision == 0);
            Assert.IsTrue(p.Duel == 0);
            Assert.IsTrue(p.Position == PlayerPositions.Midfield);

        }
        
        [TestMethod]
        public void CreationTwoParameter()
        {
            Team t1 = new("TeamOne");
            Assert.IsNotNull(t1);
            Team t2 = new("TeamTwo");
            Assert.IsNotNull(t2);
            Assert.IsTrue(t1.Players.Count == 11);
            Assert.IsTrue(t2.Players.Count == 11);
            Assert.IsTrue(t1.Name == "TeamOne");
            Assert.IsTrue(t2.Name == "TeamTwo");
            Assert.IsNotNull(new Match(t1, t2));
        }

    }
}
