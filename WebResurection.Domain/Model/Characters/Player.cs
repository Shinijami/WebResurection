using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public class Player : Entity<int>
    {
        //public string Name { get; set; }
        //public double HealthPoints { get; set; }
        //public double Damage { get; set; }
        public string PlayerString { get; set; } = "I'm a Player";

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        //public virtual ICollection<ImplementedSkill> ImplementedSkills { get; set; }
        //public virtual ICollection<ImplementedStat> ImplementedStats { get; set; }
    }
}
