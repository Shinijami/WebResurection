using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain.Model
{
    public interface iBuilding
    {
        string Name { get; set; }
        int Capacity { get; set; }

        //    public Building()
        //    {
        //        Name = "";
        //        Capacity = 1;
        //    }

        //    public Building(string name, int capacity)
        //    {
        //        Name = name;
        //        Capacity = capacity;
        //    }
    }
}
