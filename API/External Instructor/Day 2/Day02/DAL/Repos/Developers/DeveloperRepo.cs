using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Developers
{
    public class DeveloperRepo : IDeveloperRepo
    {
        private readonly APIDay02Context _context;

        public DeveloperRepo(APIDay02Context context)
        {
            _context = context;
        }

        public ICollection<Developer> GetDevelopersByIds(IEnumerable<int> ids)
        {
            return _context.Developers.Where(d => ids.Contains(d.Id)).ToList();
        }
    }
}
