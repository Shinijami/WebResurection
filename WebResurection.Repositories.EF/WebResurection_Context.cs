using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebResurection.Domain.Model;
using WebResurection.Domain.Model.Characters;

namespace WebResurection.Repositories.EF
{
    public class WebResurection_Context : DbContext
    {
        public WebResurection_Context() : base("name=WebResurectionContext")
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Stat> Stats { get; set; }
        //public DbSet<SkillSheet> SkillSheets { get; set; }
        //public DbSet<StatSheet> StatSheets { get; set; }
        public DbSet<NPC> NPCs { get; set; }
        public DbSet<ImplementedStat> ImplementedStats { get; set; }
        public DbSet<ImplementedSkill> ImplementedSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
