using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using System.Collections.Generic;
using Unity;

namespace CarAPI.Services_BLL
{
    public class OwnersService : IOwnersService // dependent
    {
        private readonly IOwnersRepository _ownerRepository;
        private readonly ICarsRepository _carsRepository;
        private readonly IPaymentService _paymentService;

        public OwnersService(IOwnersRepository ownersRepository, ICarsRepository carsRepository, IPaymentService paymentService)
        {
            _ownerRepository = ownersRepository;
            _carsRepository = carsRepository;
            _paymentService = paymentService;
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.GetAllOwners();
        }

        public bool AddOwner(Owner owner)
        {
            return _ownerRepository.AddOwner(owner);
        }


        public Owner GetById(int id)
        {
            var owner = _ownerRepository.GetOwnerById(id);
            return owner;
        }

        public string BuyCar(BuyCarInput input)
        {
            if (input.Amount <= 0)
                return "Amount should be positive";
            var car = _carsRepository.GetCarById(input.CarId);
            if (car == null)
                return "Car doesn't exist";
            if (car.Owner != null)
                return "Already sold";
            var owner = _ownerRepository.GetOwnerById(input.OwnerId);
            if (owner == null)
                return "Owner doesn't exist";

            owner.Car = car;
            car.Owner = owner;

            var paymentResult = _paymentService.Pay(input.Amount);
            return $"Successfull \r\nCar of Id: {input.CarId} is bought by {owner.Name} with payment result {paymentResult}";
        }
    }
}