using AOPAPI.DAL.Repositories;
using AOPAPI.Models;
using AOPAPI.Utilities.Validation.ValidatorContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.Utilities.Validation.Validators
{
    public class AssignCourseInputValidator : IInputValidator<AssignCourseInput>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;

        public AssignCourseInputValidator(IUserRepository userRepository, ICourseRepository courseRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }
        public bool IsValid(AssignCourseInput input)
        {
            var user = _userRepository.GetById(input.UserId);
            if (user == null)
                return false;

            var course = _courseRepository.GetById(input.CourseId);
            if (course == null)
                return false;

            if (input.PaidAmount != course.Price)
                return false;

            return true;
        }
    }
}