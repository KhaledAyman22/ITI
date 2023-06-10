using AOPAPI.Aspects.Logging.ILWeaving;
using AOPAPI.DAL;
using AOPAPI.DAL.Repositories;
using AOPAPI.Models;
using AOPAPI.Utilities;
using AOPAPI.Utilities.Validation;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOPAPI.BLL
{
    [LoggingAspect]
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        //private readonly ILogger _logger;
        //private readonly IValidationService _validationService;
        //private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserService(
            IUserRepository userRepository,
            ICourseRepository courseRepository
            //ILogger logger
            //IValidationService validationService
            )
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            //_logger = logger;
            //_validationService = validationService;
            //XmlConfigurator.Configure();
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userRepository.GetAll();
            throw new Exception("Postsharp exc");
            return users;
        }

        public User GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public bool AssignCourse(AssignCourseInput input)
        {
            //if (!_validationService.IsValid(input)) 
            //    return false;
            var user = _userRepository.GetById(input.UserId);
            var course = _courseRepository.GetById(input.CourseId);
            return _userRepository.AssignCourse(user, course);
        }

        private void Test() { }

        #region Before adding aspects
        //private void LogError(Exception exception)
        //{
        //    _log.Error(exception.Message, exception);
        //} 

        //private bool IsValid(AssignCourseInput input)
        //{
        //    var user = _userRepository.GetById(input.UserId);
        //    if (user == null)
        //        return false;

        //    var course = _courseRepository.GetById(input.CourseId);
        //    if (course == null) 
        //        return false;

        //    if (input.PaidAmount != course.Price) 
        //        return false;

        //    return true;
        //}
        #endregion
    }
}
