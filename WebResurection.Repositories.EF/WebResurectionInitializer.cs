using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebResurection.Domain.Model;
using WebResurection.Domain.Model.Characters;

namespace WebResurection.Repositories.EF
{
    public class WebResurectionInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WebResurection_Context>
    {
        protected override void Seed(WebResurection_Context context)
        {
            //var players = new List<Player>
            //{
            //    new Player { Name = "Shinijami", HealthPoints = 250, Damage = 20, CreateDate = DateTime.Now }
            //    , new Player {Name="Numn2Nutts", HealthPoints = 100, Damage = 50, CreateDate = DateTime.Now }
            //};
            //players.ForEach(player => context.Players.Add(player));
            //context.SaveChanges();

            //var skills = new List<Skill>
            //{
            //    new Skill { Name = "Accounting", CreateDate = DateTime.Now , Description = "Grants understanding of accountancy procedures, and reveals the financial "+
            //    "functioning of a business or person. Inspecting the books, one might detect cheated employees, siphoned-off funds, payment "+
            //    "of bribes or blackmail, and whether or not the financial condition is better or worse than claimed. Looking through old accounts, "+
            //    "one could see how money was gained or lost in the past (grain, slave-trading, whiskey-running, etc.) and to whom and for what payment was made."}

            //    ,new Skill { Name = "Anthropology",  CreateDate = DateTime.Now, Description = "Enables the user to identify and understand an individual’s way of life from his behavior. If the skill-user observes another culture from within for a time, or works from accurate records concerning an extinct culture, he or she may make simple predictions about that culture’s ways and morals, even though the evidence may be incomplete.Studying the culture for a month or more, the anthropologist begins to understand how the culture functions and, in combination with Psychology, may predict the actions and beliefs of representatives.Essentially useful only with existing human cultures."}
            //    ,new Skill { Name = "Archaeology",  CreateDate = DateTime.Now, Description = "Allows dating and identification of artifacts from past cultures and the detecting of fakes. Having thoroughly inspected a site, the user might deduce the purposes and way of life of those who left the remains. Anthropology might aid in this. Archaeology may also help identify written forms of extinct human languages." }
            //};
            //skills.ForEach(skill => context.Skills.Add(skill));
            //context.SaveChanges();

            //var stats = new List<Stat>
            //{
            //    new Stat {Name = "Strength",CreateDate = DateTime.Now, Description = "This is how much muscle your character bring to the table. It affects not only how hard of a punch your character can throw but also things like the strength of his grip and how much weight he/she can lift. To calculate your STR stat, simply roll three six-sided dice and add their numbers together." }
            //    , new Stat {Name = "Constitution", CreateDate = DateTime.Now, Description = "This is how tough your character is. It affects how much damage your character can take before going unconscious or dying, and how resistant your character is to disease and poison. CON is calculated in the same way as STR, by rolling three six-sided dice and adding their numbers." }
            //    , new Stat {Name = "Size", CreateDate = DateTime.Now, Description = "This is a measure of your character's physical mass.It affects both how much damage your character can deal and how much they can take, as well as how easily your character could be picked up and tossed around. To calculate your character's SIZ, roll two six-sided dice, add the results together, and then add six." }
            //    , new Stat {Name = "Dexterity",  CreateDate = DateTime.Now, Description = "This stat is how agile and quick your character is. It affects things like keeping from tripping or stumbling while running away from a horde of flesh-eating ghouls. DEX is calculated in the same way as STR and CON, by adding together the results of three six-sided dice rolls." }
            //    , new Stat {Name = "Appearance",  CreateDate = DateTime.Now, Description = "This stat is how appealing and charming your character is to others. Your character's APP is calculated like their STR, CON, and DEX: roll three six-sides and add them together." }
            //    , new Stat {Name = "Intelligence",  CreateDate = DateTime.Now, Description = "This stat is how cunning and able to deduce logical conclusions your character is. Your character's INT stat is calculated in the same way as their SIZ stat, so you roll two six-sided dice and then add six to their sum." }
            //    , new Stat {Name = "Power",  CreateDate = DateTime.Now, Description = "This stat is a combination of spirit, willpower, and mental stability. It affects a character's ability with the use of magic, as well as their resistance to the damage to their sanity that knowledge of the Cthulhu Mythos brings. POW is calculated in the same way as STR, CON, DEX, and APP, by rolling three six-sided dice and adding their values." }
            //    , new Stat {Name = "Education",  CreateDate = DateTime.Now, Description ="This stat reflect the knowledge your character has acquired from their formal education. To calculate your character's EDU stat, roll three six-sided dice, add the results, and then add three." }
            //};

            //stats.ForEach(stat => context.Stats.Add(stat));
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
