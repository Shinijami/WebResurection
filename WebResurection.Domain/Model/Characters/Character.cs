using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public class Character : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double HealthPoints { get; set; }
        public double Damage { get; set; }
        public bool isPlayer { get; set; }

        public virtual ICollection<ImplementedSkill> ImplementedSkills { get; set; }
        public virtual ICollection<ImplementedStat> ImplementedStats { get; set; }
    }
}
