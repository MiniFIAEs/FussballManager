using FussballManagerLogic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FussballManagerTest
{
    [TestClass]
    public class SaisonTests
    {
        [TestMethod]
        public void Creation()
        {
            var s = new Saison();
            Assert.IsNotNull(s);
            Assert.IsNotNull(s.Matches);
        }

        [TestMethod]
        public void FillSaison()
        {
            Saison s = new();
            Team tA = Helper.CreateTeam();
            Team tB = Helper.CreateTeam();
            
            Match m = new(tA, tB);
            Match n = new(tB, tA);
            m.Day = 1;
            n.Day = 2;
            s.Matches.Add(m);
            s.Matches.Add(n);
            s.CalculateDay(1);
            Assert.IsTrue(s.Matches[0].Home == 0);
            Assert.IsTrue(s.Matches[0].Visitor == 0);
        }

        [TestMethod]
        public void FullSeason()
        {
            List<Team> Teams = new List<Team>();
            for (int counter = 0; counter < 18; counter++)
                Teams.Add(Helper.CreateTeam());

            Saison s = new();
            for (int outer = 1; outer < Teams.Count; outer++)
                for (int inner = 0; inner < Teams.Count; inner++)
                    s.Matches.Add(new Match(Teams[inner], Teams[(inner + outer) % Teams.Count]) {Day = outer});

            //TODO: add assert

        }
        [TestMethod]
        public void PlayFullSeason()
        {
            List<Team> Teams = new List<Team>();
            for (int counter = 0; counter < 18; counter++)
                Teams.Add(Helper.CreateTeam());

            Saison s = new();
            for (int outer = 1; outer < Teams.Count; outer++)
                for (int inner = 0; inner < Teams.Count; inner++)
                    s.Matches.Add(new Match(Teams[inner], Teams[(inner + outer) % Teams.Count]) { Day = outer });

            foreach (Match match in s.Matches)
            {
                match.CalculateResult();
            }

            //TODO: add assert

        }
    }
}
