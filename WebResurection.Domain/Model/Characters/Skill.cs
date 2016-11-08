using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public class Skill: Entity<int>
    {
        //I need to assign an inteface to players and NPC's 
        //so that they cna both have skills assigned to them
        //Not called skillsheet because that sounds like multiples

        //public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public int Level { get; set; }

    }
}
