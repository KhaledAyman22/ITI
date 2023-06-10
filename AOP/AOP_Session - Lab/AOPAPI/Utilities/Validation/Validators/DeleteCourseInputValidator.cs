using AOPAPI.DAL.Repositories;
using AOPAPI.Models;
using AOPAPI.Utilities.Validation.ValidatorContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.Utilities.Validation.Validators
{
    public class DeleteCourseInputValidator : IInputValidator<DeleteCourseInput>
    {
        private readonly ICourseRepository _courseRepository;

        public DeleteCourseInputValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public bool IsValid(DeleteCourseInput input)
        {
            var course = _courseRepository.GetById(input.CourseId);
            return course != null;
        }
    }
}