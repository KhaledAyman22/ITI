using System;
using System.Collections.Generic;
using System.Linq;
using Task02.BLL.UIModels;
using Task02.DAL.Repos;

namespace Task02.BLL.Managers
{
    public class DeveloperManager : IDeveloperManager
    {
        private readonly IDeveloperRepo _developerRepo;

        public DeveloperManager(IDeveloperRepo studentRepo)
        {
            _developerRepo = studentRepo;
        }

        public void Add(Developer_UI student)
        {
            _developerRepo.Add(new()
            {
                Id = student.Id,
                Name = student.Name,
            });

            _developerRepo.Save();
        }

        public void Delete(int id)
        {
            _developerRepo.Delete(id);
            _developerRepo.Save();
        }

        public Developer_UI? Get(int id)
        {
            var std = _developerRepo.Get(id);
            
            if (std == null) return null;

            return new() { 
                Id = std.Id,
                Name = std.Name,
            };
        }

        public IEnumerable<Developer_UI>? GetAll()
        {
            return _developerRepo.GetAll()?.Select(s => new Developer_UI()
            {
                Id = s.Id,
                Name = s.Name,
            });
        }

        public void Update(Developer_UI student)
        {
            _developerRepo.Update(new()
            {
                Id = student.Id,
                Name = student.Name,
            });
            _developerRepo.Save();
        }
    }
}
