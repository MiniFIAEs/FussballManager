namespace FussballManagerLogic
{
    public class Match
    {
        public Team TeamOne { get; init; }
        public Team TeamTwo { get; init; }
        public int Day { get; set; }
        public int Home { get; private set; }
        public int Visitor { get; private set; }

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

        }
    }
}