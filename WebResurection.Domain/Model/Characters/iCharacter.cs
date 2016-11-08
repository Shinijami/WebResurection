using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model.Characters
{
    public interface iCharacter
    {
        double HealthPoints { get; set; }
        double Damage { get; set; }
    }
}
