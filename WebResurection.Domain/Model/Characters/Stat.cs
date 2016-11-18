using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public static class StatMetaData
    {
        public static List<string> threeDSix = new List<string>(new string[] { "STRENGTH", "CONSTITUTION", "POWER", "DEXTERITY", "APPEARANCE" });
        public static List<string> twoDSixPlusSix = new List<string>(new string[] { "SIZE", "INTELLIGENCE" });
        public static List<string> threeDSixPlusThree = new List<string>(new string[] { "EDUCATION" });
    }

    public class Stat : Entity<int>
    {
        //I need to assign an inteface to players and NPC's 
        //so that they cna both have skills assigned to them
        //Not called skillsheet because that sounds like multiples
       
        //public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public double Value { get; set; }//I find it odd that these values are on here, these seem more like an implementation and not something associated with
        //public double Modifier { get; set; }//a stat. But I dont know how else to do this.

    }
}
