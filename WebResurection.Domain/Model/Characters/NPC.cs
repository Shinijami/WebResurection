using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public class NPC : Entity<int>
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public double HealthPoints { get; set; }
        //public double Damage { get; set; }
        public string NpcString { get; set; } = "I'm an NPC";

        public int CharacterId { get; set; }

        public virtual Character Character { get; set; }
    }
}
