using System;

namespace FussballManagerLogic
{
    public class Match
    {
        private Team teamOne;
        private Team teamTwo;
        public int Day { get; set; }

        private string home = "0";
        public string Home
        {
            get
            {
                return this.isPlayed ? home : "-";
            }
            private set { home = value;  }
        }

        private string visitor = "0";
        public string Visitor { get
            {
                return this.isPlayed ? visitor : "-";
            }
            private set { home = value;  }}

        private bool isPlayed;
        public bool IsPlayed
        {
            get => isPlayed;
            set => isPlayed = value;
        }

        public Team TeamOne
        {
            get { return teamOne; }
            set { teamOne = value; }
        }

        public Team TeamTwo
        {
            get { return teamTwo; }
            set { teamTwo = value; }
        }


        public Match()
        {
            TeamOne = new Team("Auto1");
            TeamTwo = new Team("Auto2");
        }

        public Match(Team pTeamOne, Team pTeamTwo)
        {
            TeamOne = pTeamOne;
            TeamTwo = pTeamTwo;
        }

        public void CalculateResult()
        {
            int teamAPerformance = 0;
            foreach (var item in TeamOne.Players)
            {
                teamAPerformance += item.Speed;
                teamAPerformance += item.Precision;
                teamAPerformance += item.Duel;
            }

            int teamBPerformance = 0;
            foreach (var item in TeamTwo.Players)
            {
                teamBPerformance += item.Speed;
                teamBPerformance += item.Precision;
                teamBPerformance += item.Duel;
            }

            if (teamAPerformance > teamBPerformance) Home = "1";

            if (teamAPerformance < teamBPerformance) Visitor = "1";

            this.isPlayed = true;
        }
    }
}