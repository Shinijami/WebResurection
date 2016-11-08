using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model
{
    class Residence : Entity<int>, iBuilding
    {
        public int Capacity
        {
            get
            {
                return Capacity;
            }

            set
            {
                Capacity = value;
            }
        }

        public string Name
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

       
    }
}
