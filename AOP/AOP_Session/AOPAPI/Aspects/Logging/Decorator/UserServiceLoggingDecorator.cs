using AOPAPI.BLL;
using AOPAPI.DAL;
using AOPAPI.Models;
using AOPAPI.Utilities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace AOPAPI.Aspects.Logging
{
    public class UserServiceLoggingDecorator : IUserService
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserServiceLoggingDecorator(
            [Dependency("Validator")] IUserService userService,
            ILogger logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public bool AssignCourse(AssignCourseInput input)
        {
            try
            {
                return _userService.AssignCourse(input);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return _userService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return null;
            }
        }

        public User GetById(int id)
        {
            try
            {
                return _userService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return null;
            }
        }
    }
}