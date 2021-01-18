using System.Collections.Generic;

namespace FussballManagerLogic
{
    public class Team
    {
        public string Name { get; init; }
        private List<Player> players;

        public List<Player> Players
        {
            get => players;
            set => players = value;
        }


        public Team(string pName = "NoNamedTeam")
        {
            Name = pName;
            players = new List<Player>(11);
            for (int i = 0; i < players.Capacity; i++)
            {
                players.Add(new Player());
            }
        }
    }
}