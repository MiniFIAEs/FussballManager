using System;

namespace FussballManagerLogic
{
    public class Match
    {
        private Team teamOne;
        private Team teamTwo;
        public int Day { get; set; }
        public int Home { get; private set; }
        public int Visitor { get; private set; }
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

            if (teamAPerformance > teamBPerformance) Home = 1;

            if (teamAPerformance < teamBPerformance) Visitor = 1;

            this.isPlayed = true;
        }
    }
}