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
                }
            }
        }
        public static List<Standing> GetStanding(int day)
        {
            //TODO: get data from sqlite database

            // create dummy list

            /*List<Standing> returnList = new()
            {
                new Standing() { TeamObject = new Team("Team 1"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 2"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 3"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 4"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 5"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 6"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 7"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 8"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 9"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 10"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 11"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 12"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 13"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 14"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 15"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 16"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 17"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 },
                new Standing() { TeamObject = new Team("Team 18"), Games = 15, Points = 15, GoalsHome = 20, GoalsVisitor = 10, GoalsDifference = 10, Won = 5, Draw = 5, Lost = 5 }
            };

            return returnList; */

            return Database.GetStandingsFromDatabase(day);
        }
    }
}
