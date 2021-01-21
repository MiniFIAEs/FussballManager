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
            Team t1 = Helper.CreateTeam("TeamOne");
            Assert.IsNotNull(t1);
            Team t2 = Helper.CreateTeam("TeamTwo");
            Assert.IsNotNull(t2);
            Assert.IsTrue(t1.Players.Count == 11);
            Assert.IsTrue(t2.Players.Count == 11);
            Assert.IsTrue(t1.Name == "TeamOne");
            Assert.IsTrue(t2.Name == "TeamTwo");
            Assert.IsNotNull(new Match(t1, t2));
        }

        [TestMethod]
        public void ResultBalancedTeams()
        {
            Team tA = new();
            tA.Players.Add(new Player("A1", 50, 50, 50, PlayerPositions.Keeper));
            tA.Players.Add(new Player("A2", 50, 50, 50, PlayerPositions.Defence));
            tA.Players.Add(new Player("A3", 50, 50, 50, PlayerPositions.Defence));
            tA.Players.Add(new Player("A4", 50, 50, 50, PlayerPositions.Defence));
            tA.Players.Add(new Player("A5", 50, 50, 50, PlayerPositions.Midfield));
            tA.Players.Add(new Player("A6", 50, 50, 50, PlayerPositions.Midfield));
            tA.Players.Add(new Player("A7", 50, 50, 50, PlayerPositions.Midfield));
            tA.Players.Add(new Player("A8", 50, 50, 50, PlayerPositions.Midfield));
            tA.Players.Add(new Player("A9", 50, 50, 50, PlayerPositions.Attack));
            tA.Players.Add(new Player("AA", 50, 50, 50, PlayerPositions.Attack));
            tA.Players.Add(new Player("AB", 50, 50, 50, PlayerPositions.Attack));
            
            Team tB = new();
            tB.Players.Add(new Player("B1", 50, 50, 50, PlayerPositions.Keeper));
            tB.Players.Add(new Player("B2", 50, 50, 50, PlayerPositions.Defence));
            tB.Players.Add(new Player("B3", 50, 50, 50, PlayerPositions.Defence));
            tB.Players.Add(new Player("B4", 50, 50, 50, PlayerPositions.Defence));
            tB.Players.Add(new Player("B5", 50, 50, 50, PlayerPositions.Midfield));
            tB.Players.Add(new Player("B6", 50, 50, 50, PlayerPositions.Midfield));
            tB.Players.Add(new Player("B7", 50, 50, 50, PlayerPositions.Midfield));
            tB.Players.Add(new Player("B8", 50, 50, 50, PlayerPositions.Midfield));
            tB.Players.Add(new Player("B9", 50, 50, 50, PlayerPositions.Attack));
            tB.Players.Add(new Player("BA", 50, 50, 50, PlayerPositions.Attack));
            tB.Players.Add(new Player("BB", 50, 50, 50, PlayerPositions.Attack));

            Match m = new(tA,tB);
            m.CalculateResult();
            Assert.IsTrue(m.Home == "0");
            Assert.IsTrue(m.Visitor == "0");
        }

        [TestMethod]
        public void HomeGetter()
        {
            Match m = new Match();
            Assert.IsTrue(m.TeamOne.Name == "Auto1");
            Assert.IsTrue(m.Home == "-");

            Assert.IsTrue(m.IsPlayed == false);
            m.IsPlayed = true;
            Assert.IsTrue(m.Home == "0");
            m.IsPlayed = false;
            Assert.IsTrue(m.Home == "-");
        }

        [TestMethod]
        public void HomeSetter()
        {
            Match m = new Match();
            Assert.IsTrue(m.Home == "-");
            string test = m.Home;
            m.TeamOne.Players.Add(new Player(1,1,1, PlayerPositions.Midfield));
            m.TeamTwo.Players.Add(new Player(11,11,11, PlayerPositions.Midfield));
            m.CalculateResult();
            Assert.IsFalse(test == m.Home);
            Assert.IsTrue(m.Home == "1");
        }

        [TestMethod]
        public void VisitorGetter()
        {
            Match m = new Match();
            Assert.IsTrue(m.TeamTwo.Name == "Auto2");
            Assert.IsTrue(m.Visitor == "-");

            Assert.IsTrue(m.IsPlayed == false);
            m.IsPlayed = true;
            Assert.IsTrue(m.Visitor == "0");
            m.IsPlayed = false;
            Assert.IsTrue(m.Visitor == "-");
        }

        [TestMethod]
        public void VisitorSetter()
        {
            Match m = new Match();
            Assert.IsTrue(m.Visitor == "-");
            string test = m.Visitor;

            m.TeamOne.Players.Add(new Player(1,1,1, PlayerPositions.Midfield));
            m.TeamTwo.Players.Add(new Player(11,11,11, PlayerPositions.Midfield));
            m.CalculateResult();
            Assert.IsFalse(test == m.Visitor);
            Assert.IsTrue(m.Visitor == "0");
        }
    }
}
