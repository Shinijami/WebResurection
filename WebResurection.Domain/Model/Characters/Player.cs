using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public class Player : Entity<int>//, iCharacter//should this inherit from character?
    {
        //public double HealthPoints { get; set; }
        //public double Damage { get; set; }
        public string PlayerString { get; set; } = "I'm a Player";
        public string Difficulty { get; set; }

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        //public virtual ICollection<ImplementedSkill> ImplementedSkills { get; set; }
        //public virtual ICollection<ImplementedStat> ImplementedStats { get; set; }

        public void Create(string difficulty)
        {
            CreateDate = DateTime.Now;
            Character.CreateDate = DateTime.Now;
            Character.isPlayer = true;
            Difficulty = difficulty;
            Character.ImplementedSkills = new List<ImplementedSkill>();
            Character.ImplementedStats = new List<ImplementedStat>();
        }
    }
}
