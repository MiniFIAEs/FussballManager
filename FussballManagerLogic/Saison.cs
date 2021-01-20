using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballManagerLogic
{
    public class Saison
    {
        public List<Match> Matches { get; set; }

        public Saison()
        {
            Matches = new List<Match>();
        }

        public void CalculateDay(int v)
        {
            foreach (var item in Matches)
            {
                if (item.Day == v)
                {
                    item.CalculateResult();
                    item.IsPlayed = false;
                }
            }
        }
    }
}
