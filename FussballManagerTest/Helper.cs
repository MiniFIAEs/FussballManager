using FussballManagerLogic;
using System.Collections.Generic;

namespace FussballManagerTest
{
    public class Helper
    {
        public static Team CreateTeam(string Name = "NoNamedTeam")
        {
            Team team = new(Name);
            team.Players.Add(new Player("B1", 50, 50, 50, PlayerPositions.Keeper));
            team.Players.Add(new Player("B2", 50, 50, 50, PlayerPositions.Defence));
            team.Players.Add(new Player("B3", 50, 50, 50, PlayerPositions.Defence));
            team.Players.Add(new Player("B4", 50, 50, 50, PlayerPositions.Defence));
            team.Players.Add(new Player("B5", 50, 50, 50, PlayerPositions.Midfield));
            team.Players.Add(new Player("B6", 50, 50, 50, PlayerPositions.Midfield));
            team.Players.Add(new Player("B7", 50, 50, 50, PlayerPositions.Midfield));
            team.Players.Add(new Player("B8", 50, 50, 50, PlayerPositions.Midfield));
            team.Players.Add(new Player("B9", 50, 50, 50, PlayerPositions.Attack));
            team.Players.Add(new Player("BA", 50, 50, 50, PlayerPositions.Attack));
            team.Players.Add(new Player("BB", 50, 50, 50, PlayerPositions.Attack));
            return team;
        }
        public static Saison CreateSeason() //TODO: correct season
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
        public static Saison CreateAndPlaySeason() //TODO: complete matching, optimize loops, find bugs, matching based on official rules
        {
            List<Team> Teams = new List<Team>();
            for (int counter = 0; counter < 18; counter++)
                Teams.Add(Helper.CreateTeam("Team_" + counter));

            Saison s = new();
            int[] toprow = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7};
            int[] buttomrow = new int[8] { 16, 15, 14, 13, 12, 11, 10, 9 };

            int[] left = new int[2] { -1, -1 };
            int[] right = new int[2] { 8, 17 };

            for (int loop = 0; loop < 17; loop++)
            {
                for (int i = 0; i < 8; i++)
                {
                    s.Matches.Add(new Match(Teams[toprow[i]], Teams[buttomrow[i]]) { Day = (toprow[i] + 1 + buttomrow[i] + 1) % 17});
                }

                if (left[0] == -1) // left side "empty"
                {
                    s.Matches.Add(new Match(Teams[right[0]], Teams[right[1]]) { Day = (right[0] + 1 + right[1] + 1) % 17 });

                    left[0] = right[1];
                    left[1] = toprow[0];

                    for (int i = 1; i < 8; i++)
                    {
                        toprow[i - 1] = toprow[i];
                    }
                    toprow[7] = right[0];

                    right[0] = -1; // set right side to "empty"
                }
                else // right side "empty"
                {
                    s.Matches.Add(new Match(Teams[left[0]], Teams[left[1]]) { Day = (left[0] + 1 + left[1] + 1) % 17 });

                    right[0] = buttomrow[7];
                    right[1] = left[0];

                    for (int i = 7; i > 0; i--)
                    {
                        buttomrow[i] = buttomrow[i - 1];
                    }
                    buttomrow[0] = left[1];

                    left[0] = -1; // set left side to "empty"
                }
            }

            foreach (Match match in s.Matches)
            {
                match.CalculateResult();
            }

            return s;
        }
    }
}
