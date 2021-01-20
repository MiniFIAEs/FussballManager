using FussballManagerLogic;
using System.Collections.Generic;

namespace FussballManagerTest
{
    public class Helper
    {
        public static Team CreateTeam(string Name = "NoNamedTeam")
        {
            Team result = new(Name);
            result.Players.Add(new Player("B1", 50, 50, 50, PlayerPositions.Keeper));
            result.Players.Add(new Player("B2", 50, 50, 50, PlayerPositions.Defence));
            result.Players.Add(new Player("B3", 50, 50, 50, PlayerPositions.Defence));
            result.Players.Add(new Player("B4", 50, 50, 50, PlayerPositions.Defence));
            result.Players.Add(new Player("B5", 50, 50, 50, PlayerPositions.Midfield));
            result.Players.Add(new Player("B6", 50, 50, 50, PlayerPositions.Midfield));
            result.Players.Add(new Player("B7", 50, 50, 50, PlayerPositions.Midfield));
            result.Players.Add(new Player("B8", 50, 50, 50, PlayerPositions.Midfield));
            result.Players.Add(new Player("B9", 50, 50, 50, PlayerPositions.Attack));
            result.Players.Add(new Player("BA", 50, 50, 50, PlayerPositions.Attack));
            result.Players.Add(new Player("BB", 50, 50, 50, PlayerPositions.Attack));
            return result;
        }
        public static Saison CreateSeason()
        {
            List<Team> Teams = new List<Team>();
            for (int counter = 0; counter < 18; counter++)
                Teams.Add(Helper.CreateTeam());

            Saison s = new();
            for (int outer = 1; outer < Teams.Count; outer++)
                for (int inner = 0; inner < Teams.Count; inner++)
                    s.Matches.Add(new Match(Teams[inner], Teams[(inner + outer) % Teams.Count]) { Day = outer });

            return s;
        }
    }
}
