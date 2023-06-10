using AOPAPI.BLL;
using AOPAPI.DAL;
using AOPAPI.Models;
using AOPAPI.Utilities;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                _logger.LogDebug($"{nameof(AssignCourse)} params {input}");

                Stopwatch sw = new Stopwatch();
                sw.Start();
                var res = _userService.AssignCourse(input);
                sw.Stop();

                _logger.LogDebug($"{nameof(AssignCourse)} took {sw.ElapsedMilliseconds}ms");
                _logger.LogDebug($"{nameof(AssignCourse)} returned {res}");
                _logger.LogDebug($"---------------------------------------------------");

                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                _logger.LogDebug($"---------------------------------------------------");
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