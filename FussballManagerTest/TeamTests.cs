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
            Assert.IsNotNull(new Team());
        }

        [TestMethod]
        public void CreationAndInitialization()
        {
            Team t = Helper.CreateTeam();
            Assert.IsNotNull(t);
            t.Players.Capacity = 11;
            Assert.IsNotNull(t.Players);
            Assert.IsTrue(t.Players.Count == 11);
        }

        [TestMethod]
        public void TeamWithCorrectTeamSize()
        {
            Team t = Helper.CreateTeam();
            Assert.IsNotNull(t);
            t.Players.Capacity = 11;
            Assert.IsNotNull(t.Players);
            Assert.IsTrue(t.Players.Count == 11);
        }

        [TestMethod]
        public void PlayersSetter()
        {
            Team t = Helper.CreateTeam();
            Assert.IsTrue(t.Name == "NoNamedTeam");
            Assert.IsTrue(t.Players[1].Name == "B2");
            t.Players[1] = new Player("NamedPlayer", 0,0,0, PlayerPositions.Midfield);
            Assert.IsTrue(t.Players[1].Name == "NamedPlayer");
        }

        [TestMethod]
        public void SaveTeamToDatabase()
        {
            Team t = Helper.CreateTeam();
            Assert.IsNotNull(t);
            Database.SaveTeamToDatabase(t);

            //TODO: assert
        }
    }
}