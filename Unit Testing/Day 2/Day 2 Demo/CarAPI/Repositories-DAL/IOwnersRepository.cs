using CarAPI.Entities;
using System.Collections.Generic;

namespace CarAPI.Repositories_DAL
{
    public interface IOwnersRepository
    {
        bool AddOwner(Owner owner);
        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);
    }
}