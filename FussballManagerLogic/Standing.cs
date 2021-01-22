using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballManagerLogic
{
    public class Standing
    {
        public int Games { get; set; }
        public Team TeamObject { get; set; }
        public int Points { get; set; }
        public int GoalsHome { get; set; }
        public int GoalsVisitor { get; set; }
        public int GoalsDifference { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
    }  
}
