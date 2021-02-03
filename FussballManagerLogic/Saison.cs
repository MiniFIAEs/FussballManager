using System.Collections.Generic;

namespace FussballManagerLogic
{
    public class Saison
    {
        public List<Match> Matches { get; set; }
        private List<Match> _matchDay;

        public List<Match> MatchDay
        {
            get => _matchDay;
            set => _matchDay = value;
        }

        public Saison()
        {
            Matches = new List<Match>();
        }

        public void CalculateDay(int pSpieltag)
        {
            foreach (var item in Matches)
            {
                if (item.Day == pSpieltag)
                {
                    item.CalculateResult();
                    MatchDay.Add(item);
                }
            }
        }
    }
}
