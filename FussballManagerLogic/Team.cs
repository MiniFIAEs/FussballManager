using System.Collections.Generic;

namespace FussballManagerLogic
{
    public class Team
    {
        public string Name { get; set; }
        private List<Player> players;
        

        public List<Player> Players
        {
            get => players;
            set => players = value;
        }


        public Team(string pName = "NoNamedTeam")
        {
            Name = pName;
            Players = new List<Player>();
        }

        public Team(int pPlayerCount)
        {
            //todo: needed?
            Name = "NoNamedTeam";
            Players = new List<Player>(pPlayerCount);

            for (int playerIndex = 0; playerIndex < Players.Capacity; playerIndex++)
            {
                Player playerModel = new Player(0, 0, 0, PlayerPositions.Midfield);
                Players.Add(playerModel);
            }
        }
    }
}