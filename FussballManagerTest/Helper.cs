using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public static Saison CreateSeason()
        {
            List<Team> teams = new List<Team>();
            for (int counter = 0; counter < 18; counter++)
            {
                teams.Add(Helper.CreateTeam());
                teams[counter].Name += counter;
            }

            Saison s = new();
            for (int outer = 9; outer < teams.Count; outer++)
            for (int inner = 0; inner < teams.Count / 2; inner++)
            {
                s.Matches.Add(new Match(teams[inner], teams[(inner + outer) % teams.Count]) {Day = outer});
            }

            foreach (var item in s.Matches)
            {
                item.CalculateResult();
            }

            return s;
        }

        //https://gist.github.com/luzumi/ac2aecac8629ed367c1bf0e62b84e444
        List<List<List<(int, int)>>> getOrganizedMatchDaysFromTeamList(List<int> teamList, bool secondRound)
        {
            List<List<List<(int, int)>>> resultList = new List<List<List<(int, int)>>>(teamList.Count);

            //Nur gerade Anzahl Teilnehmer erlaubt
            int intTeams = teamList.Count();
            if ((intTeams % 2) != 0)
            {
                return resultList;
            }

            // --- Spielpaarungen bestimmen ---------------------------------------
            int n = intTeams - 1;
            (int, int) paarung;

            for (int i = 1; i <= intTeams - 1; i++)
            {
                List<(int, int)> initListSpieltag = new List<(int, int)>(teamList.Count / 2);
                resultList.Add(new List<List<(int, int)>> { new List<(int, int)> { (initListSpieltag[i].Item1, initListSpieltag[i].Item2) }});

                int h = intTeams;
                int a = i;

                // heimspiel? auswärtsspiel?
                if ((i % 2) != 0)
                {
                    int temp = a;
                    a = h;
                    h = temp;
                }

                paarung.Item1 = teamList[h - 1];
                paarung.Item2 = teamList[a - 1];

                List<List<(int, int)>> m = resultList[i - 1];
                m.Add(new List<(int,int)> { paarung });
                resultList[i-1] = m;

                for (int k = 1; k <= ((intTeams / 2) - 1); k++)
                {
                    if ((i - k) < 0)
                    {
                        a = n + (i - k);
                    }
                    else
                    {
                        a = (i - k) % n;
                        a = (a == 0) ? n : a; // 0 -> n-1
                    }

                    h = (i + k) % n;
                    h = (h == 0) ? n : h; // 0 -> n-1

                    // heimspiel? auswärtsspiel?
                    if ((k % 2) == 0)
                    {
                        int temp = a;
                        a = h;
                        h = temp;
                    }

                    paarung.Item1 = teamList[h - 1];
                    paarung.Item2 = teamList[a - 1];

                    List<List<(int, int)>> l = resultList[i - 1];
                    l.Add(new List<(int,int)> { paarung });
                    resultList[i - 1] =  l;
                }
            }

            // --- mit Rückrunde? -------------------------------------------------------
            if (secondRound)
            {
                int cntSpieltage = resultList.Count();
                for (int i = 0; i < cntSpieltage; i++)
                {
                    List<List<(int, int)>> spieltagList = resultList[i];

                    int cntSpiele = spieltagList.Count();
                    for (int j = 0; j < cntSpiele; j++)
                    {
                        paarung = spieltagList[i][j];
                        int temp = paarung.Item1;
                        paarung.Item1 = paarung.Item2;
                        paarung.Item2 = temp;
                        spieltagList[j] = new List<(int, int)>() { paarung };
                    }

                    resultList.Add(spieltagList);
                }
            }
            return resultList;
        }
    }
}