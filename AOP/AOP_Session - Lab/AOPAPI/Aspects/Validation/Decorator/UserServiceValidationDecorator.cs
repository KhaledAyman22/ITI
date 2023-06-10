using AOPAPI.BLL;
using AOPAPI.DAL;
using AOPAPI.Models;
using AOPAPI.Utilities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace AOPAPI.Aspects.Validation
{
    public class UserServiceValidationDecorator : IUserService
    {
        private readonly IUserService _userService;
        private readonly IValidationService _validationService;

        public UserServiceValidationDecorator(
            [Dependency("Base")] IUserService userService,
            IValidationService validationService)
        {
            _userService = userService;
            _validationService = validationService;
        }

        public bool AssignCourse(AssignCourseInput input)
        {
            if (!_validationService.IsValid(input))
                return false;
            return _userService.AssignCourse(input);
        }

        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        public User GetById(int id)
        {
            return _userService.GetById(id);
        }
    }
}