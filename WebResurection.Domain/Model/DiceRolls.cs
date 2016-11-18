using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model
{
    public static class DiceRolls
    {
        private static Random rnd = new Random();

        public static int Roll(int numDice, int sides, int modifier)
        {
            int iteration = 0;
            int returnValue = 0;
            do
            {
                returnValue += rnd.Next(1, sides);
                iteration++;
            } while (iteration < numDice);
            return returnValue + modifier;
        }
    }
}
