using System.Collections.Generic;

namespace FussballManagerLogic
{
    public class Saison
    {
        public List<Match> Matches { get; set; }

        public Saison()
        {
            Matches = new List<Match>();
        }

        public void CalculateDay(int pMatchDay)
        {
            foreach (var item in Matches)
            {
                if (item.Day == pMatchDay)
                {
                    item.CalculateResult();
                }
            }
        }
    }
}
