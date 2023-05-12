using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Task02.DAL.Models;

namespace Task02.DAL.Repos
{
    internal class DeveloperRepo : IDeveloperRepo
    {
        private readonly APID02Context _context;

        public DeveloperRepo(APID02Context context)
        {
            _context = context;
        }

        public void Add(Developers student)
        {
            _context.Add(student);
        }

        public void Delete(int id)
        {
            var student = _context.Developers.Find(id);
            
            if (student is null) return;
            
            _context.Remove(student);
        }

        public Developers? Get(int id)
        {
            return _context.Developers.Find(id);
        }

        public IEnumerable<Developers> GetAll()
        {
            return _context.Developers.AsNoTracking().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Developers student)
        {
            _context.Update(student);
        }
    }
}
