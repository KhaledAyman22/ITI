using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPITests.Fake
{
    public class FakeOwnersRepository : IOwnersRepository
    {
        private readonly FakeContext _context;

        public FakeOwnersRepository(FakeContext context)
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
