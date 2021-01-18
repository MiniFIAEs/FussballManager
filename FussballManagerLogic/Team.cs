using System.Collections.Generic;

namespace FussballManagerLogic
{
    public class Team
    {
        private List<Player> players;

        public List<Player> Players
        {
            get => players;
            set => players = value;
        }

        public Team()
        {
            
        }
    }
}