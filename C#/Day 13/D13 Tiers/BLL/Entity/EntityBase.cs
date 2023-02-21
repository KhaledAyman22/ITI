using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public  class EntityBase
    {
        public EntityState State { get; set; } = EntityState.UnChanged;
    }
}
