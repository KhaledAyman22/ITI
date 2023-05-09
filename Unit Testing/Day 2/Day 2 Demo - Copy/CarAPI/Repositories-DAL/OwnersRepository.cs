using CarAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CarAPI.Repositories_DAL
{
    public class OwnersRepository : IOwnersRepository
    {

        private readonly InMemoryContext _context;

        public OwnersRepository(InMemoryContext context)
        {
            _context = context;
        }

        public List<Owner> GetAllOwners()
        {
            return _context.Owners;
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == id);
        }

        public bool AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return true;
        }

    }
}