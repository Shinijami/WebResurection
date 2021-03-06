namespace WebResurection.Migrations
{
    using Domain.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebResurection.Repositories.EF;
    using WebResurection.Domain.Model.Characters;

    internal sealed class Configuration : DbMigrationsConfiguration<WebResurection.Repositories.EF.WebResurection_Context>//DbMigrationsConfiguration<WebResurection.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebResurection_Context context)//WebResurection.Models.ApplicationDbContext context)This is the Identity stuff provided by Microsoft
        {
            var skills = new List<Skill>
            {
                new Skill { Name = "Accounting", CreateDate = DateTime.Now , Description = "Grants understanding of accountancy procedures, and reveals the financial "+
                "functioning of a business or person. Inspecting the books, one might detect cheated employees, siphoned-off funds, payment "+
                "of bribes or blackmail, and whether or not the financial condition is better or worse than claimed. Looking through old accounts, "+
                "one could see how money was gained or lost in the past (grain, slave-trading, whiskey-running, etc.) and to whom and for what payment was made."}

                ,new Skill { Name = "Anthropology", CreateDate = DateTime.Now, Description = "Enables the user to identify and understand an individual�s way of life from his behavior. If the skill-user observes another culture from within for a time, or works from accurate records concerning an extinct culture, he or she may make simple predictions about that culture�s ways and morals, even though the evidence may be incomplete.Studying the culture for a month or more, the anthropologist begins to understand how the culture functions and, in combination with Psychology, may predict the actions and beliefs of representatives.Essentially useful only with existing human cultures."}
                ,new Skill { Name = "Archaeology", CreateDate = DateTime.Now, Description = "Allows dating and identification of artifacts from past cultures and the detecting of fakes. Having thoroughly inspected a site, the user might deduce the purposes and way of life of those who left the remains. Anthropology might aid in this. Archaeology may also help identify written forms of extinct human languages." }
            };
            skills.ForEach(skill => context.Skills.AddOrUpdate(sk => sk.Name, skill));
            context.SaveChanges();

            var stats = new List<Stat>
            {
                new Stat {Name = "Strength",  CreateDate = DateTime.Now, Description = "This is how much muscle your character bring to the table. It affects not only how hard of a punch your character can throw but also things like the strength of his grip and how much weight he/she can lift. To calculate your STR stat, simply roll three six-sided dice and add their numbers together." }
                , new Stat {Name = "Constitution",  CreateDate = DateTime.Now, Description = "This is how tough your character is. It affects how much damage your character can take before going unconscious or dying, and how resistant your character is to disease and poison. CON is calculated in the same way as STR, by rolling three six-sided dice and adding their numbers." }
                , new Stat {Name = "Size",  CreateDate = DateTime.Now, Description = "This is a measure of your character's physical mass.It affects both how much damage your character can deal and how much they can take, as well as how easily your character could be picked up and tossed around. To calculate your character's SIZ, roll two six-sided dice, add the results together, and then add six." }
                , new Stat {Name = "Dexterity",  CreateDate = DateTime.Now, Description = "This stat is how agile and quick your character is. It affects things like keeping from tripping or stumbling while running away from a horde of flesh-eating ghouls. DEX is calculated in the same way as STR and CON, by adding together the results of three six-sided dice rolls." }
                , new Stat {Name = "Appearance",  CreateDate = DateTime.Now, Description = "This stat is how appealing and charming your character is to others. Your character's APP is calculated like their STR, CON, and DEX: roll three six-sides and add them together." }
                , new Stat {Name = "Intelligence",  CreateDate = DateTime.Now, Description = "This stat is how cunning and able to deduce logical conclusions your character is. Your character's INT stat is calculated in the same way as their SIZ stat, so you roll two six-sided dice and then add six to their sum." }
                , new Stat {Name = "Power",  CreateDate = DateTime.Now, Description = "This stat is a combination of spirit, willpower, and mental stability. It affects a character's ability with the use of magic, as well as their resistance to the damage to their sanity that knowledge of the Cthulhu Mythos brings. POW is calculated in the same way as STR, CON, DEX, and APP, by rolling three six-sided dice and adding their values." }
                , new Stat {Name = "Education", CreateDate = DateTime.Now, Description ="This stat reflect the knowledge your character has acquired from their formal education. To calculate your character's EDU stat, roll three six-sided dice, add the results, and then add three." }
            };
            stats.ForEach(stat => context.Stats.AddOrUpdate(st => st.Name, stat));
            context.SaveChanges();
            
            var characters = new List<Character>
            {
                new Character { FirstName = "Shinijami", HealthPoints = 250.0, Damage = 20.0, isPlayer = true, CreateDate = DateTime.Now }//, ImplementedStats = implementedStats }///*, StatSheet = { new ImplementedStat(), new ImplementedStat() }, SkillSheet = { new ImplementedSkill() }*/ }
                , new Character { FirstName = "Numn2Nutts", HealthPoints = 100.0, Damage = 50.0, isPlayer = true, CreateDate = DateTime.Now.AddDays(-1) }//, ImplementedStats = implementedStats2 }
                , new Character { FirstName = "Levi",LastName = "Juan", HealthPoints = 500.0, Damage = 250.0, isPlayer = false, CreateDate = DateTime.Now.AddDays(-1) }
            };
            characters.ForEach(ch => context.Characters.AddOrUpdate(c => c.FirstName, ch));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player { CharacterId = characters.Single(p => p.FirstName == "Shinijami").ID, Difficulty = "Hard", CreateDate = DateTime.Now.AddDays(-1) }//, ImplementedStats = implementedStats }///*, StatSheet = { new ImplementedStat(), new ImplementedStat() }, SkillSheet = { new ImplementedSkill() }*/ }
                , new Player {  CharacterId = characters.Single(p => p.FirstName == "Numn2Nutts").ID, Difficulty = "Hard", CreateDate = DateTime.Now.AddDays(-1) }//, ImplementedStats = implementedStats2 }
            };
            players.ForEach(ch => context.Players.AddOrUpdate(c => c.CharacterId, ch));
            context.SaveChanges();

            var npcs = new List<NPC>
            {
                new NPC {  CharacterId = characters.Single(p => p.FirstName == "Levi").ID, CreateDate = DateTime.Now.AddDays(-1) }
            };
            npcs.ForEach(ch => context.NPCs.AddOrUpdate(c => c.CharacterId, ch));
            context.SaveChanges();

            var implementedStats = new List<ImplementedStat>();
            foreach (var stat in stats)
            {
                implementedStats.Add(new ImplementedStat { Stat = stat, Modifier = 0, Value = 10, CreateDate = DateTime.Now, CharacterId = characters.Single(p => p.FirstName == "Shinijami").ID });
            }
            foreach (var stat in stats)
            {
                implementedStats.Add(new ImplementedStat { Stat = stat, Modifier = 0, Value = 5, CreateDate = DateTime.Now, CharacterId = characters.Single(p => p.FirstName == "Numn2Nutts").ID });
            }
            foreach (var stat in stats)
            {
                implementedStats.Add(new ImplementedStat { Stat = stat, Modifier = 0, Value = 15, CreateDate = DateTime.Now, CharacterId = characters.Single(p => p.FirstName == "Levi").ID });
            }
            implementedStats.ForEach(imp => context.ImplementedStats.AddOrUpdate(imp));
            context.SaveChanges();
        }
    }
}
