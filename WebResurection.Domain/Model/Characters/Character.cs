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


        public void CreatePlayerStats(List<Stat> stats, string difficulty)
        {
            switch (difficulty)
            {
                case "Easy":
                    break;
                case "Medium":
                    break;
                case "Hard":
                    Hard(stats);
                    break;
                default:
                    break;
            }
        }

        public void Easy(Player player)
        {

        }

        public void Medium(Player player)
        {

        }

        public void Hard(List<Stat> stats)
        {
            Random rnd = new Random();

            foreach (var stat in stats)
            {
                var impStat = new ImplementedStat { Stat = stat, Modifier = 0, Value = 10, CreateDate = DateTime.Now, CharacterId = ID };
                if (StatMetaData.threeDSix.Contains(stat.Name.ToUpper()))
                    impStat.Value = DiceRolls.Roll(3, 6, 0);
                else if (StatMetaData.twoDSixPlusSix.Contains(stat.Name.ToUpper()))
                    impStat.Value = DiceRolls.Roll(2, 6, 6);// Roll2D6Plus6(rnd);
                else if (StatMetaData.threeDSixPlusThree.Contains(stat.Name.ToUpper()))
                    impStat.Value = DiceRolls.Roll(3, 6, 3);// Roll3d6Plus3(rnd);

                ImplementedStats.Add(impStat);
            }
        }
    }
}
