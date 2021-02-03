using System;
using System.Collections.Generic;

namespace FussballManagerLogic
{
    public class Team
    {
        public string Name { get; set; }
        private List<Player> _players;

        public List<Player> Players
        {
            get => _players;
            set => _players = value;
        }


        public Team(string pName = "NoNamedTeam")
        {
            Name = pName;
            Players = new List<Player>();
        }


        public Team(int pPlayerCount)
        {
            Name = "NoNamedTeam";
            Players = new List<Player>(pPlayerCount);
            Random rnd = new Random();

            for (int playerIndex = 0; playerIndex < Players.Capacity; playerIndex++)
            {
                Player playerModel = new Player(
                    (byte)rnd.Next(0,100), 
                    (byte)rnd.Next(0,100),
                    (byte)rnd.Next(0,100), PlayerPositions.Midfield);
                Players.Add(new Player());
            }
        }
    }
}