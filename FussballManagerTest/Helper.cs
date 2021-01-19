using FussballManagerLogic;

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
    }
}
