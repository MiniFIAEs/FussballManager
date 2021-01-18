using System.Collections.Generic;

namespace FussballManagerLogic
{
    public class Team
    {
        public List<Player> Players { get; set; }
        public string Name { get; init; }


        public Team(string pName = "NoNamedTeam")
        {
            Name = pName;
        }
    }
}