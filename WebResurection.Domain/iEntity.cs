using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResurection.Domain
{
    /// <summary>
    /// All data that comes from a table will implement this. For the most part everything will be an entity
    /// however, we have this in here for if in the future we start using composit keys.
    /// </summary>
    public interface iEntity
    {
    }
}
