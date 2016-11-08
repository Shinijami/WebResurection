using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public class ImplementedStat : Entity<int>
    {
        public double Value { get; set; }
        public double Modifier { get; set; }

        public int StatId { get; set; }
        public virtual Stat Stat { get; set; }

        public int CharacterId { get; set; }
        public virtual Character Character{ get; set; }

    }
}
