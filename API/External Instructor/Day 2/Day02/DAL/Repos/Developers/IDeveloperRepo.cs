using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Developers
{
    public interface IDeveloperRepo
    {
        public ICollection<Developer> GetDevelopersByIds(IEnumerable<int> ids);
    }
}
