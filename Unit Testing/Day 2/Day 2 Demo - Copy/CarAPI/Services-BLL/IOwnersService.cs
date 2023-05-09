using CarAPI.Entities;
using CarAPI.Models;
using System.Collections.Generic;

namespace CarAPI.Services_BLL
{
    public interface IOwnersService
    {
        bool AddOwner(Owner owner);
        string BuyCar(BuyCarInput input);
        Owner GetById(int id);
        List<Owner> GetOwners();
    }
}