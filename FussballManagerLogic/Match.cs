namespace FussballManagerLogic
{
    public class Match
    {
        public Team TeamOne { get; init; }
        public Team TeamTwo { get; init; }

        public Match()
        {
            TeamOne = new Team("Auto1");
            TeamTwo = new Team("Auto2");
        }

        public Match(Team pTeamOne, Team pTeamTwo)
        {

        }
    }
}