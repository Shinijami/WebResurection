using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public class ImplementedSkill : Entity<int>
    {
       
        public double Value { get; set; }
        public double Modifier { get; set; }
        public bool hasPassed { get; set; }
        public bool hasCritPassed { get; set; }

        public int SkillId { get; set; }
        public virtual Skill Skill{ get; set; }

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
    }
}
